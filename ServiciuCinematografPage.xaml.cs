using Patricia_Adelina_mobila.Models;
namespace Patricia_Adelina_mobila;

public partial class ServiciuCinematografPage : ContentPage
{
    ProgramareFilm p;
    public ServiciuCinematografPage(ProgramareFilm progr)
	{
		InitializeComponent();
        p = progr;
    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var serviciucinematograf = (ServiuciuCinematograf)BindingContext;
        await App.Database.SaveServiuiuCinematografAsync(serviciucinematograf);
        listView.ItemsSource = await App.Database.GetServiciiCinematografAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var serviciucinematograf = (ServiuciuCinematograf)BindingContext;
        await App.Database.DeleteServiuciuCinematografAsync(serviciucinematograf);
        listView.ItemsSource = await App.Database.GetServiciiCinematografAsync();
    }
    async void OnDeleteItemButtonClicked(object sender, EventArgs e)
    {
        ServiuciuCinematograf serviciu;
        var serv = (ServiuciuCinematograf)BindingContext;
        if (listView.SelectedItem != null)
        {
            serviciu = listView.SelectedItem as ServiuciuCinematograf;
            var listaToateServiciile = await App.Database.GetServiciiCinematografAsync();
            var listaServiciu = listaToateServiciile.FindAll(x => x.ID == serviciu.ID);
            await App.Database.DeleteServiuciuCinematografAsync(listaServiciu.FirstOrDefault());
            await Navigation.PopAsync();
        }
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetServiciiCinematografAsync();
    }
    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        ServiuciuCinematograf s;
        if (listView.SelectedItem != null)
        {
            s = listView.SelectedItem as ServiuciuCinematograf;
            var ls = new ListaServiciuCinematograf()
            {
                ProgramareFilmID = p.ID,
                ServiuciuCinematografID = s.ID
            };
            await App.Database.SaveListaServiciuCinematografAsync(ls);
            s.ListaServicii = new List<ListaServiciuCinematograf> { ls };
            await Navigation.PopAsync();
        }

    }
}