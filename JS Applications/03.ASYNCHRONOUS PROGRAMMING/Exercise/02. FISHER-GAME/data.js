function host(endpoint) {
    if (endpoint == '') {
        return `https://fisher-game.firebaseio.com/catches.json`;
    } else {
        return `https://fisher-game.firebaseio.com/catches/${endpoint}.json`
    }
}


export async function getData() {
    const data = await (await fetch(host(''))).json();
    return data;
}

export async function createEntry(entry) {
    return (await fetch(host(''), {
        method: 'POST',
        body: JSON.stringify(entry)
    }));
}

export async function updateEntry(id, entry) {
    return (await fetch(host(id), {
        method: 'PUT',
        body: JSON.stringify(entry)
    }));
}

export async function deleteEntry(id) {
    return (await fetch(host(id), {
        method: 'DELETE'
    }));
}
