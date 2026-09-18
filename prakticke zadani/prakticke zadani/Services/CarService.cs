using prakticke_zadani.Interfaces;
using prakticke_zadani.Models;
using System.Windows.Controls;
using System.Xml.Linq;

namespace prakticke_zadani.Services
{
    public class CarService : ICarService
    {
        public List<Car> GetCarsFromXml(XDocument document)
        {
            List<Car> cars = new List<Car>();

            foreach (XElement car in document.Descendants("car"))
            {

                Car new_car = new Car();
                new_car.Model = car.Element("model").Value;
                new_car.Date = DateOnly.Parse(car.Element("date").Value);
                new_car.Price = double.Parse(car.Element("price").Value);
                new_car.Dph = double.Parse(car.Element("dph").Value);
                cars.Add(new_car);
            }

            return cars;
        }

        public XDocument CreateXmlFromCars(List<Car> Cars)
        {
            XElement carsElement = new XElement("cars");

            foreach (Car car in Cars)
            {
                XElement carElement = new XElement(
                    "car",
                    new XElement("model", car.Model),
                    new XElement("date", car.Date.ToString("yyyy-MM-dd")),
                    new XElement("price", car.Price),
                    new XElement("dph", car.Dph)
                );

                carsElement.Add(carElement);
            }

            XDocument document = new XDocument(carsElement);

            return document;
        }

        public List<CarSummary> GetCarSummary(List<Car> cars)
        {
            List<CarSummary> summary = new List<CarSummary>();


            var weekendCars = cars.Where(car =>
                car.Date.DayOfWeek == DayOfWeek.Saturday ||
                car.Date.DayOfWeek == DayOfWeek.Sunday);

            var modelCars = weekendCars.GroupBy(car => car.Model);

            foreach (var group in modelCars)
            {
                CarSummary carSummary = new CarSummary();

                carSummary.Model = group.Key;
                carSummary.PriceWithoutDph = group.Sum(car => car.Price);
                carSummary.PriceWithDph = group.Sum(car =>car.Price * (1 + car.Dph / 100));
                summary.Add(carSummary);
            }

            return summary;
        }

        public void AddCar(List<Car> cars, Car car)
        {
            cars.Add(car);
        }

        public void EditCar(List<Car> cars, int index, Car car)
        {
            cars[index] = car;
        }
    }
}
