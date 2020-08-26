function host(endpoint) {
    if (endpoint === undefined) {
        return `http://localhost:8000/phonebook`;
    } else {
        return `http://localhost:8000/phonebook/${endpoint}`;
    }
}

export async function getData() {
    const data = await (await fetch(host(''))).json();
    console.log(data);
    return data;
}

export function deleteData(id) {
    return new Promise((resolve, reject) => {
        //return reject('cannot delete entry');
        fetch(host(id), {
            method: 'DELETE'
        }).then(data => {
            setTimeout(resolve, 1500);
        }).catch(err => reject(err));
    });

}

export async function createEntry(entry) {
    return (await fetch(host(), {
        method: 'POST',
        body: JSON.stringify(entry)
    })).json();
}