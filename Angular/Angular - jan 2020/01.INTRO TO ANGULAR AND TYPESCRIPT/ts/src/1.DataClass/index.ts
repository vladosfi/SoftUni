class myRequest {
    private method: string;
    private uri: string;
    private version: string;
    private message: string
    private response: string;
    private fulfilled: boolean;

    constructor(method: string, uri: string, version: string, message: string) {
        this.method = method;
        this.uri = uri;
        this.version = version;
        this.message = message;
        this.response = undefined;
        this.fulfilled = false;
    }

    toString(): any {
        const request = {
            method: this.method,
            uri: this.uri,
            version: this.version,
            message: this.message,
            response: this.response,
            fulfilled: this.fulfilled
        };

        return request;
    }
}




let myData = new myRequest('GET', 'http://google.com', 'HTTP/1.1', '')
console.log(myData);

