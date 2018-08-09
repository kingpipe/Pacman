var tryingToReconnect = false;

const connection = new signalR.HubConnectionBuilder()
    .withUrl("/pacman")
    .build();

connection.start().catch(err => console.error(err.toString()));

var canvas = document.getElementById('map');
context = canvas.getContext('2d');

var width = canvas.width;
var height = canvas.height;

var w = Number(document.getElementById('width').innerText);
var h = Number(document.getElementById('height').innerText);

var spriteX = width / w;
var spriteY = height / h;

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

connection.on('DrawMap', (id) => {
    for (var w = 0; w < id.length; w++) {
        for (var h = 0; h < id[w].length; h++) {
            SetElement(id[w][h], w, h);
        }
    }
});

connection.on('Level', (level) => {
    var element = document.getElementById("level");
    element.innerText = level;
});

connection.on('Live', (live) => {
    var element = document.getElementById("live");
    element.innerText = live;
    if (live == 0)
        connection.invoke("AddinDB").catch(err => console.error(err.toString()));
});

connection.on('Score', (score) => {
    var count = document.getElementById("score");
    count.innerText = score;
});

function SetElement(id, x, y) {
    var element = document.getElementById(id);
    context.fillStyle = "black";
    context.fillRect(x * spriteX, y * spriteY, spriteX, spriteY);
    context.drawImage(element, x * spriteX, y * spriteY, spriteX, spriteY);
}