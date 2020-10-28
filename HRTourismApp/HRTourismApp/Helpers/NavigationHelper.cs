using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HRTourismApp.Helpers
{
    public static class NavigationHelper
    {
        public static void GoToMainPage()
        {
            Application.Current.MainPage = new NavigationPage(new HRTourismApp.Views.MainMenu());
        }

        public static async Task PushAsyncSingle(Page page, bool isAnimated = false)
        {
            var navigation = Application.Current.MainPage.Navigation;
            var pageNavigationStacks = navigation.NavigationStack;
            if (pageNavigationStacks.Count == 0 || pageNavigationStacks.Last().GetType() != page.GetType())
            {
                await navigation.PushAsync(page, isAnimated);
            }
        }

        public static async Task PopAsyncSingle(bool isAnimated = false)
        {
            var navigation = Application.Current.MainPage.Navigation;
            var pageNavigationStacks = navigation.NavigationStack;
            if (pageNavigationStacks != null && pageNavigationStacks.Count > 0)
            {
                await navigation.PopAsync(isAnimated);
            }
        }

        public static async Task PushModalAsyncSingle(Page page, bool isAnimated = false)
        {
            var navigation = Application.Current.MainPage.Navigation;
            var modalNavigationStacks = navigation.ModalStack;
            if (modalNavigationStacks.Count == 0 || modalNavigationStacks.Last().GetType() != page.GetType())
            {
                await navigation.PushModalAsync(page, isAnimated);
            }
        }

        public static async Task PopModalAsyncSingle(bool isAnimated = false)
        {
            var navigation = Application.Current.MainPage.Navigation;
            var modalNavigationStacks = navigation.ModalStack;
            if (modalNavigationStacks != null && modalNavigationStacks.Count > 0)
            {
                await navigation.PopModalAsync(isAnimated);
            }
        }

        public static async Task PushPopUpAsyncSingle(PopupPage page, bool isAnimated = false)
        {
            var navigation = PopupNavigation.Instance;
            var popupNavigationStacks = navigation.PopupStack;
            if (popupNavigationStacks.Count == 0 || popupNavigationStacks.Last().GetType() != page.GetType())
            {
                await navigation.PushAsync(page, isAnimated);
            }
        }

        public static async Task PopPopUpAsyncSingle(bool isAnimated = false)
        {
            var navigation = PopupNavigation.Instance;
            var popupNavigationStacks = navigation.PopupStack;
            if (popupNavigationStacks != null && popupNavigationStacks.Count > 0)
            {
                await navigation.PopAsync(isAnimated);
            }
        }

        public static void RemoveCurrentPage(Page page = null)
        {
            var navigation = Application.Current.MainPage.Navigation;
            var pageNavigationStacks = navigation.NavigationStack;
            if (pageNavigationStacks == null || pageNavigationStacks.Count == 0)
                return;

            if (page != null)
            {
                if (pageNavigationStacks.Last().GetType() != page.GetType() && pageNavigationStacks.Contains(page))
                    navigation.RemovePage(page);
            }
            else
            {
                var currentPage = pageNavigationStacks.LastOrDefault();
                if (currentPage != null)
                {
                    if (pageNavigationStacks.Contains(currentPage))
                        navigation.RemovePage(currentPage);
                }
            }
        }
    }
}
