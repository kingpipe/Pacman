const connection = new signalR.HubConnectionBuilder()
    .withUrl("/chat")
    .build();

connection.start().catch(err => console.error(err.toString()));

var canvas = document.getElementById('map');
context = canvas.getContext('2d');

var width = canvas.width;
var height = canvas.height;

var spriteX = width / 30;
var spriteY = height / 31;


connection.on('Init', (x, y, id) => {
    SetElement(id, x, y);
});

function SetElement(id, x, y) {

    var element = document.getElementById(id);
    context.drawImage(element, x * spriteX, y * spriteY, spriteX, spriteY);
}