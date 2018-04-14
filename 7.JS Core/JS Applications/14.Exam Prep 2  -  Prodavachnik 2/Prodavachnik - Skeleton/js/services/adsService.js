/*
let adsService = (() => {

    function getAllAds() {
        const endpoint = 'advertisements';
    
        return remote.get('appdata', endpoint, 'kinvey');
    }

    return
    {
        getAllAds
    }

})();
*/

let ads = (() => {


    function getAllAds() {
        const endpoint = 'advertisements';
    
        return remote.get('appdata', endpoint, 'kinvey');
    }


    function deleteAdd(addId) {
        const endpoint = `advertisements/${addId}`;

        return remote.remove('appdata', endpoint, 'kinvey');
    }


    function getAddById(addId) {
        const endpoint = `advertisements/${addId}`;
        return remote.get('appdata', endpoint, 'kinvey');
    }


    function createAd(publisher, title, description, date, price, views, linkToImage) {
        
        const endpoint = 'advertisements';
        let data = { publisher, title, description, date, price, views, linkToImage };

        return remote.post('appdata', endpoint, 'kinvey', data);
    }

    
    function editAd(adId, publisher, title, description, date, price, views, linkToImage) {

        const endpoint = `advertisements/${adId}`;
        let data = { publisher, title, description, date, price, views, linkToImage };

        return remote.update('appdata', endpoint, 'kinvey', data);
    }


    return {    
        getAllAds,
        deleteAdd,
        getAddById,
        createAd,
        editAd  
    }
})();