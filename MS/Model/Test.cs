using System;
using System.Data;
using System.Data.SqlClient;

public class Test
{
	public Test()
	{

	}

	public SqlDataReader checkUser(String username,String password)
	{
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Testing\MS\MS\MS\Database1.mdf;Integrated Security=True");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        con.Open();
        cm = new SqlCommand("SELECT * FROM Users WHERE UserName = @Username AND Password = @Password", con);
        cm.Parameters.AddWithValue("@Username", username);
        cm.Parameters.AddWithValue("@Password", password);
        cm.ExecuteNonQuery();
        dr = cm.ExecuteReader();
        return dr;


    }
}
