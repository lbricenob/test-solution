using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Rules;

public class FixedCashRule : IRebateRule
{
    public bool CheckRebateResult(Rebate rebate, Product product, decimal volume, out decimal rebateAmount)
    {
        rebateAmount = 0m;
        bool success = true;
        if (rebate == null)
        {
            success = false;
        }
        else if (!product.SupportedIncentives.HasFlag(SupportedIncentiveType.FixedCashAmount))
        {
            success = false;
        }
        else if (rebate.Amount == 0)
        {
            success = false;
        }
        else
        {
            rebateAmount = rebate.Amount;
        }

        return success;
    }
}
