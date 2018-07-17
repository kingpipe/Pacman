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

connection.on('Init', () => {
    InitMap();
});
var pacman = 'pacman';
var pinky = 'pinky';
var inky = 'inky';
var blinky = 'blinky';
var clyde = 'clyde';
var energaizer = 'energaizer';
var littlegoal = 'littlegoal';

function SetElement(id, x, y) {
    var element = document.getElementById(id);
    context.drawImage(element, x * spriteX, y * spriteY, spriteX, spriteY);
}

function InitMap() {
    var line = 1;
    for (var i = 2; i < 14; i++) {
        SetElement(littlegoal, i, line);
    }
    for (var i = 16; i < 28; i++) {
        SetElement(littlegoal, i, line);
    }
    line = 2;
    SetElement(energaizer, 2, line);
    SetElement(littlegoal, 7, line);
    SetElement(littlegoal, 13, line);
    SetElement(littlegoal, 16, line);
    SetElement(littlegoal, 22, line);
    SetElement(energaizer, 27, line);

    line = 3;
    SetElement(littlegoal, 2, line);
    SetElement(littlegoal, 7, line);
    SetElement(littlegoal, 13, line);
    SetElement(littlegoal, 16, line);
    SetElement(littlegoal, 22, line);
    SetElement(littlegoal, 27, line);

    line = 4;
    SetElement(littlegoal, 2, line);
    SetElement(littlegoal, 7, line);
    SetElement(littlegoal, 13, line);
    SetElement(littlegoal, 16, line);
    SetElement(littlegoal, 22, line);
    SetElement(littlegoal, 27, line);

    line = 5;
    for (var i = 2; i < 28; i++) {
        SetElement(littlegoal, i, line);
    }

    line = 6;
    SetElement(littlegoal, 2, line);
    SetElement(littlegoal, 7, line);
    SetElement(littlegoal, 10, line);
    SetElement(littlegoal, 19, line);
    SetElement(littlegoal, 22, line);
    SetElement(littlegoal, 27, line);

    line = 7;
    SetElement(littlegoal, 2, line);
    SetElement(littlegoal, 7, line);
    SetElement(littlegoal, 10, line);
    SetElement(littlegoal, 19, line);
    SetElement(littlegoal, 22, line);
    SetElement(littlegoal, 27, line);

    line = 8;
    for (var i = 2; i < 8; i++) {
        SetElement(littlegoal, i, line);
    }
    for (var i = 10; i < 14; i++) {
        SetElement(littlegoal, i, line);
    }
    for (var i = 16; i < 20; i++) {
        SetElement(littlegoal, i, line);
    }
    for (var i = 22; i < 28; i++) {
        SetElement(littlegoal, i, line);
    }

    line = 9;
    SetElement(littlegoal, 7, line);
    SetElement(littlegoal, 22, line);

    line = 10;
    SetElement(littlegoal, 7, line);
    SetElement(littlegoal, 22, line);

    line = 11;
    SetElement(littlegoal, 7, line);
    SetElement(blinky, 15, line);
    SetElement(littlegoal, 22, line);

    line = 12;
    SetElement(littlegoal, 7, line);
    SetElement(littlegoal, 22, line);

    line = 13;
    SetElement(littlegoal, 7, line);
    SetElement(littlegoal, 22, line);

    line = 14;
    SetElement(littlegoal, 7, line);
    SetElement(littlegoal, 22, line);

    line = 15;
    SetElement(littlegoal, 7, line);
    SetElement(inky, 13, line);
    SetElement(clyde, 15, line);
    SetElement(pinky, 17, line);
    SetElement(littlegoal, 22, line);

    line = 16;
    SetElement(littlegoal, 7, line);
    SetElement(littlegoal, 22, line);

    line = 17;
    SetElement(littlegoal, 7, line);
    SetElement(littlegoal, 22, line);

    line = 18;
    SetElement(littlegoal, 7, line);
    SetElement(littlegoal, 22, line);

    line = 19;
    SetElement(littlegoal, 7, line);
    SetElement(littlegoal, 22, line);

    line = 20;
    for (var i = 2; i < 14; i++) {
        SetElement(littlegoal, i, line);
    }
    for (var i = 16; i < 28; i++) {
        SetElement(littlegoal, i, line);
    }

    line = 21;
    SetElement(littlegoal, 2, line);
    SetElement(littlegoal, 7, line);
    SetElement(littlegoal, 13, line);
    SetElement(littlegoal, 16, line);
    SetElement(littlegoal, 22, line);
    SetElement(littlegoal, 27, line);

    line = 22;
    SetElement(littlegoal, 2, line);
    SetElement(littlegoal, 7, line);
    SetElement(littlegoal, 13, line);
    SetElement(littlegoal, 16, line);
    SetElement(littlegoal, 22, line);
    SetElement(littlegoal, 27, line);

    line = 23;
    SetElement(energaizer, 2, line);
    for (var i = 3; i < 5; i++) {
        SetElement(littlegoal, i, line);
    }
    for (var i = 7; i < 14; i++) {
        SetElement(littlegoal, i, line);
    }
    SetElement(pacman, 15, line);
    for (var i = 16; i < 23; i++) {
        SetElement(littlegoal, i, line);
    }
    for (var i = 25; i < 27; i++) {
        SetElement(littlegoal, i, line);
    }
    SetElement(energaizer, 27, line);

    line = 24;
    SetElement(littlegoal, 4, line);
    SetElement(littlegoal, 7, line);
    SetElement(littlegoal, 10, line);
    SetElement(littlegoal, 19, line);
    SetElement(littlegoal, 22, line);
    SetElement(littlegoal, 25, line);

    line = 25;
    SetElement(littlegoal, 4, line);
    SetElement(littlegoal, 7, line);
    SetElement(littlegoal, 10, line);
    SetElement(littlegoal, 19, line);
    SetElement(littlegoal, 22, line);
    SetElement(littlegoal, 25, line);

    line = 26;
    for (var i = 2; i < 8; i++) {
        SetElement(littlegoal, i, line);
    }
    for (var i = 10; i < 14; i++) {
        SetElement(littlegoal, i, line);
    }
    for (var i = 16; i < 20; i++) {
        SetElement(littlegoal, i, line);
    }
    for (var i = 22; i < 28; i++) {
        SetElement(littlegoal, i, line);
    }

    line = 27;
    SetElement(littlegoal, 2, line);
    SetElement(littlegoal, 13, line);
    SetElement(littlegoal, 16, line);
    SetElement(littlegoal, 27, line);

    line = 28;
    SetElement(littlegoal, 2, line);
    SetElement(littlegoal, 13, line);
    SetElement(littlegoal, 16, line);
    SetElement(littlegoal, 27, line);

    line = 29;
    for (var i = 2; i < 28; i++) {
        SetElement(littlegoal, i, line);
    }
}