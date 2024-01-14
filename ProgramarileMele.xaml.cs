using Patricia_Adelina_mobila.Models;
using Patricia_Adelina_mobila;


namespace Patricia_Adelina_mobila
{
    public partial class ProgramarileMele : ContentPage
    {
        public ProgramarileMele()
        {
            InitializeComponent();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var plist = (ProgramareFilm)BindingContext;
            plist.DataProgramare = DateTime.UtcNow;
            if (CinematografulPicker.SelectedItem != null)
            {
                Cinematograf cinematografSelectat = (CinematografulPicker.SelectedItem as Cinematograf);
                plist.CinematografID = cinematografSelectat.ID;
            }

            await App.Database.SaveProgramareFilmAsync(plist);
            await Navigation.PopAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var plist = (ProgramareFilm)BindingContext;
            await App.Database.DeleteProgramareFilmAsync(plist);
            await Navigation.PopAsync();
        }

        async void OnDeleteItemButtonClicked(object sender, EventArgs e)
        {
            ServiuciuCinematograf serviciu;
            var programare = (ProgramareFilm)BindingContext;
            if (listView.SelectedItem != null)
            {
                serviciu = listView.SelectedItem as ServiuciuCinematograf;
                var listaToateServiciile = await App.Database.GetListaServiciiCinematografAsync();
                var listaServiciu = listaToateServiciile.FindAll(x => x.ServiuciuCinematografID == serviciu.ID && x.ProgramareFilmID == programare.ID);
                await App.Database.DeleteListaServiciuCinematografAsync(listaServiciu.FirstOrDefault());
                await Navigation.PopAsync();
            }
        }

        async void OnChooseButtonClicked(object sender, EventArgs e)
        {
            if (this.BindingContext is ProgramareFilm lprogramare)
            {
                await Navigation.PushAsync(new ServiciuCinematografPage(lprogramare)
                {
                    BindingContext = new ServiuciuCinematograf()
                });
            }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var items = await App.Database.GetCinematografeAsync();
            CinematografulPicker.ItemsSource = items;
            CinematografulPicker.ItemDisplayBinding = new Binding("DetaliiCinematograf");
            var lprogramare = (ProgramareFilm)BindingContext;
            listView.ItemsSource = await App.Database.GetListaServiciiCinematografAsync(lprogramare.ID);
        }
    }
}

