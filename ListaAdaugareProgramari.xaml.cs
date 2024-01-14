using Patricia_Adelina_mobila.Models;

namespace Patricia_Adelina_mobila;

public partial class ListaAdaugareProgramari : ContentPage
{
    public ListaAdaugareProgramari()
    {
        InitializeComponent();
    }

        protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetProgramariFilmAsync();
    }
    async void OnProgramareAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ProgramarileMele
        {
            BindingContext = new ProgramareFilm()
        });
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new ProgramarileMele
            {
                BindingContext = e.SelectedItem as ProgramareFilm
            });
        }
    }
}
