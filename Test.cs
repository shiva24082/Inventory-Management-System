using System;
using System.Data;
using System.Data.SqlClient;

public class Test
{
	public Test()
	{

	}

	public DataReady function checkUser(username,password)
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

        if (dr.Read())
        {
            return dr;
        }



    }
}
