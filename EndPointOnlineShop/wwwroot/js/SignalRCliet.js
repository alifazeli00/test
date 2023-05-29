
var connection = new signalR.HubConnectionBuilder()
    .withUrl("/chathub")
    .build();

connection.start();


var connectionn = new signalR.HubConnectionBuilder()
    .withUrl("/Suphub")
    .build();




connectionn.start();



//$(document).ready(function () {
//    connection.invoke('SendNewMessage', "بازدید کننده", "سلام این پیام از سمت کلاینت ارسال شده است");
//    connection.invoke('SendNewMessage', "بازدیدکننده", "سلام این پیام از سمت کلاینت ارسال شده است");
//});

var chatBox = $("#ChatBox");



function showChatDialog() {
    chatBox.css("display", "block");
    }
function Init() {

    setTimeout(showChatDialog, 1000);
    var newMassegeForm = $("#NewMessageForm");
    newMassegeForm.on("submit", function (e) {
        e.preventDefault(); // jelogiri az ersal
        var massege = e.target[0].value; // chon input avalin item dakhel form
        e.target[0].value = '';
     
        connection.invoke('SendNewMessage', "client", massege)
    })
}

connection.on('GetNewMasseg', getMasseg);

function getMasseg(sender, message, time) {
    alert(message);
    alert("sa");
   

    $("#Messages").append("<li><div><span class='name'>" + sender + "</span><span clas='time'>" + time + "</span></div><div class='message'>" + message + "</div></li>")
        ;


};
$(document).ready(function () {
    showChatDialog();
    Init();
});
