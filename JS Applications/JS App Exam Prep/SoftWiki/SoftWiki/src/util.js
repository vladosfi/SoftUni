export function setUserData(data) {
    sessionStorage.setItem('auth', JSON.stringify(data));
}

export function getUserData() {
    const auth = sessionStorage.getItem('auth');

    if (auth !== null) {
        return JSON.parse(auth);
    } else {
        return null;
    }
}

export function getUserId() {
    const auth = sessionStorage.getItem('localId');

    if (auth !== null) {
        return JSON.parse(auth).localId;
    } else {
        return null;
    }
}

export function objectToArray(data) {
    if (data === null) {
        return [];
    } else {
        return Object.entries(data).map(([k, v]) => Object.assign({ _id: k }, v));
    }
}

export async function addPartials(ctx) {
    const partials = await Promise.all([
        ctx.load('/templates/common/header.hbs'),
        ctx.load('/templates/common/footer.hbs')
    ]);

    ctx.partials = {
        header: partials[0],
        footer: partials[1]
    };
}