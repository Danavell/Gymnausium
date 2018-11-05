﻿using Data_Access_Layer.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Data_Access_Layer.shared
{
    public class DBCommand
    {
        private readonly IDbCommand _cmd;

        private readonly TransactionContext _suppliedTransactionContext;

        public DBCommand(string commandString)
        {
            this._cmd = DBComponentsFactory.ComponentProvider.CreateCommand();
            this._cmd.CommandText = commandString;
        }

        public DBCommand(string commandString, TransactionContext transactionContext) : this(commandString)
        {
            this._suppliedTransactionContext = transactionContext;
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
        public void AddQueryParamters(string key, int value)
        {
            IDataParameter param = DBComponentsFactory.ComponentProvider.CreateParameter();
            param.ParameterName = key;
            param.Value = value;
            _cmd.Parameters.Add(param);
        }

        public void AddQueryParamters(string key, string value)
        {
            IDataParameter param = DBComponentsFactory.ComponentProvider.CreateParameter();
            param.ParameterName = key;
            param.Value = value;
            _cmd.Parameters.Add(param);
        }
        public void AddQueryParamters(string key, Guid value)
        {
            IDataParameter param = DBComponentsFactory.ComponentProvider.CreateParameter();
            param.ParameterName = key;
            param.Value = value;
            _cmd.Parameters.Add(param);
        }

        public bool ExecuteBoolQuery()
        {
            var context = this.ResolveContext();
            try
            {
                var rowsAffectedCount = this._cmd.ExecuteNonQuery();

                if (this._suppliedTransactionContext == null)
                    context.Commit();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public int ExecuteScalar()
        {
            return 0;
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

                if (this._suppliedTransactionContext == null)
                    context.Commit();
            }
        }

        private TransactionContext ResolveContext()
        {
            var context = this._suppliedTransactionContext ?? TransactionContext.New();
            this._cmd.Connection = context.Connection;
            this._cmd.Transaction = context.Transaction;

            return context;
        }
    }
}
