using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using api.models;
using api.Models;




namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class exercisesController : ControllerBase
    {
        // GET: api/exercises
        [HttpGet]
        public List<Exercise> Get()
        {
            ExerciseUtility utility = new ExerciseUtility();
            return utility.GetAllExercises();
        }

        // GET: api/exercises/5
        // [HttpGet("{id}", Name = "Get")]
        // public Exercise Get(int id)
        // {
        //     ExerciseUtility utility = new ExerciseUtility();
        //     List<Exercise> myExercises = utility.GetAllExercises();
        //     foreach (Exercise exercise in myExercises)
        //     {
        //         if (exercise.id == id)
        //         {
        //             return exercise;
        //         }
        //     }
        //     return new Exercise();

        // }

        // POST: api/exercises //Adds a new exercise
        [HttpPost]
        public void Post([FromBody] Exercise value)
        {
            //Console.WriteLine(value.Title);
            ExerciseUtility utility1 = new ExerciseUtility();
            utility1.AddExercise(value);


        }

        // PUT: api/exercises/5
        //will be for pinned
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Exercise value)
        {
            ExerciseUtility utility2 = new ExerciseUtility();
            utility2.handlePin5(value);
        }

        // DELETE: api/exercises/5
        //will be for delete duh
        [HttpDelete("{id}")]
        public void Delete(int id, [FromBody] Exercise value)
        {
            ExerciseUtility utility5 = new ExerciseUtility();
            utility5.handleDelete(value);

        }
    }
}
