using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public static class CreditCardHelper
{
    public static string GetCreditCardType(this string cardNumber)
    {
        return  new CreditCard().GetCreditCardType(cardNumber);
    }
}

public class CreditCard
{
    private string AmericanExpressPattern => @"^3[47][0-9]{13}$";
    private string MasterCardPattern => @"^5[1-5][0-9]{14}$";
    private string VisaCardPattern => @"^4[0-9]{12}(?:[0-9]{3})?$";
    private string DinersClubCardPattern => @"^3(?:0[0-5]|[68][0-9])[0-9]{11}$";
    private string EnRouteCardPattern => @"^(2014|2149)";
    private string DiscoverCardPattern => @"^6(?:011|5[0-9]{2})[0-9]{12}$";
    private string JcbCardPattern => @"^(?:2131|1800|35\d{3})\d{11}$";


    private Dictionary<string, string> CreditRegxs { get; set; }

    public CreditCard()
    {
        CreditRegxs = new Dictionary<string, string>()
        {
            {"American Express",AmericanExpressPattern},
            {"Mastercard",MasterCardPattern},
            {"Visa",VisaCardPattern},
            {"Diners Club",DinersClubCardPattern},
            {"En Route",EnRouteCardPattern},
            {"Discover",DiscoverCardPattern},
            {"JCB ",JcbCardPattern},
        };
    }

    public string GetCreditCardType(string cardNumber)
    {
        string cardType = "Unknown";
        try
        {
            string cardNum = cardNumber.Replace(" ", "").Replace("-", "");
            foreach (string cardTypeName in CreditRegxs.Keys)
            {
                Regex regex = new Regex(CreditRegxs[cardTypeName]);
                if (regex.IsMatch(cardNum))
                {
                    cardType = cardTypeName;
                    break;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        return cardType;
    }

}