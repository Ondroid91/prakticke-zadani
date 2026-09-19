using prakticke_zadani.Interfaces;
using prakticke_zadani.Services;
using System.Windows;

namespace prakticke_zadani.View
{
    public partial class CarWindow : Window
    {
        private readonly ICarService _CarService;
        private List<Car> _cars;
        private MainWindow _mainWindow;

        public CarWindow(List<Car> cars, MainWindow mainWindow)
        {
            InitializeComponent();
            _CarService = new CarService();
            _cars = cars;
            _mainWindow = mainWindow;
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


            if (!double.TryParse(priceText.Text, out double price) && !string.IsNullOrWhiteSpace(priceText.Text))
            {
                msg += "Cena musí být číslo.\n";
            }
            else
            {
                newCar.Price = price;
                if (price < 0)
                {
                    msg += "Cena musí být kladná hodnota.\n";
                }

            }

            if (!double.TryParse(dphText.Text, out double dph) && !string.IsNullOrWhiteSpace(dphText.Text))
            {
                msg += "DPH musí být číslo.\n";
            }
            else
            {
                newCar.Dph = dph;
                if (dph < 0)
                {
                    msg += "Dph musí být kladná hodnota.\n";
                }
            }

            if (msg != "")
            {
                SendMessage(msg);
                return;
            }

            _CarService.AddCar(_cars, newCar);
            _mainWindow.RefreshDataGrids();
            Close();
        }

        private void SendMessage(string message)
        {
            View.warningMsg window = new View.warningMsg(message);
            window.ShowDialog();
        }

        private void Cancel_btn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
