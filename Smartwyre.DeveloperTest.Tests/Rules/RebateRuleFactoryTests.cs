using Smartwyre.DeveloperTest.Rules;
using Smartwyre.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Smartwyre.DeveloperTest.Tests.Rules
{
    public class RebateRuleFactoryTests
    {
        private readonly RebateRuleFactory factory;

        public RebateRuleFactoryTests()
        {
            factory = new RebateRuleFactory();
        }

        [Fact]
        public void RuleFactory_ShouldInstantiate_FixedCashRule_ForCorresponding_IncentiveType()
        {
            Rebate rebate = new()
            {
                Incentive = IncentiveType.FixedCashAmount
            };

            IRebateRule rebateRule = factory.CreateRule(rebate);
            Assert.IsType<FixedCashRule>(rebateRule);
        }

        [Fact]
        public void RuleFactory_ShouldInstantiate_FixedRateRule_ForCorresponding_IncentiveType()
        {
            Rebate rebate = new()
            {
                Incentive = IncentiveType.FixedRateRebate
            };

            IRebateRule rebateRule = factory.CreateRule(rebate);
            Assert.IsType<FixedRateRule>(rebateRule);
        }

        [Fact]
        public void RuleFactory_ShouldInstantiate_AmountPerUomRule_ForCorresponding_IncentiveType()
        {
            Rebate rebate = new()
            {
                Incentive = IncentiveType.AmountPerUom
            };

            IRebateRule rebateRule = factory.CreateRule(rebate);
            Assert.IsType<AmountPerUomRule>(rebateRule);
        }
    }
}
