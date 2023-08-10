using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Rules;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Services;

public class RebateService : IRebateService
{
    public IRebateRuleFactory rebateRuleFactory;
    public IRebateDataStore rebateDataStore;
    public IProductDataStore productDataStore;

    public RebateService(IRebateRuleFactory _rebateRuleFactory, IRebateDataStore _rebateDataStore, IProductDataStore _productDataStore)
    {
        rebateRuleFactory = _rebateRuleFactory;
        rebateDataStore = _rebateDataStore;
        productDataStore = _productDataStore;
    }
    public CalculateRebateResult Calculate(CalculateRebateRequest request)
    {
        Rebate rebate = rebateDataStore.GetRebate(request.RebateIdentifier);
        Product product = productDataStore.GetProduct(request.ProductIdentifier);

        var result = new CalculateRebateResult();

        decimal rebateAmount;
        IRebateRule rebateRule = rebateRuleFactory.CreateRule(rebate);

        result.Success = rebateRule.CheckRebateResult(rebate, product, request.Volume, out rebateAmount);

        if (result.Success)
        {
            rebateDataStore.StoreCalculationResult(rebate, rebateAmount);
        }

        return result;
    }
}
