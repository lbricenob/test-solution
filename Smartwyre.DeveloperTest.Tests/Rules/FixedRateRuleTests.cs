using Smartwyre.DeveloperTest.Rules;
using Smartwyre.DeveloperTest.Types;
using Xunit;

namespace Smartwyre.DeveloperTest.Tests.Rules
{
    public class FixedRateRuleTests
    {
        private readonly FixedRateRule fixedRateRule;
        private decimal invalidVolume = 0m;
        private decimal validVolume = 10m;
        private Rebate nullRebate = null;
        private Product nullProduct = null;
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
            Amount = 100,
            Percentage = 100
        };
        private Product validProduct = new()
        {
            SupportedIncentives = SupportedIncentiveType.FixedRateRebate,
            Price = 100,
        };

        public FixedRateRuleTests()
        {
            fixedRateRule = new FixedRateRule();
        }

        [Fact]
        public void CheckRebateResult_IsNot_Success_If_RebateIsNull()
        {
            decimal rebateAmount;
            bool result = fixedRateRule.CheckRebateResult(nullRebate, validProduct, validVolume, out rebateAmount);
            Assert.False(result);
        }

        [Fact]
        public void CheckRebateResult_IsNot_Success_If_ProductIsNull()
        {
            decimal rebateAmount;
            bool result = fixedRateRule.CheckRebateResult(validRebate, nullProduct, validVolume, out rebateAmount);
            Assert.False(result);
        }

        [Fact]
        public void CheckRebateResult_IsNot_Success_If_ProductIncentive_IsNot_FixedCash()
        {
            decimal rebateAmount;
            bool result = fixedRateRule.CheckRebateResult(validRebate, invalidIncentiveProduct, validVolume, out rebateAmount);
            Assert.False(result);
        }

        [Fact]
        public void CheckRebateResult_IsNot_Success_If_AmountIsZero()
        {
            decimal rebateAmount;
            bool result = fixedRateRule.CheckRebateResult(zeroAmountRebate, validProduct, validVolume, out rebateAmount);
            Assert.False(result);
        }

        [Fact]
        public void CheckRebateResult_IsNot_Success_If_VolumeIsZero()
        {
            decimal rebateAmount;
            bool result = fixedRateRule.CheckRebateResult(validRebate, validProduct, invalidVolume, out rebateAmount);
            Assert.False(result);
        }

        [Fact]
        public void CheckRebateResult_Is_Success_IfRebate_NotNull_And_Product_IsValid()
        {
            decimal rebateAmount;
            bool result = fixedRateRule.CheckRebateResult(validRebate, validProduct, validVolume, out rebateAmount);
            Assert.True(result);
        }
    }
}
