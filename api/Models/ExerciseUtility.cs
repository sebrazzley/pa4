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
                    Id = rdr.GetInt32(0),
                    Title = rdr.GetString(1),
                    Distance = rdr.GetString(2),
                    Day = rdr.GetString(3),
                    pinned = rdr.GetBoolean(4),
                    deleted = rdr.GetBoolean(5)

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
            cmd.CommandText = @"Insert INTO exercises(Title,Distance,Day) VALUES(@title,@distance,@day)";
            cmd.Parameters.AddWithValue("@title", exercise.Title);
            cmd.Parameters.AddWithValue("@distance", exercise.Distance);
            cmd.Parameters.AddWithValue("@day", exercise.Day);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            con.Close();



        }

        public void handlePin5(Exercise exercise)
        {
            ConnectionString db = new ConnectionString();
            using var con = new MySqlConnection(db.cs);
            string stm = @"Select * from exercises;";
            con.Open();

            using var cmd = new MySqlCommand(stm, con);
            cmd.CommandText = @"UPDATE exercises SET pinned = !pinned WHERE id = @id";

            cmd.Parameters.AddWithValue("@id", exercise.Id);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void handleDelete(Exercise exercise)
        {
            ConnectionString db = new ConnectionString();
            using var con = new MySqlConnection(db.cs);
            string stm = @"Select * from exercises;";
            con.Open();

            using var cmd = new MySqlCommand(stm, con);
            cmd.CommandText = @"UPDATE exercises SET deleted = !deleted WHERE id = @id";

            cmd.Parameters.AddWithValue("@id", exercise.Id);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            con.Close();
        }

    }
}


