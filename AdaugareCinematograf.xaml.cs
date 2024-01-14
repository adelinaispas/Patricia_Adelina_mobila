using Patricia_Adelina_mobila.Models;

namespace Patricia_Adelina_mobila;

public partial class AdaugareCinematograf : ContentPage
{
	public AdaugareCinematograf()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetCinematografeAsync();
    }
    async void OnCinematografAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CinematografPage
        {
            BindingContext = new Cinematograf()
        });
    }
    async void OnListViewItemSelected(object sender,SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new CinematografPage
            {
                BindingContext = e.SelectedItem as Cinematograf
            });
        }
    }
}