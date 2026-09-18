using prakticke_zadani.Interfaces;
using prakticke_zadani.Services;
using prakticke_zadani.View;
using System.Runtime.Intrinsics.Arm;
using System.Windows;

namespace prakticke_zadani.View
{
    public partial class New_car : Window
    {
        private readonly ICarService _CarService;
        private List<Car> _cars;

        public New_car(List<Car> cars)
        {
            InitializeComponent();
            _CarService = new CarService();
            _cars = cars;
        }

        private void Create_btn_Click(object sender, RoutedEventArgs e)
        {
            Car newCar = new Car();
            String msg = "";

            newCar.Model = modelText.Text;

            if (string.IsNullOrWhiteSpace(modelText.Text))
            {
                msg += "Napište název modelu auta.\n";
            }
            if (string.IsNullOrWhiteSpace(priceText.Text))
            {
                msg += "Napište cenu auta.\n";
            }
            if (string.IsNullOrWhiteSpace(dphText.Text))
            {
                msg += "Napište DPH auta.\n";
            }
            if (dateCalendar.SelectedDate == null)
            {
                msg += "Vyberte datum.\n";
            }
            else
            {
                newCar.Date = DateOnly.FromDateTime(dateCalendar.SelectedDate.Value);

            }

            if (msg != "")
            {
                SendMessage(msg);
                return;
            }

            if (!double.TryParse(priceText.Text, out double price))
            {
                msg += "Cena musí být číslo.\n";
            }
            else
            {
                newCar.Price = price;
            }

            if (!double.TryParse(priceText.Text, out double dph))
            {
                msg += "DPH musí být číslo.\n";
            }
            else
            {
                newCar.Dph = dph;
            }

            if (msg != "")
            {
                SendMessage(msg);
                return;
            }

            _CarService.AddCar(_cars, newCar);
            Close();

        }

        private void SendMessage(string message)
        {
            View.warning window = new View.warning(message);
            window.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
