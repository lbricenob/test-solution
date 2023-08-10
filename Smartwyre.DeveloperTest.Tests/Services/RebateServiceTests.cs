using Moq;
using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Rules;
using Smartwyre.DeveloperTest.Services;
using Smartwyre.DeveloperTest.Types;
using Xunit;

namespace Smartwyre.DeveloperTest.Tests.Services
{
    
    public class RebateServiceTests
    {
        private readonly Mock<IRebateRuleFactory> rebateRuleFactory;
        private readonly Mock<IRebateDataStore> rebateDataStore;
        private readonly Mock<IProductDataStore> productDataStore;
        private readonly Mock<IRebateRule> rebateRule;
        private RebateService rebateService;

        public RebateServiceTests()
        {
            rebateRuleFactory = new Mock<IRebateRuleFactory>();
            productDataStore = new Mock<IProductDataStore>();
            rebateDataStore = new Mock<IRebateDataStore>();
            rebateRule = new Mock<IRebateRule>();
            rebateService = new RebateService(rebateRuleFactory.Object, rebateDataStore.Object, productDataStore.Object);
        }

        [Fact]
        public void CalculateShould_Call_ProductAndRebateDataStores()
        {
            CalculateRebateRequest request = new()
            {
                ProductIdentifier = "this_product_identifier",
                RebateIdentifier = "this_rebate_identifier",
                Volume = 1m
            };
            Rebate rebate = new();
            Product product = new();
            decimal rebateAmount;
            rebateDataStore.Setup(r => r.GetRebate(It.IsAny<string>())).Returns(rebate);
            productDataStore.Setup(p => p.GetProduct(It.IsAny<string>())).Returns(product);
            rebateDataStore.Setup(r => r.StoreCalculationResult(It.IsAny<Rebate>(), It.IsAny<decimal>()));
            rebateRule.Setup(r => r.CheckRebateResult(It.IsAny<Rebate>(), It.IsAny<Product>(), It.IsAny<decimal>(), out rebateAmount)).Returns(true);
            rebateRuleFactory.Setup(r => r.CreateRule(It.IsAny<Rebate>())).Returns(rebateRule.Object);

            rebateService.Calculate(request);
            rebateDataStore.Verify(r => r.GetRebate(It.IsAny<string>()));
            productDataStore.Verify(p => p.GetProduct(It.IsAny<string>()));
            rebateDataStore.Verify(r => r.StoreCalculationResult(It.IsAny<Rebate>(), It.IsAny<decimal>()));
        }
    }
}
