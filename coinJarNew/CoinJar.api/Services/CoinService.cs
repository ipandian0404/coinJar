using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Kye.CoinJar.Api.Models;
using CoinJar.api.CoinData;


namespace CoinJar.api.Services
{

    public class CoinService : ICoinService
    {
        private readonly ILogger logger;
        public int AddCoins(CoinDetails coinDetails)
        {
            try
            {
                 
                CoinDataDetails coinData = new CoinDataDetails();
                DataRow row = coinData.dtCoins.NewRow();
                row["Amount"] = coinDetails.Amount;
                row["Volume"] = coinDetails.Volume;
                coinDetails.ID = coinData.AddCoinDataDetails(row);
                logger.LogDebug("Added coin successfully");
                return coinDetails.ID;
            }
            catch (System.Exception ex)
            {
                logger.LogDebug("Error adding coin,Error:-", ex.Message);
                return 0;
            }

        }

        public decimal GetTotalCoins( )
        {
            try
            {
                CoinDataDetails coinData = new CoinDataDetails();
                DataRowCollection coinRows =  coinData.GetCoinDataDetails();
                decimal totalCoins = 0;
                if (coinRows != null)
                {
                    foreach (DataRow row in coinRows)
                    {

                        totalCoins += (decimal)row["Amount"];

                    }
                }

                logger.LogDebug("totalCoins returned successfully");
                return totalCoins;

            }
            catch (System.Exception ex)
            {
                logger.LogDebug("Error geting totalCoins ,Error:-", ex.Message);
                return 0;
            }

        }


        public bool ResetCoins()
        {
            CoinDataDetails coinData = new CoinDataDetails();
            return coinData.ResetCoinDataDetails();

        }
    }


    public interface ICoinService
    {
        int AddCoins(CoinDetails coinDetails);
        decimal GetTotalCoins();
        bool ResetCoins();

    }
}
