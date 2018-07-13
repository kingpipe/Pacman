const connection = new signalR.HubConnectionBuilder()
    .withUrl("/chat")
    .build();

connection.start().catch(err => console.error(err.toString()));

connection.on('Send', (message) => {
    appendLine(message);
});

document.getElementById('frm-send-message').addEventListener('submit', event => {
    let message = $('#message').val();

    $('#message').val('');

    connection.invoke('Send', message);
    event.preventDefault();
});

function appendLine(message) {
    let msgElement = document.createElement('em');
    msgElement.innerText = ` ${message}`;

    let li = document.createElement('li');
    li.appendChild(msgElement);

    $('#messages').append(li);
};

var canvas = document.getElementById('map');
context = canvas.getContext('2d');

var width = canvas.width;
var height = canvas.height;

var spriteX = width / 30;
var spriteY = height / 31;

SetElement('blinky', 15 * spriteX, 11 * spriteY);
SetElement('inky', 15 * spriteX, 15 * spriteY);
SetElement('pinky', 17 * spriteX, 15 * spriteY);
SetElement('clyde', 13 * spriteX, 15 * spriteY);
SetElement('pacman', 15 * spriteX, 23 * spriteY);
SetElement('energaizer', 2 * spriteX, 3 * spriteY);
SetElement('energaizer', 27 * spriteX, 3 * spriteY);
SetElement('energaizer', 2 * spriteX, 23 * spriteY);
SetElement('energaizer', 27 * spriteX, 23 * spriteY);
