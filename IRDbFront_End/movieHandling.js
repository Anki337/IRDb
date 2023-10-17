//  FETCH / GET Function för att använda vid updatering av vyn efter CRUD functionalitet har använts.
function fetchMovies() {
  fetch("https://localhost:7171/api/Movies")
    .then((res) => res.json())
    .then((data) => console.log(data));
  // ---------------------------------------
}

// Selectors //
const idInput = document.querySelector("#id-Input");
const titleInput = document.querySelector("#title-Input");
const directorInput = document.querySelector("#director-Input");
const yearInput = document.querySelector("#year-Input");
const genreInput = document.querySelector("#genre-Input");
const durationInput = document.querySelector("#duration-Input");
const ratingInput = document.querySelector("#rating-Input");
const addMovieBtn = document.querySelector("#add-Movie-Btn");
const updateMovieBtn = document.getElementById("update-Movie-Btn");
const updmovieIdInput = document.querySelector("#updmovieIdInput");
const deleteMovieBtn = document.getElementById("delete-Movie-Btn");
const delmovieIdInput = document.getElementById("DelmovieIdInput");
const updtTitleInput = document.querySelector("#updt-title-Input");
const updtDirectorInput = document.querySelector("#updt-director-Input");
const updtYearInput = document.querySelector("#updt-year-Input");
const updtGenreInput = document.querySelector("#updt-genre-Input");
const updtDurationInput = document.querySelector("#updt-duration-Input");
const updtRatingInput = document.querySelector("#updt-rating-Input");
// Event-listeners //
addMovieBtn.addEventListener("click", addMovie);
updateMovieBtn.addEventListener("click", () => {
  // Gör om värdet från textrutan till Int
  const selectedMovieId = parseInt(updmovieIdInput.value, 10);
  // Kolla så den inte är Nan ( Not a Number ), annars, kör funtionen deleteMovie med SelectedMovieID som ID.
  if (!isNaN(selectedMovieId)) {
    updateMovie(selectedMovieId);
  }
});
deleteMovieBtn.addEventListener("click", () => {
  // Gör om värdet från textrutan till Int
  const selectedMovieId = parseInt(delmovieIdInput.value, 10);
  // Kolla så den inte är Nan ( Not a Number ), annars, kör funtionen deleteMovie med SelectedMovieID som ID.
  if (!isNaN(selectedMovieId)) {
    deleteMovie(selectedMovieId);
  }
});

// Functions //

// adda film till DB.
function addMovie() {
  // Hämta värdet av input stringen.
  const title = titleInput.value;
  const director = directorInput.value;
  const year = yearInput.value;
  const genre = genreInput.value;
  const duration = durationInput.value;
  const rating = ratingInput.value;

  const newMovie = {
    title: title,
    director: director,
    year: year,
    genre: genre,
    duration: duration,
    rating: rating,
  };

  // Skicka filmen till API:t.
  fetch("https://localhost:7171/api/Movies", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(newMovie),
  }).then((response) => {
    if (response.status === 200) {
      const successMessageElement = document.getElementById("success-message");
      successMessageElement.textContent = "Movie successfully added";
      setTimeout(() => {
        successMessageElement.textContent = "";
      }, 5000);
    }
    fetchMovies();
  });
}

// Uppdatera en existerande film.
function updateMovie() {
  const updatedMovie = {
    id: updmovieIdInput.value,
    title: updtTitleInput.value,
    director: updtDirectorInput.value,
    year: updtYearInput.value,
    genre: updtGenreInput.value,
    duration: updtDurationInput.value,
    rating: updtRatingInput.value,
  };

  fetch(`https://localhost:7171/api/Movies/${updatedMovie.id}`, {
    method: "PUT",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(updatedMovie),
  }).then((response) => {
    if (response.status === 200) {
      const successMessageElement = document.getElementById("success-message");
      successMessageElement.textContent = "Movie successfully deleted";
      setTimeout(() => {
        successMessageElement.textContent = "";
      }, 5000);
    }
    fetchMovies();
  });
}

// Ta bort en existerande film
function deleteMovie(id) {
  // Make the DELETE request with the selected ID
  fetch(`https://localhost:7171/api/Movies/${id}`, {
    method: "DELETE",
    headers: {
      "Content-Type": "application/json",
    },
  })
    .then((response) => {
      if (response.status === 200) {
        const successMessageElement =
          document.getElementById("success-message");
        successMessageElement.textContent = "Movie successfully deleted";
        setTimeout(() => {
          successMessageElement.textContent = "";
        }, 5000);
      }
      fetchMovies(); // Refresh the movie list
    })
    .catch((error) => {
      console.error("Error deleting the movie:", error);
    });
}
