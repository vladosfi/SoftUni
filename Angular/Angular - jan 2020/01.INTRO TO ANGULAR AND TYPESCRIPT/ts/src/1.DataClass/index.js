var myRequest = /** @class */ (function () {
    function myRequest(method, uri, version, message) {
        this.method = method;
        this.uri = uri;
        this.version = version;
        this.message = message;
        this.response = undefined;
        this.fulfilled = false;
    }
    myRequest.prototype.toString = function () {
        var request = {
            method: this.method,
            uri: this.uri,
            version: this.version,
            message: this.message,
            response: this.response,
            fulfilled: this.fulfilled
        };
        return request;
    };
    return myRequest;
}());
var myData = new myRequest('GET', 'http://google.com', 'HTTP/1.1', '');
console.log(myData);
