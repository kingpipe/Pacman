var canvas = document.getElementById('map');

var width = canvas.width;
var height = canvas.height;

var spriteX = width / 30;
var spriteY = height / 31

function DrawWall(x, y) {
    context.fillRect(x * spriteX, y * spriteY, spriteX, spriteY);
    context.strokeRect(x * spriteX, y * spriteY, spriteX, spriteY);
}
function DrawEmtry(x, y) {
    context.fillRect(x * spriteX, y * spriteY, spriteX, spriteY);
}
function SetStyleToWall() {
    context.fillStyle = "blue";
    context.strokeStyle = "black";
    context.lineWidth = 1;
}
function SetStyleToEmtry() {
    context.fillStyle = "black";
}
context = canvas.getContext('2d');
//1line
var line = 0;
SetStyleToWall();
for (var i = 0; i < 30; i++) {
    DrawWall(i, line);
}
//2line
line = 1;
DrawWall(0, line)
DrawWall(1, line);
DrawWall(14, line);
DrawWall(15, line);
DrawWall(28, line);
DrawWall(29, line);

SetStyleToEmtry();
for (var i = 2; i < 14; i++) {
    DrawEmtry(i, line);
}
for (var i = 16; i < 28; i++) {
    DrawEmtry(i, line);
}
//3line
line = 2;
SetStyleToWall();
DrawWall(0, line);
DrawWall(1, line);
for (var i = 3; i < 7; i++) {
    DrawWall(i, line);
}
for (var i = 8; i < 13; i++) {
    DrawWall(i, line);
}
DrawWall(14, line);
DrawWall(15, line);
for (var i = 17; i < 22; i++) {
    DrawWall(i, line);
}
for (var i = 23; i < 27; i++) {
    DrawWall(i, line);
}
DrawWall(28, line);
DrawWall(29, line);

SetStyleToEmtry();
DrawEmtry(2, line);
DrawEmtry(7, line);
DrawEmtry(13, line);
DrawEmtry(16, line);
DrawEmtry(22, line);
DrawEmtry(27, line);
//line4
line = 3;
SetStyleToWall();
DrawWall(0, line);
DrawWall(1, line);
for (var i = 3; i < 7; i++) {
    DrawWall(i, line);
}
for (var i = 8; i < 13; i++) {
    DrawWall(i, line);
}
DrawWall(14, line);
DrawWall(15, line);
for (var i = 17; i < 22; i++) {
    DrawWall(i, line);
}
for (var i = 23; i < 27; i++) {
    DrawWall(i, line);
}
DrawWall(28, line);
DrawWall(29, line);

SetStyleToEmtry();
DrawEmtry(2, line);
DrawEmtry(7, line);
DrawEmtry(13, line);
DrawEmtry(16, line);
DrawEmtry(22, line);
DrawEmtry(27, line);
//line5
line = 4;
SetStyleToWall();
DrawWall(0, line);
DrawWall(1, line);
for (var i = 3; i < 7; i++) {
    DrawWall(i, line);
}
for (var i = 8; i < 13; i++) {
    DrawWall(i, line);
}
DrawWall(14, line);
DrawWall(15, line);
for (var i = 17; i < 22; i++) {
    DrawWall(i, line);
}
for (var i = 23; i < 27; i++) {
    DrawWall(i, line);
}
DrawWall(28, line);
DrawWall(29, line);

SetStyleToEmtry();
DrawEmtry(2, line);
DrawEmtry(7, line);
DrawEmtry(13, line);
DrawEmtry(16, line);
DrawEmtry(22, line);
DrawEmtry(27, line);
//line6
line = 5;
SetStyleToWall();
DrawWall(0, line);
DrawWall(1, line);
DrawWall(28, line);
DrawWall(29, line);

SetStyleToEmtry();
for (var i = 2; i < 28; i++) {
    DrawEmtry(i, line);
}
//line7
line = 6;
SetStyleToWall();
DrawWall(0, line);
DrawWall(1, line);
for (var i = 3; i < 7; i++) {
    DrawWall(i, line);
}
DrawWall(8, line);
DrawWall(9, line);
for (var i = 11; i < 19; i++) {
    DrawWall(i, line);
}
DrawWall(20, line);
DrawWall(21, line);
for (var i = 23; i < 27; i++) {
    DrawWall(i, line);
}
DrawWall(28, line);
DrawWall(29, line);

SetStyleToEmtry();
DrawEmtry(2, line);
DrawEmtry(7, line);
DrawEmtry(10, line);
DrawEmtry(19, line);
DrawEmtry(22, line);
DrawEmtry(27, line);
//line8
SetStyleToWall();
line = 7;
DrawWall(0, line);
DrawWall(1, line);
for (var i = 3; i < 7; i++) {
    DrawWall(i, line);
}
DrawWall(8, line);
DrawWall(9, line);
for (var i = 11; i < 19; i++) {
    DrawWall(i, line);
}
DrawWall(20, line);
DrawWall(21, line);
for (var i = 23; i < 27; i++) {
    DrawWall(i, line);
}
DrawWall(28, line);
DrawWall(29, line);

SetStyleToEmtry();
DrawEmtry(2, line);
DrawEmtry(7, line);
DrawEmtry(10, line);
DrawEmtry(19, line);
DrawEmtry(22, line);
DrawEmtry(27, line);
//line9
line = 8;
SetStyleToWall();
DrawWall(0, line);
DrawWall(1, line);
DrawWall(8, line);
DrawWall(9, line);
DrawWall(14, line);
DrawWall(15, line);
DrawWall(20, line);
DrawWall(21, line);
DrawWall(28, line);
DrawWall(29, line);

SetStyleToEmtry();
for (var i = 2; i < 8; i++) {
    DrawEmtry(i, line);
}
for (var i = 10; i < 14; i++) {
    DrawEmtry(i, line);
}
for (var i = 16; i < 20; i++) {
    DrawEmtry(i, line);
}
for (var i = 22; i < 28; i++) {
    DrawEmtry(i, line);
}
//line10
line = 9
SetStyleToWall();
for (var i = 0; i < 7; i++) {
    DrawWall(i, line);
}
for (var i = 8; i < 13; i++) {
    DrawWall(i, line);
}
DrawWall(14, line);
DrawWall(15, line);
for (var i = 17; i < 22; i++) {
    DrawWall(i, line);
}
for (var i = 23; i < 30; i++) {
    DrawWall(i, line);
}

SetStyleToEmtry();
DrawEmtry(7, line);
DrawEmtry(13, line);
DrawEmtry(16, line);
DrawEmtry(22, line);
//line11
line = 10
SetStyleToWall();
DrawWall(5, line);
DrawWall(6, line);
for (var i = 8; i < 13; i++) {
    DrawWall(i, line);
}
DrawWall(14, line);
DrawWall(15, line);
for (var i = 17; i < 22; i++) {
    DrawWall(i, line);
}
for (var i = 23; i < 25; i++) {
    DrawWall(i, line);
}

SetStyleToEmtry();
for (var i = 0; i < 5; i++) {
    DrawEmtry(i, line);
}
DrawEmtry(7, line);
DrawEmtry(13, line);
DrawEmtry(16, line);
DrawEmtry(22, line);
for (var i = 25; i < 30; i++) {
    DrawEmtry(i, line);
}
//line12
line = 11
SetStyleToWall();
DrawWall(5, line);
DrawWall(6, line);
DrawWall(8, line);
DrawWall(9, line);
DrawWall(20, line);
DrawWall(21, line);
DrawWall(23, line);
DrawWall(24, line);

SetStyleToEmtry();
for (var i = 0; i < 5; i++) {
    DrawEmtry(i, line);
}
DrawEmtry(7, line);
for (var i = 10; i < 20; i++) {
    DrawEmtry(i, line);
}
DrawEmtry(22, line);
for (var i = 25; i < 30; i++) {
    DrawEmtry(i, line);
}
//line13
line = 12
SetStyleToWall();
DrawWall(5, line);
DrawWall(6, line);
DrawWall(8, line);
DrawWall(9, line);

for (var i = 11; i < 14; i++) {
    DrawWall(i, line);
}
for (var i = 16; i < 19; i++) {
    DrawWall(i, line);
}
DrawWall(20, line);
DrawWall(21, line);
DrawWall(23, line);
DrawWall(24, line);

SetStyleToEmtry();
for (var i = 0; i < 5; i++) {
    DrawEmtry(i, line);
}
DrawEmtry(7, line);
DrawEmtry(10, line);
DrawEmtry(14, line);
DrawEmtry(15, line);
DrawEmtry(19, line);
DrawEmtry(22, line);
for (var i = 25; i < 30; i++) {
    DrawEmtry(i, line);
}
//line14
line = 13
SetStyleToWall();
for (var i = 0; i < 7; i++) {
    DrawWall(i, line);
}
DrawWall(8, line);
DrawWall(9, line);
for (var i = 11; i < 14; i++) {
    DrawWall(i, line);
}
for (var i = 16; i < 19; i++) {
    DrawWall(i, line);
}
DrawWall(20, line);
DrawWall(21, line);
for (var i = 23; i < 30; i++) {
    DrawWall(i, line);
}
SetStyleToEmtry();
DrawEmtry(7, line);
DrawEmtry(10, line);
DrawEmtry(14, line);
DrawEmtry(15, line);
DrawEmtry(19, line);
DrawEmtry(22, line);
//line15
line = 14
SetStyleToWall();
DrawWall(11, line);
DrawWall(18, line);

SetStyleToEmtry();
for (var i = 0; i < 11; i++) {
    DrawEmtry(i, line);
}
for (var i = 12; i < 18; i++) {
    DrawEmtry(i, line);
}
for (var i = 19; i < 30; i++) {
    DrawEmtry(i, line);
}
//line16
line = 15;
SetStyleToWall();
for (var i = 0; i < 7; i++) {
    DrawWall(i, line);
}
DrawWall(8, line);
DrawWall(9, line);
DrawWall(11, line);
DrawWall(18, line);
DrawWall(20, line);
DrawWall(21, line);
for (var i = 23; i < 30; i++) {
    DrawWall(i, line);
}
SetStyleToEmtry();
DrawEmtry(7, line);
DrawEmtry(10, line);
for (var i = 12; i < 18; i++) {
    DrawEmtry(i, line);
}
DrawEmtry(19, line);
DrawEmtry(22, line);
//line17
line = 16;
SetStyleToWall();
DrawWall(5, line);
DrawWall(6, line);
DrawWall(8, line);
DrawWall(9, line);
for (var i = 11; i < 19; i++) {
    DrawWall(i, line);
}
DrawWall(20, line);
DrawWall(21, line);
DrawWall(23, line);
DrawWall(24, line);

SetStyleToEmtry();
for (var i = 0; i < 5; i++) {
    DrawEmtry(i, line);
}
DrawEmtry(7, line);
DrawEmtry(10, line);
DrawEmtry(19, line);
DrawEmtry(22, line);
for (var i = 25; i < 30; i++) {
    DrawEmtry(i, line);
}
//line18
line = 17;
SetStyleToWall();
DrawWall(5, line);
DrawWall(6, line);
DrawWall(8, line);
DrawWall(9, line);
DrawWall(20, line);
DrawWall(21, line);
DrawWall(23, line);
DrawWall(24, line);

SetStyleToEmtry();
for (var i = 0; i < 5; i++) {
    DrawEmtry(i, line);
}
DrawEmtry(7, line);
for (var i = 10; i < 20; i++) {
    DrawEmtry(i, line);
}
DrawEmtry(22, line);
for (var i = 25; i < 30; i++) {
    DrawEmtry(i, line);
}
//line19
line = 18;
SetStyleToWall();
DrawWall(5, line);
DrawWall(6, line);
DrawWall(8, line);
DrawWall(9, line);
for (var i = 11; i < 19; i++) {
    DrawWall(i, line);
}
DrawWall(20, line);
DrawWall(21, line);
DrawWall(23, line);
DrawWall(24, line);

SetStyleToEmtry();
for (var i = 0; i < 5; i++) {
    DrawEmtry(i, line);
}
DrawEmtry(7, line);
DrawEmtry(10, line);
DrawEmtry(19, line);
DrawEmtry(22, line);
for (var i = 25; i < 30; i++) {
    DrawEmtry(i, line);
}
//line20
line = 19
SetStyleToWall();
for (var i = 0; i < 7; i++) {
    DrawWall(i, line);
}
DrawWall(8, line);
DrawWall(9, line);
for (var i = 11; i < 19; i++) {
    DrawWall(i, line);
}
DrawWall(20, line);
DrawWall(21, line);
for (var i = 23; i < 30; i++) {
    DrawWall(i, line);
}

SetStyleToEmtry();
DrawEmtry(7, line);
DrawEmtry(10, line);
DrawEmtry(19, line);
DrawEmtry(22, line);
//line21
line = 20;
SetStyleToWall();
DrawWall(0, line)
DrawWall(1, line);
DrawWall(14, line);
DrawWall(15, line);
DrawWall(28, line);
DrawWall(29, line);

SetStyleToEmtry();
for (var i = 2; i < 14; i++) {
    DrawEmtry(i, line);
}
for (var i = 16; i < 28; i++) {
    DrawEmtry(i, line);
}
//line22
line = 21;
SetStyleToWall();
DrawWall(0, line);
DrawWall(1, line);
for (var i = 3; i < 7; i++) {
    DrawWall(i, line);
}
for (var i = 8; i < 13; i++) {
    DrawWall(i, line);
}
DrawWall(14, line);
DrawWall(15, line);
for (var i = 17; i < 22; i++) {
    DrawWall(i, line);
}
for (var i = 23; i < 27; i++) {
    DrawWall(i, line);
}
DrawWall(28, line);
DrawWall(29, line);

SetStyleToEmtry();
DrawEmtry(2, line);
DrawEmtry(7, line);
DrawEmtry(13, line);
DrawEmtry(16, line);
DrawEmtry(22, line);
DrawEmtry(27, line);
//line23
line = 22;
SetStyleToWall();
DrawWall(0, line);
DrawWall(1, line);
for (var i = 3; i < 7; i++) {
    DrawWall(i, line);
}
for (var i = 8; i < 13; i++) {
    DrawWall(i, line);
}
DrawWall(14, line);
DrawWall(15, line);
for (var i = 17; i < 22; i++) {
    DrawWall(i, line);
}
for (var i = 23; i < 27; i++) {
    DrawWall(i, line);
}
DrawWall(28, line);
DrawWall(29, line);

SetStyleToEmtry();
DrawEmtry(2, line);
DrawEmtry(7, line);
DrawEmtry(13, line);
DrawEmtry(16, line);
DrawEmtry(22, line);
DrawEmtry(27, line);
//line24
line = 23;
SetStyleToWall();
DrawWall(0, line);
DrawWall(1, line);
DrawWall(5, line);
DrawWall(6, line);
DrawWall(23, line);
DrawWall(24, line);
DrawWall(28, line);
DrawWall(29, line);

SetStyleToEmtry();
for (var i = 2; i < 5; i++) {
    DrawEmtry(i, line);
}
for (var i = 7; i < 23; i++) {
    DrawEmtry(i, line);
}
for (var i = 25; i < 28; i++) {
    DrawEmtry(i, line);
}
//line25
line = 24;
SetStyleToWall();
for (var i = 0; i < 4; i++) {
    DrawWall(i, line);
}
DrawWall(5, line);
DrawWall(6, line);
DrawWall(8, line);
DrawWall(9, line);
for (var i = 11; i < 20; i++) {
    DrawWall(i, line);
}
DrawWall(20, line);
DrawWall(21, line);
DrawWall(23, line);
DrawWall(24, line);
for (var i = 26; i < 30; i++) {
    DrawWall(i, line);
}
SetStyleToEmtry();
DrawEmtry(4, line);
DrawEmtry(7, line);
DrawEmtry(10, line);
DrawEmtry(19, line);
DrawEmtry(22, line);
DrawEmtry(25, line);
//line26
line = 25;
SetStyleToWall();
for (var i = 0; i < 4; i++) {
    DrawWall(i, line);
}
DrawWall(5, line);
DrawWall(6, line);
DrawWall(8, line);
DrawWall(9, line);
for (var i = 11; i < 20; i++) {
    DrawWall(i, line);
}
DrawWall(20, line);
DrawWall(21, line);
DrawWall(23, line);
DrawWall(24, line);
for (var i = 26; i < 30; i++) {
    DrawWall(i, line);
}
SetStyleToEmtry();
DrawEmtry(4, line);
DrawEmtry(7, line);
DrawEmtry(10, line);
DrawEmtry(19, line);
DrawEmtry(22, line);
DrawEmtry(25, line);
//line27
line = 26;
SetStyleToWall();
DrawWall(0, line);
DrawWall(1, line);
DrawWall(8, line);
DrawWall(9, line);
DrawWall(14, line);
DrawWall(15, line);
DrawWall(20, line);
DrawWall(21, line);
DrawWall(28, line);
DrawWall(29, line);

SetStyleToEmtry();
for (var i = 2; i < 8; i++) {
    DrawEmtry(i, line);
}
for (var i = 10; i < 14; i++) {
    DrawEmtry(i, line);
}
for (var i = 16; i < 20; i++) {
    DrawEmtry(i, line);
}
for (var i = 22; i < 28; i++) {
    DrawEmtry(i, line);
}
//line28
line = 27;
SetStyleToWall();
DrawWall(0, line);
DrawWall(1, line);
for (var i = 3; i < 13; i++) {
    DrawWall(i, line);
}
DrawWall(14, line);
DrawWall(15, line);
for (var i = 17; i < 27; i++) {
    DrawWall(i, line);
}
DrawWall(28, line);
DrawWall(29, line);

SetStyleToEmtry();
DrawEmtry(2, line);
DrawEmtry(13, line);
DrawEmtry(16, line);
DrawEmtry(27, line);
//line29
line = 28;
SetStyleToWall();
DrawWall(0, line);
DrawWall(1, line);
for (var i = 3; i < 13; i++) {
    DrawWall(i, line);
}
DrawWall(14, line);
DrawWall(15, line);
for (var i = 17; i < 27; i++) {
    DrawWall(i, line);
}
DrawWall(28, line);
DrawWall(29, line);

SetStyleToEmtry();
DrawEmtry(2, line);
DrawEmtry(13, line);
DrawEmtry(16, line);
DrawEmtry(27, line);
//line30
line = 29;
SetStyleToWall();
DrawWall(0, line);
DrawWall(1, line);
DrawWall(28, line);
DrawWall(29, line);

SetStyleToEmtry();
for (var i = 2; i < 28; i++) {
    DrawEmtry(i, line);
}
//line31
line = 30;
SetStyleToWall();
for (var i = 0; i < 30; i++) {
    DrawWall(i, line);
}