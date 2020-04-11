using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Data.SqlClient;
using System.IO;

namespace RunSqlFiles
{
    class RunSqlFiles
    {
        static void Main(string[] args)
        {
            try
            {
                var sqlConnectionString = args[0];
                var path = args[1];
                var dirs = Directory.GetDirectories(path);
                using var connection = new SqlConnection(sqlConnectionString);
                var server = new Server(new ServerConnection(connection));
                foreach (var dir in dirs)
                {
                    var filesName = Directory.GetFiles(dir, "*", SearchOption.AllDirectories);                    
                    foreach (var fileName in filesName)
                    {
                        var file = new FileInfo(fileName);
                        var script = file.OpenText().ReadToEnd();
                        server.ConnectionContext.ExecuteNonQuery(script);
                        file.OpenText().Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
