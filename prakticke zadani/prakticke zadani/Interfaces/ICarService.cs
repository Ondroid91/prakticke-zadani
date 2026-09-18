using prakticke_zadani.Models;
using System.Windows.Controls;
using System.Xml.Linq;

namespace prakticke_zadani.Interfaces
{
    public interface ICarService
    {
        List<Car> GetCarsFromXml(XDocument document);
        XDocument CreateXmlFromCars(List<Car> Cars);

        List<CarSummary> GetCarSummary(List<Car> cars);
        void AddCar(List<Car> cars, Car car);

        void EditCar(List<Car> cars, int index, Car car);

    }
}
