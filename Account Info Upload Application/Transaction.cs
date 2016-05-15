using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* Factory class to hold all information for transaction
 * getter, setter and toString
 * 
 */
namespace Account_Info_Upload_Application
{
    public class Transaction
    {
        private String _account;
        private String _description;
        private String _currency;
        private double _value;
        public Transaction(String account, String description, String currency, double value)
        {
            _account = account;
            _description = description;
            _currency = currency;
            _value = value;
        }
        public String getAccount()
        {
            return _account;
        }
        public String getDescription()
        {
            return _description;
        }
        public String getCurrency()
        {
            return _currency;
        }
        public double getValue()
        {
            return _value;
        }
        public override string ToString()
        {
            return _account + ": " + _description + ": " + _currency + ": " + _value;
        }
    }
}
