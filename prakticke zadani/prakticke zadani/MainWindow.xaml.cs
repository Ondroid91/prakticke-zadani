using Microsoft.Win32;
using prakticke_zadani.Interfaces;
using prakticke_zadani.Services;
using System.Windows;
using System.Xml.Linq;

namespace prakticke_zadani
{
    public partial class MainWindow : Window
    {
        private readonly ICarService _CarService;
        List<Car> cars = new List<Car>();


        public MainWindow()
        {
            InitializeComponent();
            _CarService = new CarService();
        }

        private void Load_btn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "XML Files | *.xml";

            bool? success = ofd.ShowDialog();

            if (success == true)
            {
                filepath.Text = ofd.FileName;
                XDocument document =  XDocument.Load(ofd.FileName);
                cars = _CarService.GetCarFromXml(document);

                autobox.Text = cars.Count().ToString();
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
            View.New_car window = new View.New_car(cars);
            window.ShowDialog();
        }
    }
}