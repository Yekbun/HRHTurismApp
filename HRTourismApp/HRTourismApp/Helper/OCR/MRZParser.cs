using HRTourismApp.Models;
using HRTourismApp.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace HRTourismApp.Helper.OCR
{
    public class MRZParser
    {
        private readonly CountryService _countryService = new CountryService();

        private readonly Dictionary<char, int> _checkDigitArray = new Dictionary<char, int>();

        //Parsing is based on https://en.wikipedia.org/wiki/Machine-readable_passport
        //Useful information https://www.icao.int/publications/Documents/9303_p3_cons_en.pdf

        public MRZResult Parse(string newmrz)
        {
            //It should be done before calling this function
            //var newmrz = mrz.TrimEnd().Replace("«", "<<").Replace("&", "<").Replace("\n", "").Replace(" ", "");
            //newmrz = System.Text.RegularExpressions.Regex.Replace(newmrz, "[']+", "");

            var validationMessage = MRZValidationMessage(newmrz);
            if (!string.IsNullOrEmpty(validationMessage))
            {
                var errorObj = new MRZResult { IsValid = false, ValidationMessage = validationMessage };
                return errorObj;
            }

            var retVal = new MRZResult
            {
                DocumentType = DocumentType(newmrz),
                Gender = Gender(newmrz),
                ExpireDate = ExpireDate(newmrz),
                IssuingCountryIso = IssuingCountryIso(newmrz),
                FirstName = FirstName(newmrz),
                LastName = LastName(newmrz),
                DocumentNumber = DocumentNumber(newmrz),
                NationalityIso = NationalityIso(newmrz),
                DateOfBirth = DateOfBirth(newmrz),
                IsValid = true
            };

            retVal.DocumentTypeDescription = DocumentTypeDescription(retVal.DocumentType);
            //retVal.IssuingCountryName = IssuingCountryName(retVal.IssuingCountryIso);
            retVal.NationalityName = NationalityName(retVal.NationalityIso);

            return retVal;
        }

        private string MRZValidationMessage(string mrz)
        {
            if (string.IsNullOrEmpty(mrz)) throw new Exception("Empty MRZ");
            if (mrz.Length < 88) throw new Exception($"MRZ length is not valid should be 88 but it is {mrz.Length}");
            //if (mrz.Substring(0, 1) != "P" && mrz.Substring(0, 1) != "V" && mrz.Substring(0, 1) != "C") return $"Document Type should either be P, V or C";
            string checkDigit = CheckDigit(mrz.Substring(44 + 0, 10) + mrz.Substring(44 + 13, 7) +
                           mrz.Substring(44 + 21, 22));
            if (checkDigit != mrz.Substring(87, 1)) throw new Exception("unable to read passport properly, please upload well-scanned document");
            return string.Empty;
        }

        private string DocumentType(string mrz)
        {
            return mrz.Substring(0, 1);

        }

        private string DocumentTypeDescription(string docType)
        {
            switch (docType)
            {
                case "P":
                    return "Passport";
                case "C":
                    return "Card";
                case "V":
                    return "Visa";
                default:
                    throw new Exception("Invalid Document Type");
            }

        }

        private string IssuingCountryIso(string mrz)
        {
            string iso = mrz.Substring(2, 3);
            iso = iso.Replace('1', 'I').Replace('6', 'G');
            return iso;
        }

        private string IssuingCountryName(string issIso)
        {
            var natItem = _countryService.GetCountryByCode(issIso);
            return natItem != null ? natItem.Name : string.Empty;
        }

        private string FirstName(string mrz)
        {
            var nameArraySplit = mrz.Substring(5).Split(new[] { "<<" }, StringSplitOptions.RemoveEmptyEntries);
            return nameArraySplit.Length >= 2 ? nameArraySplit[1].Replace("<", " ") : nameArraySplit[0].Replace("<", " ");
        }

        private string LastName(string mrz)
        {
            var nameArraySplit = mrz.Substring(5).Split(new[] { "<<" }, StringSplitOptions.RemoveEmptyEntries);
            return nameArraySplit.Length >= 2 ? nameArraySplit[0].Replace("<", " ") : string.Empty;
        }


        private string DocumentNumber(string mrz)
        {
            string passport = mrz.Substring(0 + 44, 9);
            string checkDigit = CheckDigit(passport);
            if (checkDigit != mrz.Substring(9 + 44, 1)) return string.Empty;

            return passport.Replace("<", "");

        }

        private string NationalityIso(string mrz)
        {
            string iso = mrz.Substring(10 + 44, 3);
            iso = iso.Replace('1', 'I').Replace('6', 'G');
            return iso;
        }

        private string NationalityName(string natIso)
        {
            var natItem = _countryService.GetCountryByCode(natIso);
            return natItem != null ? natItem.Name : string.Empty;

        }

        private DateTime? DateOfBirth(string mrz)
        {
            string checkDigit = CheckDigit(mrz.Substring(13 + 44, 6));
            if (checkDigit != mrz.Substring(19 + 44, 1)) return null;
            try
            {
                var dob = new DateTime(int.Parse(DateTime.Now.Year.ToString().Substring(0, 2) + mrz.Substring(13 + 44, 2)), int.Parse(mrz.Substring(15 + 44, 2)),
                        int.Parse(mrz.Substring(17 + 44, 2)));

                if (dob < DateTime.Now)
                    return dob;

                return dob.AddYears(-100); //Subtract a century
            }
            catch (Exception exs)
            {
                return null;
            }

        }

        private string Gender(string mrz)
        {
            string gender = mrz.Substring(20 + 44, 1);
            if (Regex.IsMatch(gender, "(M|F)")) return gender;
            return string.Empty;
        }

        private DateTime? ExpireDate(string mrz)
        {
            string checkDigit = CheckDigit(mrz.Substring(21 + 44, 6));
            if (checkDigit != mrz.Substring(27 + 44, 1)) return null;
            //I am assuming all passports will certainly expire this century
            try
            {
                return new DateTime(int.Parse(DateTime.Now.Year.ToString().Substring(0, 2) + mrz.Substring(21 + 44, 2)), int.Parse(mrz.Substring(23 + 44, 2)),
                                    int.Parse(mrz.Substring(25 + 44, 2)));
            }
            catch (Exception ex)
            {
                return null;
            }

        }      

        internal string CheckDigit(string icaoPassportNumber)
        {
            //http://www.highprogrammer.com/alan/numbers/mrp.html#checkdigit
            if (!_checkDigitArray.Any())
                FillCheckDigitDictionary();

            icaoPassportNumber = icaoPassportNumber.ToUpper();
            var inputArray = icaoPassportNumber.Trim().ToCharArray();
            var multiplier = 7;
            var total = 0;
            foreach (var dig in inputArray)
            {
                total = total + _checkDigitArray[dig] * multiplier;
                if (multiplier == 7) multiplier = 3;
                else if (multiplier == 3) multiplier = 1;
                else if (multiplier == 1) multiplier = 7;
            }

            long result;
            Math.DivRem(total, 10, out result);
            return result.ToString();
        }
        private void FillCheckDigitDictionary()
        {
            _checkDigitArray.Add('<', 0);
            _checkDigitArray.Add('0', 0);
            _checkDigitArray.Add('1', 1);
            _checkDigitArray.Add('2', 2);
            _checkDigitArray.Add('3', 3);
            _checkDigitArray.Add('4', 4);
            _checkDigitArray.Add('5', 5);
            _checkDigitArray.Add('6', 6);
            _checkDigitArray.Add('7', 7);
            _checkDigitArray.Add('8', 8);
            _checkDigitArray.Add('9', 9);
            _checkDigitArray.Add('A', 10);
            _checkDigitArray.Add('B', 11);
            _checkDigitArray.Add('C', 12);
            _checkDigitArray.Add('D', 13);
            _checkDigitArray.Add('E', 14);
            _checkDigitArray.Add('F', 15);
            _checkDigitArray.Add('G', 16);
            _checkDigitArray.Add('H', 17);
            _checkDigitArray.Add('I', 18);
            _checkDigitArray.Add('J', 19);
            _checkDigitArray.Add('K', 20);
            _checkDigitArray.Add('L', 21);
            _checkDigitArray.Add('M', 22);
            _checkDigitArray.Add('N', 23);
            _checkDigitArray.Add('O', 24);
            _checkDigitArray.Add('P', 25);
            _checkDigitArray.Add('Q', 26);
            _checkDigitArray.Add('R', 27);
            _checkDigitArray.Add('S', 28);
            _checkDigitArray.Add('T', 29);
            _checkDigitArray.Add('U', 30);
            _checkDigitArray.Add('V', 31);
            _checkDigitArray.Add('W', 32);
            _checkDigitArray.Add('X', 33);
            _checkDigitArray.Add('Y', 34);
            _checkDigitArray.Add('Z', 35);
        }

    }
}