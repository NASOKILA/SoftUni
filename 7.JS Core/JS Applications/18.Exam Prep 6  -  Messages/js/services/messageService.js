

let messageService = (() => {

    function listMessagesByRecipient(){
        let username = sessionStorage.getItem('username');
        let endpoint = `messages?query={"recipient_username":"${username}"}`;

        return remote.get('appdata', endpoint, 'kinvey');
    }

    function listMessagesBySender(){
        let username = sessionStorage.getItem('username');        
        let endpoint = `messages?query={"sender_username":"${username}"}`;

        return remote.get('appdata', endpoint, 'kinvey');
    }

    function sendMessage(sender_username, sender_name, recipient_username, text) {
        let data = { sender_username, sender_name, recipient_username, text };

        return remote.post('appdata', 'messages', 'kinvey', data);
    }

    function deleteMessage(msq_Id) {
        const endpoint = `messages/${msq_Id}`;

        return remote.remove('appdata', endpoint, 'kinvey');
    }

    function formatDate(dateISO8601) {
        let date = new Date(dateISO8601);
        if (Number.isNaN(date.getDate()))
            return '';
        return date.getDate() + '.' + padZeros(date.getMonth() + 1) +
            "." + date.getFullYear() + ' ' + date.getHours() + ':' +
            padZeros(date.getMinutes()) + ':' + padZeros(date.getSeconds());
    
        function padZeros(num) {
            return ('0' + num).slice(-2);
        }
    }
    
    function formatSender(name, username) {
        if (!name)
            return username;
        else
            return username + ' (' + name + ')';
    }
    

    return {
        listMessagesByRecipient,
        listMessagesBySender,
        sendMessage,
        deleteMessage,
        formatDate,
        formatSender
    }

})();