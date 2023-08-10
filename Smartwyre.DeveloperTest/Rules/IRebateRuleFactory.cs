using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Rules;
public interface IRebateRuleFactory
{
    IRebateRule CreateRule(Rebate rebate);
}
