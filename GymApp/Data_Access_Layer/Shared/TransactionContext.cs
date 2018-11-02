using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Access_Layer.Shared
{
    public class TransactionContext
    {
        private TransactionContext(IsolationLevel isolationLevel)
        {
            this.Connection = DBComponentsFactory.Connection;
            this.Connection.Open();
            this.Transaction = this.Connection.BeginTransaction(isolationLevel);
        }

        public IDbConnection Connection { get; private set; }
        public IDbTransaction Transaction { get; private set; }

        public static TransactionContext New(IsolationLevel isolationLevel = IsolationLevel.Serializable)
        {
            return new TransactionContext(isolationLevel);
        }

        public void Commit()
        {
            this.Transaction.Commit();
            this.Connection.Close();
        }

        public void Rollback()
        {
            this.Transaction.Rollback();
            this.Connection.Close();
        }
    }
}
