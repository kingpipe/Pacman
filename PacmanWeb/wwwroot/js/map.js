var canvas = document.getElementById('map');

var width = canvas.width;
var height = canvas.height;

var spriteX = width / 30;
var spriteY = height / 31

function DrawWall(startX, StartY, EndX, EndY) {
    context.fillRect(startX, StartY, EndX, EndY);
    context.strokeRect(startX, StartY, EndX, EndY);
}
function DrawEmtry(startX, StartY, EndX, EndY) {
    context.fillRect(startX, StartY, EndX, EndY);
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
SetStyleToWall();
for (var i = 0; i < 30; i++) {
    DrawWall(i * spriteX, 0, spriteX, spriteY);
}
//2line
DrawWall(0, spriteY, spriteX, spriteY)
DrawWall(1 * spriteX, spriteY, spriteX, spriteY);
DrawWall(14 * spriteX, spriteY, spriteX, spriteY);
DrawWall(15 * spriteX, spriteY, spriteX, spriteY);
DrawWall(28 * spriteX, spriteY, spriteX, spriteY);
DrawWall(29 * spriteX, spriteY, spriteX, spriteY);

SetStyleToEmtry();
for (var i = 2; i < 14; i++) {
    DrawEmtry(i * spriteX, spriteX, spriteX, spriteY);
}
for (var i = 16; i < 28; i++) {
    DrawEmtry(i * spriteX, spriteX, spriteX, spriteY);
}
//3line
DrawEmtry(3 * spriteX, 2 * spriteX, spriteX, spriteY);
DrawEmtry(13 * spriteX, 2 * spriteX, spriteX, spriteY);
DrawEmtry(16 * spriteX, 2 * spriteX, spriteX, spriteY);
DrawEmtry(27 * spriteX, 2 * spriteX, spriteX, spriteY);

SetStyleToWall();
DrawWall(0, 2 * spriteY, spriteX, spriteY)
DrawWall(1 * spriteX, 2 * spriteY, spriteX, spriteY)
DrawWall(2 * spriteX, 2 * spriteY, spriteX, spriteY)
for (var i = 4; i < 13; i++) {
    DrawWall(i * spriteX, 2 * spriteX, spriteX, spriteY);
}
DrawWall(14 * spriteX, 2 * spriteY, spriteX, spriteY)
DrawWall(15 * spriteX, 2 * spriteY, spriteX, spriteY)
for (var i = 17; i < 27; i++) {
    DrawWall(i * spriteX, 2 * spriteX, spriteX, spriteY);
}
DrawWall(28 * spriteX, 2 * spriteY, spriteX, spriteY)
DrawWall(29 * spriteX, 2 * spriteY, spriteX, spriteY)
