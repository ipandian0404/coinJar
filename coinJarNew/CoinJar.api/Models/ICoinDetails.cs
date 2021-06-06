 using System;
using System.Collections.Generic;
 
namespace Kye.CoinJar.Api.Models
{
    public interface ICoinDetails
    {   
      public  decimal Amount { get; set; }
      public  decimal Volume { get; set; }

    }
}
