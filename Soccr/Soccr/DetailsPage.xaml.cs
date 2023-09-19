using Soccr.Models;
using Soccr.Services;
using System.Text.RegularExpressions;

namespace Soccr;

public partial class DetailsPage : ContentPage
{
    Stream _imageStream;
    string _recognizedData = "";
    List<PlayerModel> _players;
    public DetailsPage(Stream data)
    {
        InitializeComponent();
        _imageStream = data;
        this.Loaded += DetailsPage_Loaded;
    }

    private async void DetailsPage_Loaded(object sender, EventArgs e)
    {
        processingIndicator.IsVisible = true;

        _recognizedData = await OCRService.ParseImageFromStream(_imageStream);
        var players = PlayerService.ParsePlayersFromResponse(_recognizedData);
        _players = players;
        playersListView.ItemsSource = players;

        verticalStack.Children.Remove(processingIndicator);
        savePlayersButton.IsVisible = true;
    }

    private async void savePlayersButton_Clicked(object sender, EventArgs e)
    {
        if (savePlayersButton.Text == "SAVE")
        {
            await HttpService.PostPlayersAsync(_players);
            savePlayersButton.Text = "EXIT";
        }
        else if (savePlayersButton.Text == "EXIT")
            Environment.Exit(0);
    }
}