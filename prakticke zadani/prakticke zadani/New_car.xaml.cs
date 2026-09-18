using prakticke_zadani.Interfaces;
using prakticke_zadani.Services;
using System.Windows;


namespace prakticke_zadani
{

    public partial class New_car : Window
    {
        private readonly ICarService _CarService;

        public New_car()
        {
            InitializeComponent();
            _CarService = new CarService();
        }

        private void Create_btn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
