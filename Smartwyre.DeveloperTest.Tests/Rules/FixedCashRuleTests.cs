using Smartwyre.DeveloperTest.Rules;
using Smartwyre.DeveloperTest.Types;
using Xunit;

namespace Smartwyre.DeveloperTest.Tests.Rules
{
    public class FixedCashRuleTests
    {
        private readonly FixedCashRule fixedCashRule;
        private decimal volume = 0m;
        private Rebate nullRebate = null;
        private Rebate zeroAmountRebate = new()
        {
            Amount = 0
        };
        private Product invalidIncentiveProduct = new()
        {
            SupportedIncentives = SupportedIncentiveType.AmountPerUom
        };
        private Rebate validRebate = new()
        {
            Amount = 100
        };
        private Product validProduct = new()
        {
            SupportedIncentives = SupportedIncentiveType.FixedCashAmount
        };

        public FixedCashRuleTests()
        {
            fixedCashRule = new FixedCashRule();
        }

        [Fact]
        public void CheckRebateResult_IsNot_Success_If_RebateIsNull()
        {
            decimal rebateAmount;
            bool result = fixedCashRule.CheckRebateResult(nullRebate, validProduct, volume, out rebateAmount);
            Assert.False(result);
        }

        [Fact]
        public void CheckRebateResult_IsNot_Success_If_ProductIncentive_IsNot_FixedCash()
        {
            decimal rebateAmount;
            bool result = fixedCashRule.CheckRebateResult(validRebate, invalidIncentiveProduct, volume, out rebateAmount);
            Assert.False(result);
        }

        [Fact]
        public void CheckRebateResult_IsNot_Success_If_AmountIsZero()
        {
            decimal rebateAmount;
            bool result = fixedCashRule.CheckRebateResult(zeroAmountRebate, validProduct, volume, out rebateAmount);
            Assert.False(result);
        }

        [Fact]
        public void CheckRebateResult_Is_Success_IfRebate_NotNull_And_Product_IsValid()
        {
            decimal rebateAmount;
            bool result = fixedCashRule.CheckRebateResult(validRebate, validProduct, volume, out rebateAmount);
            Assert.True(result);
        }
    }
}
