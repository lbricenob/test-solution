using Smartwyre.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartwyre.DeveloperTest.Rules
{
    public class FixedRateRule : IRebateRule
    {
        public bool CheckRebateResult(Rebate rebate, Product product, decimal volume, out decimal rebateAmount)
        {
            bool success = true;
            rebateAmount = 0m;
            if (rebate == null)
            {
                success = false;
            }
            else if (product == null)
            {
                success = false;
            }
            else if (!product.SupportedIncentives.HasFlag(SupportedIncentiveType.FixedRateRebate))
            {
                success = false;
            }
            else if (rebate.Percentage == 0 || product.Price == 0 || volume == 0)
            {
                success = false;
            }
            else
            {
                rebateAmount += product.Price * rebate.Percentage * volume;
                success = true;
            }

            return success;
        }
    }
}
