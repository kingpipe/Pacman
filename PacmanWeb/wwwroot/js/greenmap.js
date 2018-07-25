var canvas = document.getElementById('map');
context = canvas.getContext('2d');

function SetElement(id, x, y) {
    var element = document.getElementById(id);
    context.fillStyle = "black";
    context.fillRect(x * spriteX, y * spriteY, spriteX, spriteY);
    context.drawImage(element, x * spriteX, y * spriteY, spriteX, spriteY);
}


function readTextFile(file, callback) {
    var rawFile = new XMLHttpRequest();
    rawFile.overrideMimeType("application/json");
    rawFile.open("GET", file, true);
    rawFile.onreadystatechange = function () {
        if (rawFile.readyState === 4 && rawFile.status == "200") {
            callback(rawFile.responseText);
        }
    }
    rawFile.send(null);
}
readTextFile('/maps/greenmap.json', function (text) {
    var data = JSON.parse(text);

    var width = canvas.width;
    var height = canvas.height;

    var spriteX = width / data.length;
    var spriteY = height / data[0].length;

    for (var w = 0; w < data.length; w++) {
        for (var h = 0; h < data[w].length; h++) {
            SetElement(data[w][h], h, w);
        }
    }
});