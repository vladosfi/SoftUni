class Data {
    response: string = undefined;
    fulfilled: boolean = false;

    constructor(public method: string, public uri: string, public version: string, public message: string) {
    }

    toString(){
        return {
            method: this.method,
            uri: this.uri,
            version: this.version,
            message: this.message,
            response: this.response,
            fulfilled: this.fulfilled};
    }
}

let myData = new Data('GET', 'http://google.com', 'HTTP/1.1', '');
console.log(myData.toString());