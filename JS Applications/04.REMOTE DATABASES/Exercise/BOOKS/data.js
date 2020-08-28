const appId = '7C4FA567-B589-16DB-FF0D-458BD6ABA000';
const apiKey = 'FFB4645E-2CE6-4514-B1BF-0941FB2ABEDA';

function host(endpoint) {
    return `https://api.backendless.com/${appId}/${apiKey}/data/${endpoint}`;
}

export async function getBooks() {
    const response = await (fetch(host('books')))
    const data = await response.json();
    return data;

    // let response = fetch(host('books'))
    //     .then(resp => resp.json())
    //     .then(result => result);
    // return response;

}

export async function createBook(book) {
    const response = await fetch(host('books'), {
        method: 'POST',
        body: JSON.stringify(book),
    });

    const data = await response.json();
    return data;
}

export async function updateBook(book) {
    const id = book.objectId;
    const response = await fetch(host('books/' + id), {
        method: 'PUT',
        body: JSON.stringify(book),
    });

    const data = await response.json();
    return data;
}

export async function deleteBook(id) {
    const response = await fetch(host('books/' + id), {
        method: 'DELETE',
    });

    const data = await response.json();
}