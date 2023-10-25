using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HikeManagement.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsHike : ContentPage
    {
        public DetailsHike(Model.HikeModel model)
        {
            InitializeComponent();
            Title = "Details hike";
            nameHike.Text = model.Name;
            locationHike.Text = model.Location;
            dateHike.Text = model.Date;
            parkingAvaiHike.Text = model.Parking;
            DesHike.Text = model.Description;
            LengthHike.Text = model.Length;
            LevelHike.Text = model.Level;
            MemQuantityHike.Text = model.Quantity;
            TypeHike.Text = model.TypeHike;

        }
    }
}