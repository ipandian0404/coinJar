using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace CoinJar.api.CoinData
{
    public class CoinDataDetails
    {
        public DataTable dtCoins = new DataTable();
        DataColumn column = new DataColumn();
        public CoinDataDetails()
        {
           
            column.DataType = System.Type.GetType("System.Int32");
            column.AutoIncrement = true;
            column.AutoIncrementSeed = 1;
            column.AutoIncrementStep = 1;
            column.ColumnName = "Id";
            dtCoins.Columns.Add(column);
            dtCoins.Columns.Add("Amount");
            dtCoins.Columns.Add("Volume");
        }
        public int AddCoinDataDetails(DataRow row)
        {
            try
            {
                dtCoins.Rows.Add(row);
                dtCoins.AcceptChanges();
                DataRow newRow= dtCoins.Select("MAX(Id)")[0];
                return (int)newRow["Id"];


            }
            catch (Exception)
            {
                return 0;
            }
           
        }

        public DataRowCollection GetCoinDataDetails( )
        {
            try
            {
                
                return dtCoins.Rows;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public bool ResetCoinDataDetails()
        {
            try
            {
                    foreach (DataRow row in dtCoins.Rows)
                    {

                        row["Amount"] = 0; ;

                    }
                return false;
                
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
