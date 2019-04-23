using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardTypeConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var card = "4111 1111 1111 1111";
            Console.WriteLine(card.GetCreditCardType());

        }
        
    }
}
