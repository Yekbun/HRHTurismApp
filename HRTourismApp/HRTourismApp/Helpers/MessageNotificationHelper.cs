using Xamarin.Forms;

namespace HRTourismApp.Helpers
{
    public static class MessageNotificationHelper
    {
        public static void ShowMessageSingleButton(string message)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                await Application.Current.MainPage.DisplayAlert(string.Empty, message, "OK").ConfigureAwait(false);
            });
        }

        public static void ShowMessageMultipleButton(string message)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                await Application.Current.MainPage.DisplayAlert(string.Empty, message, "OK", "Cancel").ConfigureAwait(false);
            });
        }

        public static void ShowMessageWarning(string message)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                await Application.Current.MainPage.DisplayAlert("Warning", message, "OK").ConfigureAwait(false);
            });
        }

        public static void ShowMessageError(string message)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                await Application.Current.MainPage.DisplayAlert("Error", message, "OK").ConfigureAwait(false);
            });
        }

        public static void ShowMessageFail(string message)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                await Application.Current.MainPage.DisplayAlert("Fail", message, "OK").ConfigureAwait(false);
            });
        }

        public static void ShowMessageSuccess(string message)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                await Application.Current.MainPage.DisplayAlert("Success", message, "OK").ConfigureAwait(false);
            });
        }
    }
}
