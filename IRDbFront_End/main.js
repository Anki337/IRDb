//  FETCH / GET
fetch("https://localhost:7171/api/Movies")
  .then((res) => res.json())
  .then((data) => displayData(data));

// Displaya datan i Index i en grid style.
// Varje div är ett card tillsammans med en border och 2px padding och möjlighet att addera bilder. Ps. Addera bilder.
function displayData(data) {
  const grandparent = document.querySelector("#grandparent");
  grandparent.innerHTML = "";

  data.forEach((element, index) => {
    if (index % 2 === 0) {
      const row = document.createElement("div");
      row.className = "row";
      grandparent.appendChild(row);
    }

    const col = document.createElement("div");
    col.className = "col p-2";
    const card = document.createElement("div");
    card.className = "card border border-primary-subtle";

    const cardBody = document.createElement("div");
    cardBody.className = "card-body";
    cardBody.innerHTML = `
      <h5 class="card-title">${element.title}</h5>
      <p class="card-text">Director: ${element.director}</p>
      <p class="card-text">Released: ${element.year}</p>
      <p class="card-text">Genre: ${element.genre}</p>
    `;

    // Ersätt : med _ för The lord of the rings naming violation lösning.
    const imageFileName = `resources/images/${element.title
      .toLowerCase()
      .replace(/:/g, "_")}.png`;

    // Lägg till bilden till cardet.
    const image = document.createElement("img");
    image.className = "card-img-top";
    image.src = imageFileName;
    image.alt = "Movie Cover";

    card.appendChild(image);
    card.appendChild(cardBody);

    col.appendChild(card);

    grandparent.lastChild.appendChild(col);
  });
}
