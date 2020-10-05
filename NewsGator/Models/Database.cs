// using MySqlConnector;
using MySql.Data.MySqlClient;

namespace NewsGator.Models
{
  public class DB
  {
    public static string ConnectionString = $"server=localhost;user id=root;password={EnvironmentalVariables.SqlPassword};port=3306;database=gator_test;";
    public static MySqlConnection Connection()
    {
      MySqlConnection conn = new MySqlConnection(DB.ConnectionString);
      return conn;
    }

    public static MySqlConnection OpenConnection()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      return conn;
    }

    public static void CloseConnection(MySqlConnection conn)
    {
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static MySqlCommand CreateCommand(MySqlConnection conn, string commandText)
    {
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = commandText;
      return cmd;
    }
  }
}