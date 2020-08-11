class Library {
    constructor(libraryName) {
        this.libraryName = libraryName;
        this.subscribers = [];
        this.subscriptionTypes;
    }

    subscribe(name, type) {
        if (!(type === 'normal' || type === 'special' || type === 'vip')) {
            throw new Error(`The type ${type} is invalid`);
        }

        let subscriber = this.subscribers.find(s => s.name === name);

        if (subscriber) {
            subscriber.type = type;
        } else {
            subscriber = {
                name,
                type,
                books: []
            }

            this.subscribers.push(subscriber);
        }

        return subscriber;
    }

    unsubscribe(name) {
        const subscriber = this.subscribers.find(s => s.name === name);
        const indexOfSubscriber = this.subscribers.indexOf(subscriber);

        if (indexOfSubscriber === -1) {
            throw new Error(`There is no such subscriber as ${name}`);
        }

        this.subscribers.splice(indexOfSubscriber, 1);
        return this.subscribers;
    }

    receiveBook(subscriberName, bookTitle, bookAuthor) {
        const subscriber = this.subscribers.find(s => s.name === subscriberName);

        if (subscriber === undefined) {
            throw new Error(`There is no such subscriber as ${subscriberName}`);
        }

        let subTypeLimit = this.libraryName.length;

        if (subscriber.type === 'special') {
            subTypeLimit *= 2;
        } else if (subscriber.type === 'vip') {
            subTypeLimit = Number.MAX_SAFE_INTEGER;
        }

        if (subscriber.books.length < subTypeLimit) {
            const book = {
                title: bookTitle,
                author: bookAuthor
            };

            subscriber.books.push(book);
        } else {
            throw new Error(`You have reached your subscription limit ${subTypeLimit}!`);
        }

        return subscriber;
    }

    showInfo() {
        const result = [];
        if (this.subscribers.length > 0) {
            this.subscribers.forEach(s => {
                result.push(`Subscriber: ${s.name}, Type: ${s.type}`);
                if (s.books.length > 0) {
                    let books = s.books.map(function (b) {
                        return (`${b.title} by ${b.author}`);
                    }).join(', ');
                    result.push(`Received books: ` + books);
                }
            });

        } else {
            result.push(`${this.libraryName} has no information about any subscribers`);
        }
        
        return result.join('\n');
    }
}


let lib = new Library('Lib');

lib.subscribe('Peter', 'normal');
lib.subscribe('John', 'special');

lib.receiveBook('John', 'A Song of Ice and Fire', 'George R. R. Martin');
lib.receiveBook('Peter', 'Lord of the rings', 'J. R. R. Tolkien');
lib.receiveBook('John', 'Harry Potter', 'J. K. Rowling');
lib.receiveBook('John', 'Harry Potter', 'J. K. Rowling\n');

console.log(lib.showInfo());

// Unexpected error: expected 
// 'Subscriber: Peter, Type: normal\nReceived books: Lord of the rings by J. R. R. Tolkien\nSubscriber: Josh, Type: vip\nReceived books: Graf Monte Cristo by Alexandre Dumas, Cromwell by Victor Hugo, Marie Tudor by Victor Hugo, Bug-Jargal by Victor Hugo, Les Orientales by Victor Hugo, Marion de Lorme by Victor Hugo'
// 'Subscriber: Peter, Type: normal\nReceived books: Lord of the rings by J. R. R. Tolkien\nSubscriber: Josh, Type: vip\nReceived books: Graf Monte Cristo by Alexandre Dumas, Cromwell by Victor Hugo, Marie Tudor by Victor Hugo, Bug-Jargal by Victor Hugo, Les Orientales by Victor Hugo, Marion de Lorme by Victor Hugo\n'