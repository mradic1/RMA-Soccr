using Soccr.Services;

namespace Soccr;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(usernameEntry.Text))
        {
            await DisplayAlert("Invalid login info", "You must provide an username", "OK");
            return;
        }

        if (string.IsNullOrEmpty(passwordEntry.Text))
        {
            await DisplayAlert("Invalid login info", "You must provide a password", "OK");
            return;
        }

        if (!await HttpService.AuthorizeAsync(usernameEntry.Text, passwordEntry.Text))
        {
            await DisplayAlert("Login error", "Username or password is invalid", "OK");
            usernameEntry.Text = string.Empty;
            passwordEntry.Text = string.Empty;
            return;
        }

        await Navigation.PushAsync(new OCRPage());
    }
}

