using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AnimalShelter
{

    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
        }

        private void OnAddProfileClicked(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {

            nameEntry.Text = string.Empty;
            surnameEntry.Text = string.Empty;
            patronymicEntry.Text = string.Empty;
            birthDatePicker.Date = DateTime.Now; // Устанавливаем текущую дату по умолчанию
            ExpEntry.Text = string.Empty;
            PhoneNumEntry.Text = string.Empty;
            EmailEntry.Text = string.Empty;
            Pethabits.Text = string.Empty;
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            // Логика сохранения данных профиля
            await DisplayAlert("Сохранение", "Данные профиля сохранены", "ОК");
        }
    }
}