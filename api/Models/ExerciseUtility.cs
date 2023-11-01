using System.Net.Http.Headers;
using api.models;
using MySql.Data.MySqlClient;
using pa4;

namespace api.Models
{
    public class ExerciseUtility
    {
        public List<Exercise> GetAllExercises()
        {
            ConnectionString db = new ConnectionString();

            using var con = new MySqlConnection(db.cs);
            con.Open();
            string stm = "Select * from exercises;";
            using var cmd = new MySqlCommand(stm, con);


            List<Exercise> myExercises = new List<Exercise>();
            using MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                myExercises.Add(new Exercise
                {
                    Title = rdr.GetString(1)
                });
            }
            con.Close();
            return myExercises;

        }

        public void AddExercise(Exercise exercise)
        {
            ConnectionString db = new ConnectionString();
            using var con = new MySqlConnection(db.cs);
            string stm = "Select * from exercises;";
            con.Open();
            // 

            using var cmd = new MySqlCommand(stm, con);
            cmd.CommandText = @"Insert INTO exercises(Title) VALUES(@title)";
            cmd.Parameters.AddWithValue("@title", exercise.Title);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            con.Close();
            Console.WriteLine("Itsworking");


        }

    }
}


