let chirpService = (() => {

    //TOZI SERVISE SE ZANIMAVA SAMO S POSTOVETE OT BAZATA

    //vzimame vsichki postove
    function getAllSubscriptionsChirps(subs) {

        const endpoint = `chirps?query={"author":{"$in": ${subs}}}&sort={"_kmd.ect": 1}`;

        return remote.get('appdata', endpoint, 'kinvey');
    }

    function getUserChirps(username) {
        const endpoint = `chirps?query={"author":"${username}"}&sort={"_kmd.ect": 1}`;

        return remote.get('appdata', endpoint, 'kinvey');
    }

    //suzdavame nov post
    function createChirp(author, text) {
        let data = { author, text };

        return remote.post('appdata', 'chirps', 'kinvey', data);
    }

    //triem posta
    function deleteChirp(chirpId) {
        const endpoint = `chirps/${chirpId}`;

        return remote.remove('appdata', endpoint, 'kinvey');
    }

    // vzimame SAMO NASHITE POSTOVE
    function getMyChirps(username) {
        const endpoint = `posts?query={"author":"${username}"}&sort={"_kmd.ect": -1}`;

        return remote.get('appdata', endpoint, 'kinvey');
    }

    //vzimme daden post po id
    function getChirpById(chirpId) {
        const endpoint = `chirps/${chirpId}`;

        return remote.get('appdata', endpoint, 'kinvey');
    }

    function getChirpCount(username) {

        const endpoint = `chirps?query={"author":"${username}"}`;
        return remote.get('appdata', endpoint, 'kinvey');
    }

    //to finish
    function followUser(userId)
    {
        
        let data = {}
        return remote.update('appdata', endpoint, 'kinvey', data);
    }
    
    //to finish
    function unFollowUser(userId)
    {

        let data = {}
        return remote.update('appdata', endpoint, 'kinvey', data);        
    }

    return {
        getAllSubscriptionsChirps,
        createChirp,
        deleteChirp,
        getChirpById,
        getChirpCount,
        getMyChirps,
        getUserChirps
    }
})();