using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AnimalShelter
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ServicesPage : ContentPage
    {
        public ServicesPage()
        {
            InitializeComponent();
            LoadServices();
        }
        private void LoadServices()
        {
            var services = new List<Service>
            {
                new Service { Name = "Номер «Общий» 499 ₽/день", ImageSource = "https://fd8f3b0d-a4a5-424f-9d57-1156ad7104f7.selcdn.net/uploads/images/140573/large_40.jpg" },
                new Service { Name = "Номер «Эконом» 799 ₽/день", ImageSource = "https://rondelux.ru/wp-content/uploads/2020/02/08_2_1x1.jpg" },
                new Service { Name = "Номер «Свежий Воздух» 1.499 ₽/день", ImageSource = "https://kirov.svarkaperm.ru/wp-content/gallery/volieri/volieri1.jpg" },
                new Service { Name = "Номер «Люкс» 2.999 ₽/день", ImageSource = "https://images.stroistyle.com/posts/1274911-igrovaia-komnata-dlia-koshek-36.jpg" },
                new Service { Name = "Номер «Президентский Люкс» 9.999 ₽/день", ImageSource = "https://modeneseinteriors.com/uploads/2020/09/1-artisanal-custom-made-comfort-ivory-pearl-pet-furniture-silver-leaf-details-royal-villa-home-furnishings-scaled.jpg" }
            };

            servicesCarousel.ItemsSource = services;
        }

        private async void OnBookServiceClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Service selectedService = (Service)button.BindingContext;

            // Создаем элементы для выбора даты и времени
            var datePicker = new DatePicker
            {
                Date = DateTime.Now,
                Format = "D"
            };

            var timePicker = new TimePicker
            {
                Time = new TimeSpan(9, 0, 0)
            };

            var petPicker = new Picker
            {
                Title = "Выберите питомца"
            };
            petPicker.Items.Add("Собака");
            petPicker.Items.Add("Кошка");
            petPicker.Items.Add("Попугай");
            petPicker.Items.Add("Кролик");
            petPicker.Items.Add("Другой");

            // Создаем StackLayout для размещения элементов
            var stackLayout = new StackLayout
            {
                Children = {
                    new Label { Text = "Выберите питомца:", FontSize = 18 },
                    petPicker,
                    new Label { Text = "Выберите дату заселения:", FontSize = 18 },
                    datePicker,
                    new Label { Text = "Выберите время заселения:", FontSize = 18 },
                    timePicker,
                    new Button { Text = "Подтвердить", Command = new Command(async () => await ConfirmAppointment(selectedService, datePicker, timePicker)) },
                    new Button { Text = "Отмена", Command = new Command(async () => await Application.Current.MainPage.Navigation.PopModalAsync()) }
                }
            };

            // Создаем всплывающее окно
            var popup = new ContentPage
            {
                Title = "Запись на услугу",
                Content = stackLayout,
                Padding = new Thickness(20)
            };

            await Application.Current.MainPage.Navigation.PushModalAsync(popup);
        }

        private async System.Threading.Tasks.Task ConfirmAppointment(Service selectedService, DatePicker datePicker, TimePicker timePicker)
        {
            var selectedDate = datePicker.Date;
            var selectedTime = timePicker.Time;

            // Логика для записи на услугу с выбранной датой и временем
            AppointmentsPage.Appointments.Add(new Appointment
            {
                Time = selectedTime.ToString(@"hh\:mm"),
                Date = selectedDate.ToString("dd.MM.yyyy"),
                ServiceName = selectedService.Name,
            });

            await DisplayAlert("Запись", $"Вы успешно записаны на услугу: {selectedService.Name} на {selectedDate.ToShortDateString()} в {selectedTime.Hours}:{selectedTime.Minutes}", "ОК");
            await Application.Current.MainPage.Navigation.PopModalAsync();
        }
    }

    public class Service
    {
        public string Name { get; set; }
        public string ImageSource { get; set; }
    }
}