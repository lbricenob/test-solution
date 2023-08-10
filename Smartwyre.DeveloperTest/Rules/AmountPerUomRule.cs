using Smartwyre.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartwyre.DeveloperTest.Rules
{
    public class AmountPerUomRule : IRebateRule
    {
        public bool CheckRebateResult(Rebate rebate, Product product, decimal volume, out decimal rebateAmount)
        {
            bool success = true;
            rebateAmount = 0M;
            if (rebate == null)
            {
                success = false;
            }
            else if (product == null)
            {
                success = false;
            }
            else if (!product.SupportedIncentives.HasFlag(SupportedIncentiveType.AmountPerUom))
            {
                success = false;
            }
            else if (rebate.Amount == 0 || volume == 0)
            {
                success = false;
            }
            else
            {
                rebateAmount += rebate.Amount * volume;
                success = true;
            }
            return success;
        }
    }
}
