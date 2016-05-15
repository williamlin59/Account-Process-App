using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Threading;
using System.ComponentModel;
/* Database class is responsible for connecting to online or local database and insert transaction value 
 * to correspond columns in sql db. A backgroundworker object is used to track the progress for progress bar.
 * 
 */ 
namespace Account_Info_Upload_Application
{
    public class Database
    {
        private const String CONNECTING_STRING = "Data Source=(localdb)\\v11.0;Integrated Security=true";
        private const String INSERT_QUERY = "INSERT INTO KPMG.Data (Account, Description, Currency,Value) VALUES (@ListAccount, @ListDescription, @ListCurrency, @ListValue)";
        private static SqlConnection connection;
        public static bool connect()
        {
            connection = new SqlConnection(CONNECTING_STRING);
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public static bool insert(List<Transaction> transactions, BackgroundWorker backgroundWorker1)
        {
            SqlCommand command = new SqlCommand(INSERT_QUERY);
            command.CommandType = CommandType.Text;
            command.Connection = connection;
            command.Parameters.AddWithValue("@ListAccount", SqlDbType.VarChar);
            command.Parameters.AddWithValue("@ListDescription", SqlDbType.VarChar);
            command.Parameters.AddWithValue("@ListCurrency", SqlDbType.VarChar);
            command.Parameters.AddWithValue("@ListValue", SqlDbType.Decimal);
            for (int i = 0; i < transactions.Count;i++ )
            {
                try
                {
                    command.Parameters["@ListAccount"].Value = transactions[i].getAccount();
                    command.Parameters["@ListDescription"].Value = transactions[i].getDescription();
                    command.Parameters["@ListCurrency"].Value = transactions[i].getCurrency();
                    command.Parameters["@ListValue"].Value = transactions[i].getValue();
                    command.ExecuteNonQuery();
                    backgroundWorker1.ReportProgress(i);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                    connection.Close();
                    return false;
                }
            }
            connection.Close();
            return true;
        }
    }
}
