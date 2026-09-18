using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace prakticke_zadani.Interfaces
{
    public interface ICarService
    {
        List<Car> GetCarFromXml(XDocument document);
        XDocument CreateXmlFromCars(List<Car> Cars);
        void AddCar(List<Car> cars, Car car);
        void DeleteCar(List<Car> cars, int index);
        void EditCar(List<Car> cars, int index, Car car);

    }
}
