using System;
using System.Collections.Generic;
using System.Configuration;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Data_Access_Layer.Shared
{
    public static class DBComponentsFactory
    { 
        private static DbProviderFactory _providerFactory;

        public static IDbConnection Connection
        {
            get
            {
                
                IDbConnection con = ComponentProvider.CreateConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["contacts"].ConnectionString;

                return con;
            }
        }

        public static DbProviderFactory ComponentProvider
        {
            get
            {
                if (_providerFactory == null)
                    _providerFactory = DbProviderFactories.GetFactory(ConfigurationManager.ConnectionStrings["contacts"].ProviderName);

                return _providerFactory;
            }
        }
    }
}
