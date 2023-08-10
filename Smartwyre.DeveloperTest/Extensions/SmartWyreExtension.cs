using Microsoft.Extensions.DependencyInjection;
using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Rules;
using Smartwyre.DeveloperTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartwyre.DeveloperTest.Extensions
{
    public static class SmartWyreExtension
    {
        public static void AddRebateServices(this IServiceCollection services)
        {
            services.AddScoped<IRebateService, RebateService>();
            services.AddScoped<IRebateRuleFactory, RebateRuleFactory>();
            services.AddScoped<IProductDataStore, ProductDataStore>();
            services.AddScoped<IRebateDataStore, RebateDataStore>();
        }
    }
}
