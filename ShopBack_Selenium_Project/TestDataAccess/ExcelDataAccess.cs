using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using Dapper;

namespace ShopBack_Selenium_Project.TestDataAccess
{
    public class ExcelDataAccess
    {
        /// <summary>
        /// Oledb connection to connect Test data file
        /// </summary>
        public static string TestDataFileConnection()
        {
            var fileName = ConfigurationManager.AppSettings["TestDataSheetPath"];
            var con = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = {0}; Extended Properties=Excel 12.0;", fileName);
            return con;
        }

        /// <summary>
        /// Retrieve Test data from test data file file
        /// </summary>
        public static UserData GetTestData(string testcaseName)
        {
            using (var connection = new OleDbConnection(TestDataFileConnection()))
            {
                connection.Open();
                var query = string.Format("select * from [LoginDetails$] where key='{0}'", testcaseName);
                var value = connection.Query<UserData>(query).FirstOrDefault();
                connection.Close();
                return value;
            }
        }
    }
}