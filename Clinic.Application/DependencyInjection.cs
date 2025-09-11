
using Microsoft.Extensions.DependencyInjection;

namespace Clinic.Application
{
    public class Car
    {
        // method
        public void Run()
        {
        }
    }
    public static class DependencyInjection
    {
        // extension method
        public static void AddApplication(this IServiceCollection services)
        {
           
        }

        // static method
        // => extension method
        public static int BocDau(this Car car, string hello)
        {
            car.Run();
            return 1;
        }

        static void Main()
        {
            Car car1 = new Car();
            DependencyInjection.BocDau(car1, "asjdkajskd");
            var x = car1.BocDau("asdkjaksjd");
        }
    }
}
