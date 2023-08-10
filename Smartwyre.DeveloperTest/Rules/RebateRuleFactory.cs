using Smartwyre.DeveloperTest.Types;
using System;

namespace Smartwyre.DeveloperTest.Rules;
public class RebateRuleFactory : IRebateRuleFactory
{
    public IRebateRule CreateRule(Rebate rebate)
    {
        IRebateRule rule = null;
        switch (rebate.Incentive)
        {
            case IncentiveType.FixedCashAmount:
                rule = new FixedCashRule();
                break;

            case IncentiveType.FixedRateRebate:
                rule = new FixedRateRule();
                break;

            case IncentiveType.AmountPerUom:
                rule = new AmountPerUomRule();
                break;
        }
        return rule;
    }
}
