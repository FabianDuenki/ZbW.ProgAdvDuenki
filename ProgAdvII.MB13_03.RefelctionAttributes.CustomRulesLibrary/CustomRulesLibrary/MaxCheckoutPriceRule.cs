using OrderRules.Interface;
using OrderTaker.SharedObjects;

namespace CustomRulesLibrary
{
    public class MaxCheckoutPriceRule : IOrderRule
    {
        public string RuleName { get { return "Maximum Checkout Price Rule"; } }

        public OrderRuleResult CheckRule(Order order)
        {
            return 
                order.TotalPrice > 2000 ? 
                    new OrderRuleResult(false, "Über 2000? bisch gstört?") :
                    new OrderRuleResult(true, "isch okay, hesch no glück gha");
        }
    }
}
