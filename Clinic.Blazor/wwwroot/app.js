function setToken(key, value) {
    localStorage.setItem(key, value);
}
function getToken(key) {
    return localStorage.getItem(key);
}
function removeToken(key) {
    localStorage.removeItem(key);
}