using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Utils
{
    public class Helper
    {

        public static string GetConnectionString()
        {
            var server = Properties.Settings.Default.server;
            var database = Properties.Settings.Default.database;
            var user = Properties.Settings.Default.user;
            var pass = Properties.Settings.Default.pass;
            return $"Server={server};Database={database};Uid={user};Pwd={pass};";
        }
    }
}
