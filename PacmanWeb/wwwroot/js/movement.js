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

addEventListener("keydown", function (event) {
    if (event.keyCode == 32)
        connection.invoke("Start").catch(err => console.error(err.toString()));
    event.preventDefault();
});

document.getElementById("stop").addEventListener("click", event => {
    connection.invoke("Stop").catch(err => console.error(err.toString()));
    event.preventDefault();
});

addEventListener("keydown", function (event) {
    if (event.keyCode == 13)
        connection.invoke("Stop").catch(err => console.error(err.toString()));
    event.preventDefault();
});

addEventListener("keydown", function (event) {
    if (event.keyCode > 36 && event.keyCode < 41)
        connection.invoke("PacmanDirection", event.keyCode).catch(err => console.error(err.toString()));
    event.preventDefault();
});

document.getElementById("restart").addEventListener("click", event => {
    connection.invoke("Restart").catch(err => console.error(err.toString()));
    event.preventDefault();
});

connection.on('Move', (x, y, id) => {
    SetElement(id, x, y);
});

connection.on('Map', (x, y, id, level) => {
    UpdateLevel(level);
    for (var w = 0; w < x.length; w++) {
        for (var h = 0; h < x[w].length; h++) {
            SetElement(id[w][h], x[w][h], y[w][h]);
        }
    }
});

connection.on('PacmanIsKilled', (live) => {
    var element = document.getElementById("live");
    element.innerText = live;
});

connection.on('PacmanMove', (x, y, id, score) => {
    var count = document.getElementById("score");
    count.innerText = score;
    SetElement(id, x, y);
});

function SetElement(id, x, y) {
    var element = document.getElementById(id);
    context.fillStyle = "black";
    context.fillRect(x * spriteX, y * spriteY, spriteX, spriteY);
    context.drawImage(element, x * spriteX, y * spriteY, spriteX, spriteY);
}

function UpdateLevel(level) {
    var element = document.getElementById("level");
    element.innerText = level;
}