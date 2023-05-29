
var activeRoomId = '';

var connection = new signalR.HubConnectionBuilder()
    .withUrl("/Suphub")
    .build();


var connectionChatClient = new signalR.HubConnectionBuilder()
    .withUrl("/chathub")
    .build();

connectionChatClient.start();

connection.start();


connection.on('GetMasseg', addMessages);


connectionChatClient.on('GetNewMasseg', showMessage);

function addMessages(messages) {
    if (!messages) return;
    messages.forEach(function (m) {
        showMessage(m.sender, m.mesege, m.time);
    });
}

function showMessage(sender, mesege, time) {
  
    $("#chatMessage").append('<li><div><span class="name"> ' + sender + ' </span><span class="time">' + time + '</span></div><div class="message"> ' + mesege + ' </div></li>');
}




connection.on('GetRooms', loadRooms);

function loadRooms(rooms) {
    
    if (!rooms) return;
    var roomIds = Object.keys(rooms);
   
    if (!roomIds.length) return;

    removeAllChildren(roomListEl);

    roomIds.forEach(function (id) {

        var roomInfo = rooms[id];
     
        if (!roomInfo) return;
     
       
        //ایجاد دکمه برای لیست
        return $("#roomList").append("<a class='list-group-item list-group-item-action d-flex justify-content-between align-items-center' data-id='" + roomInfo + "' href='#'>" + roomInfo + "</a>");

    });

}
$(document).ready(function () {
    loadRooms();
    var answerForm = $("#answerForm");
    answerForm.on('submit', function (e) {

        e.preventDefault();
        var text = e.target[0].value; // target 0 to yaniavalin paramert to form kemishe text box
        e.target[0].value = '';
     
        sendMessage(text);
    });

});
function sendMessage(text) {

    if (text && text.length) {
        connection.invoke('SendMessage', activeRoomId, text);
    }
}


var roomListEl = document.getElementById('roomList');
var roomMessagesEl = document.getElementById('chatMessage');


function removeAllChildren(node) {
    if (!node) return;

    while (node.lastChild) {
        node.removeChild(node.lastChild);
    }
}

function setActiveRoomButton(el) {
    var allButtons = roomListEl.querySelectorAll('a.list-group-item');

    allButtons.forEach(function (btn) {
        btn.classList.remove('active');
    });
    el.classList.add('active');
}







function switchActiveRoomTo(id) {
    if (id === activeRoomId) return;

    removeAllChildren(roomMessagesEl);
    if (activeRoomId) {
        connectionChatClient.invoke('LeaveRoom', activeRoomId);
    }
    activeRoomId = id;
    connectionChatClient.invoke('joinRoom', activeRoomId);
    connection.invoke('LoadMessage', activeRoomId);
}


if (roomListEl != null) {
    roomListEl.addEventListener('click', function (e) {
        roomMessagesEl.style.display = 'block';
        setActiveRoomButton(e.target);
        var roomId = e.target.getAttribute('data-id');
        switchActiveRoomTo(roomId);
    });
}