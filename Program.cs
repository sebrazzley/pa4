
using System;
using MySql.Data.MySqlClient;
using pa4;

string newTitle = "Cherries";

ConnectionString db = new ConnectionString();

using var con = new MySqlConnection(db.cs);
con.Open();
string stm = "Select * from exercises;";
using var cmd = new MySqlCommand(stm, con);

// cmd.CommandText = @"Insert INTO exercises(Title) VALUES(@title)";
// cmd.Parameters.AddWithValue("@title", newTitle);
// cmd.Prepare();
//cmd.ExecuteNonQuery();




//To Read in Data from table and print to user
using MySqlDataReader rdr = cmd.ExecuteReader();
while (rdr.Read())
{
    System.Console.WriteLine($"{rdr.GetInt32(0)} {rdr.GetString(1)}");
}
//****************************************************************************************

