using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AnimalShelter
{
    public partial class AppointmentsPage : ContentPage
    {
        public static List<Appointment> Appointments { get; set; } = new List<Appointment>();

        public AppointmentsPage()
        {
            InitializeComponent();
            LoadAppointments();
        }

        private void LoadAppointments()
        {
            appointmentsListView.ItemsSource = Appointments;
        }
    }

    public class Appointment
    {
        public string Time { get; set; }
        public string Date { get; set; }
        public string ServiceName { get; set; }
        public string OwnerName { get; set; }
        public string PetName { get; set; }
    }
}