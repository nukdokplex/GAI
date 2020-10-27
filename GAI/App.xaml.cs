using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace GAI
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>



    public partial class App : Application
    {
        
        public static string DBConnectionString = @"metadata=res://*/GAIDataModel.csdl|res://*/GAIDataModel.ssdl|res://*/GAIDataModel.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=NDP_LAPTOP\SQLEXPRESS;initial catalog=gai;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;";
        public static string DBProviderName = "System.Data.EntityClient";
        public static user CurrentUser;

        public void OnStartup()
        {
            InitializeDatabase();
        }
        private void InitializeDatabase()
        {
            DBHolder.DB.Database.Connection.ConnectionString = DBConnectionString;
            DBHolder.DB.Database.Connection.Open();
            
        }
    }
}
