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
    public partial class SpecialistsPage : ContentPage
    {
        public SpecialistsPage()
        {
            InitializeComponent();
            LoadSpecialists();
        }

        private void LoadSpecialists()
        {
            var specialists = new List<Specialist>
            {
                new Specialist { Name = "Семенов, Алексей Дмитриевич", Position = "Грызуны", ImageSource = "https://img.joomcdn.net/fe9ef79ff4f7256c2c075a927c6b0c8e51924d96_original.jpeg" },
                new Specialist { Name = "Кузьмина, Наталья Сергеевна", Position = "Кошки", ImageSource = "https://i5.walmartimages.com/seo/Medical-Doctor-Barker-Dog-Costume-Dress-Your-Pup-Like-Your-Favorite-Physician-Size-3_d9d5343b-92e2-492b-a59f-c00030ebcda2.cc151b186475e65b6561438f43cc5536.jpeg" },
                new Specialist { Name = "Орлов, Игорь Николаевич", Position = "Кролики", ImageSource = "https://img.joomcdn.net/1e2f2a24ef4631e55056109429a7aaaaefb1ca69_original.jpeg" },
                new Specialist { Name = "Мельникова, Татьяна Викторовна", Position = "Кошки", ImageSource = "https://thumbs.dreamstime.com/b/%D0%B4%D0%BE%D0%BA%D1%82%D0%BE%D1%80-%D0%BA%D0%BE%D1%82%D0%B0-%D1%81-%D1%88%D0%BF%D1%80%D0%B8%D1%86%D0%B5%D0%BC-%D0%B8-clyster-121465361.jpg" },
                new Specialist { Name = "Поляков, Андрей Геннадьевич", Position = "Птицы", ImageSource = "https://mundogato.com.ec/wp-content/uploads/2017/08/MedicoGato2.jpg" },
                new Specialist { Name = "Полякова, Лидия Ивановна", Position = "Собаки", ImageSource = "https://ir.ozone.ru/s3/multimedia-1-b/c400/7945970591.jpg" },
                new Specialist { Name = "Герасимов, Валерий Васильевич", Position = "Собаки", ImageSource = "https://i.etsystatic.com/26181376/r/il/3b4b40/3405392004/il_570xN.3405392004_t23n.jpg" },
            };

            specialistsListView.ItemsSource = specialists;
        }
    }

    public class Specialist
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public string ImageSource { get; set; }
    }
}