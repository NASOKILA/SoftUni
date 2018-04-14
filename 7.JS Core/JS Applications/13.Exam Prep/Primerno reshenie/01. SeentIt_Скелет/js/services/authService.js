let auth = (() => {

    //proverqva dali sme autentikirani
    function isAuth() {
        return sessionStorage.getItem('authtoken') !== null;
    }

    //zapazva ni neshtata v session storage
    function saveSession(userData) {
        sessionStorage.setItem('authtoken', userData._kmd.authtoken);
        sessionStorage.setItem('username', userData.username);
        sessionStorage.setItem('userId', userData._id);
    }

    //registrira nov user pravi post zaqvka
    function register (username, password) {
        let obj = { username, password };

        return remote.post('user', '', 'basic', obj);
    }

    //logva ni pravi post zaqvka
    function login(username, password) {
        let obj = { username, password };

        return remote.post('user', 'login', 'basic', obj)
    }
    
    //logoutva ni pak sus post zaqvka
    function logout() {
        return remote.post('user', '_logout', 'kinvey');
    }

    return {
        isAuth,
        login,
        logout,
        register,
        saveSession
    }
})();