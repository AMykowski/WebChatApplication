//SignalR handler functions to establish a connection, get and append usernames and messages
//<remarks>Artur 01.09.2019</remarks>
$(function () {
    
    var chat = $.connection.chatHub;
    chat.client.addNewMessageToPage = function (name, message) {
        $('#discussion').append('<li><strong>' + htmlEncode(name)
            + '</strong>: ' + htmlEncode(message) + '</li>');
    };
    $('#message').focus();
    $.connection.hub.start().done(function () {

        //sends chat usernames and message to the ChatHub class Send method on click of submit button
        $('#sendmessage').click(function () {
            chat.server.send($('#currentUser').text(), $('#receiverUser').text(), $('#message').val());
            $('#message').val('').focus();
        });

        //does the same on pressing Enter key
        $(document).on('keypress', function (e) {
            if (e.which == 13) {
                chat.server.send($('#currentUser').text(), $('#receiverUser').text(), $('#message').val());
                $('#message').val('').focus();
            }
            
        });
    });
});
function htmlEncode(value) {
    var encodedValue = $('<div />').text(value).html();
    return encodedValue;
}