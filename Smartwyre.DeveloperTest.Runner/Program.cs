using Microsoft.Extensions.DependencyInjection;
using Smartwyre.DeveloperTest.Extensions;
using Smartwyre.DeveloperTest.Services;
using Smartwyre.DeveloperTest.Types;
using System;

namespace Smartwyre.DeveloperTest.Runner;

class Program
{
    static IRebateService rebateService;
    static void Main(string[] args)
    {
        IServiceCollection services = new ServiceCollection();
        services.AddRebateServices();

        IServiceProvider serviceProvider = services.BuildServiceProvider();
        rebateService = serviceProvider.GetService<IRebateService>();

        CalculateRebate();
    }

    static void CalculateRebate()
    {
        Console.Clear();
        Console.WriteLine("Enter the rebate identifier:");
        string rebateIdentifier = Console.ReadLine();

        Console.WriteLine("Enter the product identifier:");
        string productIdentifier = Console.ReadLine();

        decimal volume;
        Console.WriteLine("Enter the volumne:");
        if (Decimal.TryParse(Console.ReadLine(), out volume))
        {

        }
        else
        {
            Console.WriteLine("Invalid volume. Press any key to start over.");
            Console.ReadLine();
            CalculateRebate();
        }

        CalculateRebateRequest request = new CalculateRebateRequest()
        {
            ProductIdentifier = productIdentifier,
            RebateIdentifier = rebateIdentifier,
            Volume = volume
        };
        CalculateRebateResult result = rebateService.Calculate(request);
        if (result.Success)
        {
            Console.WriteLine("The rebate was calculated.");
        }
        else
        {
            Console.WriteLine($"There was an error calculating the rebate. Press any key to start over.");
            Console.ReadLine();
            CalculateRebate();
        }
    }
}
