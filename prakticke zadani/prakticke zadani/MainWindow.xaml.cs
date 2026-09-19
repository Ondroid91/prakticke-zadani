using Microsoft.Win32;
using prakticke_zadani.Interfaces;
using prakticke_zadani.Models;
using prakticke_zadani.Services;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;

namespace prakticke_zadani
{
    public partial class MainWindow : Window
    {
        private readonly ICarService _CarService;
        List<Car> cars = new List<Car>();
        List<CarSummary> summary = new List<CarSummary>();


        public MainWindow()
        {
            InitializeComponent();
            _CarService = new CarService();
        }

        private void Unload_btn_Click(object sender, RoutedEventArgs e)
        {
            cars.Clear();
            summary.Clear();
            RefreshDataGrids();
        }

        private void Load_btn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "XML Files | *.xml";

            bool? success = ofd.ShowDialog();

            if (success == true)
            {
                XDocument document =  XDocument.Load(ofd.FileName);
                cars = _CarService.GetCarsFromXml(document);
                summary = _CarService.GetCarSummary(cars);
                CarTable.ItemsSource = cars;
                CarSumTable.ItemsSource = summary;
            }
        }

        private void Export_btn_Click(object sender, RoutedEventArgs e)
        {
            XDocument document = _CarService.CreateXmlFromCars(cars);
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "XML Files | *.xml";
            sfd.DefaultExt = ".xml";

            bool? success = sfd.ShowDialog();

            if (success == true)
            {
                document.Save(sfd.FileName);
            }
        }

        private void AddCar_btn_Click(object sender, RoutedEventArgs e)
        {
            View.CarWindow window = new View.CarWindow(cars, this);
            window.ShowDialog();
        }

        private void DeleteCar_btn_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Car car = (Car)button.DataContext;

            cars.Remove(car);
            RefreshDataGrids();
        }

        public void RefreshDataGrids()
        {
            CarTable.ItemsSource = null;
            CarTable.ItemsSource = cars;
            summary = _CarService.GetCarSummary(cars);
            CarSumTable.ItemsSource = null;
            CarSumTable.ItemsSource = summary;
        }

    }
}