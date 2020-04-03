"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();
var Image;
//////////REUSED METHODS//////////////////////
const toBase64 = file => new Promise((resolve, reject) => {
    const reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = () => resolve(reader.result);
    reader.onerror = error => reject(error);
});
//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;


//////Start Reading from here
//1
///WEBSOCKET-RECEIVER
connection.on("ReceiveMessge", async function (message, apiKey, apiId) {
    var base64 = await toBase64(Image);
    var OptionsBody = {
        'src': base64,       
    }
    const options={
        method: 'POST',
        body: JSON.stringify(OptionsBody),
        headers: new Headers({
            'Content-type': 'application/json',
            'app_id': apiId,
            'app_key': apiKey
        })
    }
    fetch("https://api.mathpix.com/v3/text", options)
        .then(res => console.log(res.json()))
});

////////You don't need anything below 1
//////END
///////I have the apikey and apiId with me,You will store it as an environment variable in your project
/////the message variable can be ignored



//////Don't read WEBSOCKET-SENDER
////WEBSOCKET-SENDER
connection.start().then(function () {
    //Enable send button
    document.getElementById("sendButton").disabled = false;

}).catch(function (err) {
    return console.error(err.toString());
    });
document.getElementById("sendButton").addEventListener("click", async function (event) {
    Image = document.getElementById("userInput").files[0];
    var message = "message";
    connection.invoke("SendMessage",message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});
//'ocr': 'maths',
        //'skip_recrop': true,
        //'formats':'{text,latex_simplified,latex_styled,mathml,asciimath,latex_list}'
