﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tcctelaTogepi.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using Firebase.Database;
using Xamarin.CommunityToolkit.Extensions;

namespace tcctelaTogepi.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Mapa : ContentPage
    {
        MapaViewModel viewModel;

        public Mapa()
        {
            InitializeComponent();

            viewModel = new MapaViewModel();
            BindingContext = viewModel;
            MapaViewModel.mapa = map;

            var result = Geolocation.GetLocationAsync(new GeolocationRequest(GeolocationAccuracy.Default, TimeSpan.FromMinutes(1)));
            viewModel.MoverCameraUsuarioAsync(result);
            viewModel.LocalizarEscola();   
        }

        private void btnSend_Clicked(object sender, EventArgs e)
        {
            var page = new Ocorrencia();
            App.Current.MainPage.Navigation.PushAsync(page);
        }

        

        private void OpenMenu()
        {
            MenuGrid.IsVisible = true;

            Action<double> callback = input => MenuView.TranslationX = input;
            MenuView.Animate("anim", callback, -260, 0, 16, 300, Easing.CubicInOut);
        }
        public void CloseMenu()
        {
            Action<double> callback = input => MenuView.TranslationX = input;
            MenuView.Animate("anim", callback, 0, -260, 16, 300, Easing.CubicInOut);

            MenuGrid.IsVisible = false;
        }

        private void btnMenu_Clicked(object sender, EventArgs e)
        {
            OpenMenu();
        }
        private void OverlayTapped(object sender, EventArgs e)
        {
            CloseMenu();
        }

        private void btnHome_Clicked(object sender, EventArgs e)
        {
            var result = Geolocation.GetLocationAsync(new GeolocationRequest(GeolocationAccuracy.Default, TimeSpan.FromMinutes(1)));
            viewModel.MoverCameraUsuarioAsync(result);
        }

        async void btnBuscar_ClickedAsync(object sender, EventArgs e)
        {
            await this.DisplayToastAsync("Hello, World", 10000);
        }
    }
}