using Patricia_Adelina_mobila.Models;
using Plugin.LocalNotification;

namespace Patricia_Adelina_mobila;

public partial class CinematografPage : ContentPage
{
	public CinematografPage()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var cinematograf = (Cinematograf)BindingContext;
        await App.Database.SaveCinematografAsync(cinematograf);
        await Navigation.PopAsync();
    }
    async void OnArataHartaButtonClicked(object sender, EventArgs e)
    {
        var cinematograf = (Cinematograf)BindingContext;
        var addresa = cinematograf.Adresa;
        var locatii = await Geocoding.GetLocationsAsync(addresa);

        var options = new MapLaunchOptions
        {
            Name = "Cinematograful la care am sa vizionez filmul"
        };
        var locatie = locatii?.FirstOrDefault();
        var locatiaMea = new Location(46.7731796289, 23.6213886738);
        var distanta = locatiaMea.CalculateDistance(locatie, DistanceUnits.Kilometers);
        if (distanta < 4)
        {
            var request = new NotificationRequest
            {
                Title = "Ai salvata o rezervare film in apropiere!",
                Description = addresa,
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = DateTime.Now.AddSeconds(1)
                }
            };
            LocalNotificationCenter.Current.Show(request);
        }
        await Map.OpenAsync(locatie, options);
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var cinematograf = (Cinematograf)BindingContext;
        await App.Database.DeleteCinematografAsync(cinematograf);
        await Navigation.PopAsync();
    }
}