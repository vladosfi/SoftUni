export function clearUserData() {
    sessionStorage.clear();
}

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
    const auth = sessionStorage.getItem('auth');

    if (auth !== null) {
        return JSON.parse(auth).localId;
    } else {
        return null;
    }
}

export function objectToArray(data) {
    //console.log(data);
    if (data === null) {
        return [];
    } else {
        //console.log(Object.entries(data).map(([k, v]) => Object.assign({ _id: k }, v)));
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

export const categoryMap = {
    'JavaScript': 'js',
    'C#': 'csharp',
    'Java': 'java',
    'Python': 'python',
};

export function mapCategories(data) {
    const result = {
        posts: []
    };

    for (let post of data) {
        result["posts"].push(post);
    }

    return result;
}