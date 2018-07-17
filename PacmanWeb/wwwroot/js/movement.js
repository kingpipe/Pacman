const connection = new signalR.HubConnectionBuilder()
    .withUrl("/game")
    .build();

connection.start().catch(err => console.error(err.toString()));

var canvas = document.getElementById('map');
context = canvas.getContext('2d');

var width = canvas.width;
var height = canvas.height;

var spriteX = width / 30;
var spriteY = height / 31;

document.getElementById("start").addEventListener("click", event => {
    connection.invoke("Start").catch(err => console.error(err.toString()));
    event.preventDefault();
});

document.getElementById("stop").addEventListener("click", event => {
    connection.invoke("Stop").catch(err => console.error(err.toString()));
    event.preventDefault();
});

addEventListener("keydown", function (event) {
    if (event.keyCode > 36 && event.keyCode < 41)
        connection.invoke("PacmanDirection", event.keyCode).catch(err => console.error(err.toString()));
    event.preventDefault();
});

connection.on('Move', (x, y, id) => {
    SetElement(id, x, y);
});

connection.on('PacmanMove', (x, y, id, score) => {
    var count = document.getElementById("score");
    count.innerText = score;
    SetElement(id, x, y);
});

function SetElement(id, x, y) {
    context.fillStyle = "black";
    context.fillRect(x * spriteX, y * spriteY, spriteX, spriteY);
    var element = document.getElementById(id);
    context.drawImage(element, x * spriteX, y * spriteY, spriteX, spriteY);
}
