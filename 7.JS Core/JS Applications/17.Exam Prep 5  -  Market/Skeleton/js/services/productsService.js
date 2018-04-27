
let productsService = (() => {

    function getAllProducts() {
        const endpoint = 'products/';
    
        return remote.get('appdata', endpoint, 'kinvey');
    }

    function updateUser(id, username, name, cart){
        let endpoint = id;
        let obj = {username, name, cart}

        return remote.update('user', endpoint, 'kinvey', obj);
    }

    function getProduct(productId) {
        const endpoint = `products/${productId}`;

        return remote.get('appdata', endpoint, 'kinvey');
    }

    return {
        getAllProducts,
        updateUser,
        getProduct
    }

})();

