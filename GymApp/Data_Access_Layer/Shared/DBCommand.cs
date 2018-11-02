using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Data_Access_Layer.Shared;

namespace Data_Access_Layer.Shared
{
    public class DBCommand
    {
        private readonly IDbCommand _cmd;

        private readonly TransactionContext _suppliedTranscationContext;

        public DBCommand(string commandString)
        {
            this._cmd = DBComponentsFactory.ComponentProvider.CreateCommand();
            this._cmd.CommandText = commandString;
        }

        public DBCommand(string commandString, TransactionContext transactionContext) : this(commandString)
        {
            this._suppliedTranscationContext = transactionContext;
        }

        public void AddQueryParamters(string[,] paramKeyValPairs)
        {
            for (int row = 0; row < paramKeyValPairs.GetLength(0); row++)
            {
                IDataParameter param = DBComponentsFactory.ComponentProvider.CreateParameter();
                param.ParameterName = paramKeyValPairs[row, 0];
                param.Value = paramKeyValPairs[row, 1];
                _cmd.Parameters.Add(param);
            }
        }

        public int ExecuteNoneQuery()
        {
            var context = this.ResolveContext();

            var rowsAffectedCount = this._cmd.ExecuteNonQuery();

            if (this._suppliedTranscationContext == null)
                context.Commit();

            return rowsAffectedCount;
        }

        public void ExecuteReaderWithRowAction(Action<IDataReader> rowReadAction)
        {
            IDataReader rdr = null;

            var context = this.ResolveContext();

            try
            {
                rdr = _cmd.ExecuteReader();

                while (rdr.Read())
                {
                    rowReadAction(rdr);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                rdr?.Close();

                if (this._suppliedTranscationContext == null)
                    context.Commit();
            }
        }

        private TransactionContext ResolveContext()
        {
            var context = this._suppliedTranscationContext ?? TransactionContext.New();
            this._cmd.Connection = context.Connection;
            this._cmd.Transaction = context.Transaction;

            return context;
        }
    }
}
