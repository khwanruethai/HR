using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HR.Models
{
    public class AppConfig
    {
        public static IConfigurationRoot Config = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .AddJsonFile("config.json")
        .Build();

        public string sqlConnString1() {

            string connect = @"Data Source=10.10.20.12\MATISQL02; Initial Catalog=PersonalDB;user id=cos_db;password=c3osoil; 
             Integrated Security=false;";

            return connect;
        }

    }
}
