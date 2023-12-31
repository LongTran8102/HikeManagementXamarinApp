﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HikeManagement.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddHike : ContentPage
    {
        public AddHike()
        {
            InitializeComponent();
        }
        Model.HikeModel _model;
        public AddHike(Model.HikeModel model)
        {
            InitializeComponent();
            Title = "Edit hike";
            _model = model;
            nameEnter.Text = model.Name;
            locationEnter.Text = model.Location;
            dateEnter.Text = model.Date;
            parkingEnter.Text = model.Parking;
            lengthEnter.Text= model.Length;
            descriptionEnter.Text= model.Description;
            levelEnter.Text = model.Level;
            quantityEnter.Text = model.Quantity;
            typeEnter.Text = model.TypeHike;
            nameEnter.Focus();


        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameEnter.Text) || string.IsNullOrWhiteSpace(locationEnter.Text) || string.IsNullOrWhiteSpace(dateEnter.Text)
                || string.IsNullOrWhiteSpace(parkingEnter.Text) || string.IsNullOrWhiteSpace(lengthEnter.Text) ||
                string.IsNullOrWhiteSpace(levelEnter.Text) || string.IsNullOrWhiteSpace(quantityEnter.Text) || string.IsNullOrWhiteSpace(typeEnter.Text))
            {
                await DisplayAlert("Invalid", "Please enter all information!", "Got it");
            }
            else if (_model != null)
            {
                UpdateHikes();
            }
            else
                AddNewHike();
        }
        async void AddNewHike()
        {
            await App.MyDatabase.CreateHike(new Model.HikeModel
            {
                Name = nameEnter.Text,
                Location = locationEnter.Text,
                Date = dateEnter.Text,
                Parking = parkingEnter.Text,
                Length = lengthEnter.Text,
                Description = descriptionEnter.Text,
                Level = levelEnter.Text,
                Quantity = quantityEnter.Text,
                TypeHike = typeEnter.Text
            });
            await Navigation.PopAsync();
        }
        async void UpdateHikes()
        {
            _model.Name = nameEnter.Text;
            _model.Location = locationEnter.Text;
            _model.Date = dateEnter.Text;  
            _model.Parking = parkingEnter.Text;
            _model.Length = lengthEnter.Text;
            _model.Description = descriptionEnter.Text;
            _model.Level = levelEnter.Text;
            _model.Quantity = quantityEnter.Text;
            _model.TypeHike = typeEnter.Text;
            await App.MyDatabase.UpdateHikes(_model);
            await Navigation.PopAsync();
        }
    }
}