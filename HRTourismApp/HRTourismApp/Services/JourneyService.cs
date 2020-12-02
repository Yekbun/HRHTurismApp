using HRTourismApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HRTourismApp.APIServices;
using System.Threading;
using HRTourismApp.Helpers;
using HRTourismApp.Models.Core;

namespace HRTourismApp.Services
{
    public class JourneyService 
    {
        private string _endpoint;
        private static CancellationToken _cancellationToken; // TODO: online ortamda static ozelligini kaldirip dene

        private Task<List<JourneyDTO>> getMockData()
        {
            List<JourneyDTO> list = new List<JourneyDTO>();

            list.Add(new JourneyDTO
            {
                Id = 69,
                DriverId = 129,
                DriverName = "Surucu 1",
                VehicleId = 35,
                VehiclePlaque = "34 TX1258",
                CompanyId = 8,
                From = "Şirinevler, Bahçelievler/İstanbul",
                To = "Mecidiyeköy, Şişli/İstanbul",
                StartDate = Convert.ToDateTime("2020-11-11 17:00:00"),
                FinishDate = Convert.ToDateTime("2020-11-11 17:30:00"),
                Fees = 275
            });
            list.Add(new JourneyDTO
            {
                Id = 70,
                DriverId = 129,
                DriverName = "Surucu 1",
                VehicleId = 35,
                VehiclePlaque = "34 KL23",
                CompanyId = 8,
                From = "Şirinevler, Bahçelievler/İstanbul",
                To = "Mecidiyeköy, Şişli/İstanbul",
                StartDate = Convert.ToDateTime("2020-11-13 10:30:30"),
                FinishDate = Convert.ToDateTime("2020-11-13 11:30:50"),
                Fees = 285
            });
            list.Add(new JourneyDTO
            {
                Id = 71,
                DriverId = 129,
                DriverName = "Surucu 1",
                VehicleId = 35,
                VehiclePlaque = "34 KL23",
                CompanyId = 8,
                From = "Şirinevler, Bahçelievler/İstanbul",
                To = "Mecidiyeköy, Şişli/İstanbul",
                StartDate = Convert.ToDateTime("2020-11-13 10:30:30"),
                FinishDate = Convert.ToDateTime("2020-11-13 11:30:50"),
                Fees = 290
            });
            list.Add(new JourneyDTO
            {
                Id = 72,
                DriverId = 129,
                DriverName = "Surucu 1",
                VehicleId = 35,
                VehiclePlaque = "34 KL23",
                CompanyId = 8,
                From = "Şirinevler, Bahçelievler/İstanbul",
                To = "Mecidiyeköy, Şişli/İstanbul",
                StartDate = Convert.ToDateTime("2020-11-13 10:30:30"),
                FinishDate = Convert.ToDateTime("2020-11-13 11:30:50"),
                Fees = 300
            });
            list.Add(new JourneyDTO
            {
                Id = 73,
                DriverId = 129,
                DriverName = "Surucu 1",
                VehicleId = 35,
                VehiclePlaque = "34 KL23",
                CompanyId = 8,
                From = "Şirinevler, Bahçelievler/İstanbul",
                To = "Mecidiyeköy, Şişli/İstanbul",
                StartDate = Convert.ToDateTime("2020-11-13 10:30:30"),
                FinishDate = Convert.ToDateTime("2020-11-13 11:30:50"),
                Fees = 310
            });
            list.Add(new JourneyDTO
            {
                Id = 74,
                DriverId = 129,
                DriverName = "Surucu 1",
                VehicleId = 35,
                VehiclePlaque = "34 KL23",
                CompanyId = 8,
                From = "Şirinevler, Bahçelievler/İstanbul",
                To = "Mecidiyeköy, Şişli/İstanbul",
                StartDate = Convert.ToDateTime("2020-11-13 10:30:30"),
                FinishDate = Convert.ToDateTime("2020-11-13 11:30:50"),
                Fees = 315
            });
            list.Add(new JourneyDTO
            {
                Id = 75,
                DriverId = 129,
                DriverName = "Surucu 1",
                VehicleId = 35,
                VehiclePlaque = "34 KL23",
                CompanyId = 8,
                From = "Şirinevler, Bahçelievler/İstanbul",
                To = "Mecidiyeköy, Şişli/İstanbul",
                StartDate = Convert.ToDateTime("2020-11-13 10:30:30"),
                FinishDate = Convert.ToDateTime("2020-11-13 11:30:50"),
                Fees = 345
            });
            list.Add(new JourneyDTO
            {
                Id = 76,
                DriverId = 129,
                DriverName = "Surucu 1",
                VehicleId = 35,
                VehiclePlaque = "34 KL23",
                CompanyId = 8,
                From = "Şirinevler, Bahçelievler/İstanbul",
                To = "Mecidiyeköy, Şişli/İstanbul",
                StartDate = Convert.ToDateTime("2020-11-13 10:30:30"),
                FinishDate = Convert.ToDateTime("2020-11-13 11:30:50"),
                Fees = 370
            });
            list.Add(new JourneyDTO
            {
                Id = 77,
                DriverId = 129,
                DriverName = "Surucu 1",
                VehicleId = 35,
                VehiclePlaque = "34 KL23",
                CompanyId = 8,
                From = "Şirinevler, Bahçelievler/İstanbul",
                To = "Bakırköy Özgürlük Meydanı, Zuhuratbaba, Bakırköy/İstanbul",
                StartDate = Convert.ToDateTime("2020-11-13 10:30:30"),
                FinishDate = Convert.ToDateTime("2020-11-13 11:30:50"),
                Fees = 390
            });
            list.Add(new JourneyDTO
            {
                Id = 78,
                DriverId = 129,
                DriverName = "Surucu 1",
                VehicleId = 35,
                VehiclePlaque = "34 KL23",
                CompanyId = 8,
                From = "Bakırköy Özgürlük Meydanı, Zuhuratbaba, Bakırköy/İstanbul",
                To = "Mecidiyeköy, Şişli/İstanbul",
                StartDate = Convert.ToDateTime("2020-11-13 10:30:30"),
                FinishDate = Convert.ToDateTime("2020-11-13 11:30:50"),
                Fees = 400
            });
            list.Add(new JourneyDTO
            {
                Id = 80,
                DriverId = 129,
                DriverName = "Surucu 1",
                VehicleId = 35,
                VehiclePlaque = "34 KL23",
                CompanyId = 8,
                From = "Şirinevler, Bahçelievler/İstanbul",
                To = "Büyükeceli, Büyükeceli Köyü Yolu, Gülnar/Mersin",
                StartDate = Convert.ToDateTime("2020-11-13 10:30:30"),
                FinishDate = Convert.ToDateTime("2020-11-13 11:30:50"),
                Fees = 420
            });
            list.Add(new JourneyDTO
            {
                Id = 81,
                DriverId = 129,
                DriverName = "Surucu 1",
                VehicleId = 35,
                VehiclePlaque = "34 KL23",
                CompanyId = 8,
                From = "Büyükeceli, Büyükeceli Köyü Yolu, Gülnar/Mersin",
                To = "Mecidiyeköy, Şişli/İstanbul",
                StartDate = Convert.ToDateTime("2020-11-13 10:30:30"),
                FinishDate = Convert.ToDateTime("2020-11-13 11:30:50"),
                Fees = 450
            });
            list.Add(new JourneyDTO
            {
                Id = 82,
                DriverId = 129,
                DriverName = "Surucu 1",
                VehicleId = 35,
                VehiclePlaque = "34 KL23",
                CompanyId = 8,
                From = "Bakırköy Özgürlük Meydanı, Zuhuratbaba, Bakırköy/İstanbul",
                To = "Mecidiyeköy, Şişli/İstanbul",
                StartDate = Convert.ToDateTime("2020-11-13 10:30:30"),
                FinishDate = Convert.ToDateTime("2020-11-13 11:30:50"),
                Fees = 450
            });

            return Task.FromResult(list);
        }

        public JourneyService()
        {
            _cancellationToken = new CancellationToken();
        }

        public Task<List<JourneyDTO>> GetAllJourney(Pagination pagination = null, int driverId=0)
        {            
            try
            {
                _endpoint = Constants.BASE_API_URL + "api/Journeys/" + App.User.CompanyId ;
                if (driverId != 0)
                    _endpoint += "/"+ driverId;

                if (pagination != null)
                   _endpoint = EndpointHelper.Pagination(_endpoint, pagination);
                

                var responseTask = BaseAPIService.Get<List<JourneyDTO>>(_endpoint, _cancellationToken);
                return Task.FromResult(responseTask.Result);
            }
            catch (Exception ex)
            {
                throw (ex);
            } 

        }

        public Task<int> DeleteAsync(long id, string cancelDesc)
        {
            try
            {
                _endpoint = Constants.BASE_API_URL + "api/Journey"+ "?id=" + id + " & userId = " + App.User.Id.ToString() + " & cancelDesc = '" + cancelDesc + "'";
                var responseTask = BaseAPIService.Delete<APIResponse>(_endpoint, _cancellationToken);
                return Task.FromResult(1);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public Task<JourneyDTO> GetJourney(long id)
        {
            try
            {
                _endpoint = Constants.BASE_API_URL + "/" + id;
                var responseTask = BaseAPIService.Get<JourneyDTO>(_endpoint, _cancellationToken);
                return Task.FromResult(responseTask.Result);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public Task<int> SaveAsync(JourneyDTO journey)
        {
            try
            {                
                journey.UserId = App.User.Id;
                _endpoint = Constants.BASE_API_URL + "api/Journey";
                var response = BaseAPIService.Post<APIResponse>(_endpoint, journey, _cancellationToken);
                response.Wait();
                var xx = response.Status;
                if (response.IsCompleted)                                   
                    return Task.FromResult(1);
                else
                    return Task.FromResult(0);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public Task<int> UpdateAsync(JourneyDTO journey)
        {
            try
            {
                journey.UserId = App.User.Id;
                _endpoint = Constants.BASE_API_URL + "api/Journey/" + journey.Id;
                var response = BaseAPIService.Put<APIResponse>(_endpoint, journey, _cancellationToken);
                response.Wait();
                if (response.Result != null)
                    return Task.FromResult(1);
                else
                    return Task.FromResult(0);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
