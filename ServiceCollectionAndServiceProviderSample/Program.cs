using DependencyInjectionSampleLib;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ServiceCollectionAndServiceProviderSample
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<ICar, MockCar>();

            ServiceProvider provider = serviceCollection.BuildServiceProvider();

            ICar mockCar = provider.GetRequiredService<ICar>(); //Wird im Hintergrund aufgerufen, wenn eine Instanz der jeweiligen Controller-Klasse erstellt wird (via Factory)
            Console.ReadKey();

            //https://autofac.readthedocs.io/en/latest/integration/aspnetcore.html
            //Alternative Libraries -> AutoFac / Ninject / StructureMap -> bieten weitere alternativen zu ServiceProvider + andere Lebenszeiten bei Objecten an. 
        }
    }
}
