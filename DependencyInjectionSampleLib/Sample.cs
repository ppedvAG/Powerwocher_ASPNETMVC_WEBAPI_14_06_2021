using System;

namespace DependencyInjectionSampleLib
{
    #region BadCode

    public class BadCar //Programmierer A benötigt 5 Tage
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime ConstructionYear { get; set; }
    }

    public class BadCarService //Programmierer B benötigt 3 Tage -> Insgesamt ist er 
    {
        public void Repair (BadCar car) 
        {
            //Mach etwas mit car
        }
    }
    #endregion

    #region Besser Variante Dependency Inversion / Dependency Injection

    public interface ICar
    {
        string Brand { get; set; }
        string Model { get; set; }
        DateTime ConstructionYear { get; set; }
    }

    public interface ICarService
    {
        void Repair(ICar car);
    }

    public class Car : ICar //Programmierer A: 5 Tage
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime ConstructionYear { get; set; }
    }

    public class CarService : ICarService //Programmierer B: 3 Tage
    {
        public void Repair(ICar car)
        {
            //Machwas
        }
    }

    public class MockCar : ICar
    {
        public string Brand { get; set; } = "VW";
        public string Model { get; set; } = "Polo";
        public DateTime ConstructionYear { get; set; } = DateTime.Now;
    }


    public class Programm
    {
        public void SampleMainMethode ()
        {
            ICarService carService = new CarService();

            carService.Repair(new MockCar()); //Zum Testen
            carService.Repair(new Car());
        }
    }


    #endregion
}
