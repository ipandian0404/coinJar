 using System;
using System.Collections.Generic;
 
namespace Kye.CoinJar.Api.Models
{
    public class CoinDetails:ICoinDetails
    {   
        public  int ID { get; set; }
        public decimal Amount { get; set; }
        public decimal Volume { get; set; }
    }
}
