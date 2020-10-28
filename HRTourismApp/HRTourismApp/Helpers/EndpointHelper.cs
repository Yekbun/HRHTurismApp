using System;

namespace HRTourismApp.Helpers
{
    public class EndpointHelper
    {
        public static string Pagination(string currentEndpoint, Pagination pagination)
        {
            try
            {
                if (pagination == null)
                {
                    throw new MobileException("Unable to modify query parameter, please check your data");
                }

                if ((pagination.PageIndex == 0 || pagination.PageIndex > 0) && pagination.ItemPerPage > 0)
                {
                    string pageQuery = currentEndpoint.Contains("?") ? "&" : "?";
                    currentEndpoint += pageQuery + "PageIndex=" + pagination.PageIndex + "&ItemPerPage=" + pagination.ItemPerPage;
                }

                if (!string.IsNullOrEmpty(pagination.SearchBy))
                {
                    string searchQuery = currentEndpoint.Contains("?") ? "&" : "?";
                    currentEndpoint += searchQuery + "Search=" + pagination.SearchBy;
                }

                if ((pagination.FilterByProperty != null && pagination.FilterByProperty.Count > 0) && (pagination.FilterByValue != null && pagination.FilterByValue.Count > 0))
                {
                    int filterValueIndex = 0;

                    pagination.FilterByProperty.ForEach(filterProperty =>
                    {
                        string filterValue = pagination.FilterByValue[filterValueIndex];

                        if (!string.IsNullOrEmpty(filterProperty) && !string.IsNullOrEmpty(filterValue))
                        {
                            string filterQuery = currentEndpoint.Contains("?") ? "&" : "?";
                            currentEndpoint += filterQuery + filterProperty + "=" + filterValue;

                            filterValueIndex++;
                        }
                    });
                }

                if (!string.IsNullOrEmpty(pagination.SortByProperty) && !string.IsNullOrEmpty(pagination.SortByValue))
                {
                    string sortQuery = currentEndpoint.Contains("?") ? "&" : "?";
                    currentEndpoint += sortQuery + pagination.SortByProperty + "=" + pagination.SortByValue;
                }
            }
            catch (MobileException exception)
            {
                throw exception;
            }
            catch (Exception exception)
            {
                LogHelper.WriteLog(exception);
            }

            return currentEndpoint;
        }
    }
}
