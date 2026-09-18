using prakticke_zadani.Interfaces;
using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Xml.Linq;

namespace prakticke_zadani.Services
{
    public class CarService : ICarService
    {
        public List<Car> GetCarFromXml(XDocument document)
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

        public void AddCar(List<Car> cars, Car car)
        {
            cars.Add(car);
        }

        public void DeleteCar(List<Car> cars, int index)
        {
            cars.RemoveAt(index);
        }

        public void EditCar(List<Car> cars, int index, Car car)
        {
            cars[index] = car;
        }
    }
}
