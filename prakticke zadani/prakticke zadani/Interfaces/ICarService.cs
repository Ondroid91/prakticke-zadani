using prakticke_zadani.Models;
using System.Xml.Linq;

namespace prakticke_zadani.Interfaces
{
    public interface ICarService
    {
        List<Car> GetCarsFromXml(XDocument document);
        XDocument CreateXmlFromCars(List<Car> Cars);

        List<CarSummary> GetCarSummary(List<Car> cars);
        void AddCar(List<Car> cars, Car car);
    }
}
