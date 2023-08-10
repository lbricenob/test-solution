using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Rules;
public interface IRebateRule
{
    bool CheckRebateResult(Rebate rebate, Product product, decimal volume, out decimal rebateAmount);
}
