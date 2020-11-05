using DebitLibrary.API.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Dapper;
using System.Data;

using DebitLibrary.API.Models;
using Oracle.ManagedDataAccess.Client;
using DebitService.API.Models;

namespace DebitLibrary.API.Services
{
    public class DebitLibraryRepository : IDebitLibraryRepository, IDisposable
    {

        private readonly string connstring;
        private IDbConnection Connection => new OracleConnection(connstring);
        public DebitLibraryRepository()
        {

            //  connstring = "Server=192.168.0.164;Database=maecbsdb;user=SA;Password=TCSuser1123;Trusted_Connection=True;";
            connstring = "User Id=maeadmin;Password =Pa55w0rd;Data Source= 192.168.0.172:1521/orclpdb1";
        }

        public bool DebitAmount(Debit req)
        {
            using (var c = Connection)
            {
                c.Open();
                var p = new DynamicParameters();
                p.Add("accountNumber", req.AccountIdentifier, DbType.String, ParameterDirection.Input);
                p.Add("amount", req.TransferAmount, DbType.Double, ParameterDirection.Input);

                string query = "update tb_mae_mort_account set available_balance= available_balance - :amount, current_balance=current_balance - :amount where account_identifier= :accountNumber";
                //string query = "update tb_mae_mort_account set [available_balance]= [available_balance] - @amount,  [current_balance]=[current_balance] - @amount where account_identifier= @accountNumber";
                var x = c.Query(query,p);
                                
                c.Close();
                return true;
            }           
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose resources when needed
            }
        }
    }
}
