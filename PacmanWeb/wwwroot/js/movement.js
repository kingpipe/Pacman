var canvas = document.getElementById('map');
context = canvas.getContext('2d');

var width = canvas.width;
var height = canvas.height;

var spriteX = width / 30;
var spriteY = height / 31;

pacmanR = $.connection.pacmanHub;
pacmanR.client.broadcastMessage = function (x, y, idx) {
    
};

$.connection.hub.start().done(function () {
    console.log("Hub is started.");
});



function SetElement(id, x, y) {

    var element = document.getElementById(id);
    context.drawImage(element, x, y, spriteX, spriteY);
}

$(function () {
    // Declare a proxy to reference the hub.
    var pacman = $.connection.pacmanHub;
    // Create a function that the hub can call to broadcast messages.
    pacman.client.SendAsync = function (x, y, id) {
        // Html encode display name and message.
        SetElement(x, y, id);
    };
    // Start the connection.
    $.connection.hub.start().done(function () {
        $('#sendmessage').click(function () {
            // Call the Send method on the hub.
            pacman.server.send($('#displayname').val(), $('#message').val());
            // Clear text box and reset focus for next comment.
            $('#message').val('').focus();
        });
    });
});


SetElement('blinky', 15 * spriteX, 11 * spriteY);
SetElement('inky', 15 * spriteX, 15 * spriteY);
SetElement('pinky', 17 * spriteX, 15 * spriteY);
SetElement('clyde', 13 * spriteX, 15 * spriteY);
SetElement('pacman', 15 * spriteX, 23 * spriteY);
SetElement('energaizer', 2 * spriteX, 3 * spriteY);
SetElement('energaizer', 27 * spriteX, 3 * spriteY);
SetElement('energaizer', 2 * spriteX, 23 * spriteY);
SetElement('energaizer', 27 * spriteX, 23 * spriteY);
