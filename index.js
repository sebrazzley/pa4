let count = 0;
let myExercises = [];
let url = "http://localhost:5096/api/Exercises";

async function handleOnLoad() {
  await ExerciseList();

  let html = `
      <h1>Exercise Tracker</h1>

      <form onsubmit="return false">

      <label for="title">Title:</label><br>
      <input type="text" id="title" name="title"><br>

      <label for="distance">Distance:</label><br>
      <input type="text" id="distance" name="distance"> <br>
  
      <label for="day">Day:</label><br>
      <input type="text" id="day" placeholder="YYYY-MM-DD" name="day"> <br>

      <button class="buttonadd" onclick="handleExerciseAdd()">Add Exercise</button>
  </form>


      <div id ="tableBody"> </div>  `




  document.getElementById('app').innerHTML = html;
  populateTable();

}

const sortExercises = function (myExercises) {
  return myExercises.sort(function (a, b) {
    if (a.Day > b.Day) {
      return -1
    }
    else if (a.Day < b.Day)
      return 1
    else
      return 0
  })
}


function populateTable() {
  myExercises = sortExercises(myExercises);
  let html = `
    <table>
    <colgroup>
                <col>
                <col style="width: 100px">
                <!-- repeat as many cols as the number of headers -->
             </colgroup>
            <tr>
              <th style="width:20%">ACTIVITY TYPE</th>
              <th style="width:15%">DISTANCE (IN MILES)</th>
              <th style="width:15%">DATE COMPLETED</th>
              <th style="width:15%">---</th>
            </tr>`;
  myExercises.forEach(function (exercise) {
    if (exercise.deleted) {
      return
    }
    let pinText = "";

    if (exercise.pinned == false) {
      pinText = "Pin";
    }
    else {
      pinText = "UnPin";
    }

    html += `<tr>
        <td>${exercise.title}</td>
        <td>${exercise.distance}</td>
        <td>${exercise.day}</td>
        <td><button onclick="handlePin1('${exercise.id}')">${pinText}</button><button onclick="handleDelete('${exercise.id}')">Delete</button></td>
        
      </tr> `
  })


  html += `</table> `
  document.getElementById('tableBody').innerHTML = html;
}

async function handlePin1(id) {

  myExercises.forEach(function (exercise) {

    if (exercise.id == id) {
      exercise.pinned = !exercise.pinned;
      handlePin2(exercise);

    }
  })
}

async function handlePin2(exercise) {

  console.log(exercise)
  await fetch(url + `/${exercise.id}`, {
    method: "PUT",
    body: JSON.stringify(exercise),
    headers: {
      "Content-type": "application/json; charset=UTF-8"
    }
  });
  location.reload();
  populateTable();

}

async function handleExerciseAdd() {
  //let id = generateExerciseID();
  let exercise = {
    Title: document.getElementById('title').value,
    Distance: document.getElementById('distance').value,
    Day: document.getElementById('day').value,
    pinned: false,
    deleted: false
  };

  await fetch(url, {
    method: "POST",
    body: JSON.stringify(exercise),
    headers: {
      "Content-type": "application/json; charset=UTF-8"
    }
  });


  //   // myExercises.push(exercise);
  //   // console.log(myExercises)
  //   // localStorage.setItem('myExercises', JSON.stringify(myExercises));
  location.reload();
  populateTable();
}



// //Watch video on jeff
function handleDelete(id) {

  myExercises.forEach(function (exercise) {
    //console.log(exercise.ExerciseID)
    if (exercise.id == id) {
      exercise.deleted = !exercise.deleted;
      handleDelete2(exercise);
    }

  })

}

async function handleDelete2(exercise) {

  console.log(exercise)
  await fetch(url + `/${exercise.id}`, {
    method: "DELETE",
    body: JSON.stringify(exercise),
    headers: {
      "Content-type": "application/json; charset=UTF-8"
    }
  });
  location.reload();
  populateTable();


}


async function ExerciseList() {
  let response = await fetch(url);
  myExercises = await response.json();
  //console.log(myPokemonArr);
}