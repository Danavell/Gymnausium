using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                //con.ConnectionString = ConfigurationManager.ConnectionStrings["sql"].ConnectionString;
                con.ConnectionString = "Data Source=kraka.ucn.dk; Initial Catalog=dmaj0917_1067666; User ID=dmaj0917_1067666; Password=Password1!;";

                return con;
            }
        }

        public static DbProviderFactory ComponentProvider
        {
            get
            {
                if (_providerFactory == null)
                {
                    //_providerFactory = DbProviderFactories.GetFactory(ConfigurationManager.ConnectionStrings["sql"].ProviderName);
                    _providerFactory = DbProviderFactories.GetFactory("System.Data.SqlClient");

                }
                return _providerFactory;
            }
        }

    }
}
