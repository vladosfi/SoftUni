function host(endpoint) {
    return `https://api.backendless.com/7C4FA567-B589-16DB-FF0D-458BD6ABA000/FFB4645E-2CE6-4514-B1BF-0941FB2ABEDA/${endpoint}`;
}

const endpoints = {
    REGISTER: 'users/register',
    LOGIN: 'users/login',
    LOGOUT: 'users/logout',
    TEAMS: 'data/teams',
    UPDATE_USER: 'users/',
};

export async function register(username, password) {
    return (await fetch(host(endpoints.REGISTER), {
        method: 'POST',
        headers: {
            'content-type': 'application/json'
        },
        body: JSON.stringify({
            username: username,
            password: password,
        })
    })).json();
}

export async function login(username, password) {
    return (await fetch(host(endpoints.LOGIN), {
        method: 'POST',
        headers: {
            'content-type': 'application/json'
        },
        body: JSON.stringify({
            login: username,
            password: password,
        })
    })).json();
}

export async function logout() {
    const token = localStorage.getItem('userToken');
    if (!token) {
        throw new Error('User is not logged in!');
    }

    return fetch(host(endpoints.LOGOUT), {
        method: 'GET',
        headers: {
            'user-token': token
        }
    });
}


async function setUserTeamId(userId, teamId) {
    const token = localStorage.getItem('userToken');
    if (!token) {
        throw new Error('User is not logged in!');
    }

    return (await fetch(host(endpoints.UPDATE_USER + userId), {
        method: 'PUT',
        headers: {
            'content-type': 'application/json',
            'user-token': token,
        },
        body: JSON.stringify({
            teamId
        })
    })).json();

}

export async function createTeam(team) {
    const token = localStorage.getItem('userToken');
    if (!token) {
        throw new Error('User is not logged in!');
    }

    const result = await (await fetch(host(endpoints.TEAMS), {
        method: 'POST',
        headers: {
            'content-type': 'application/json',
            'user-token': token,
        },
        body: JSON.stringify(team)
    })).json();

    if (result.hasOwnProperty('errorData')) {
        const error = new Error();
        Object.assign(error, result);
        throw error;
    }

    //Assign teamId to user
    const userUpdateResult = await setUserTeamId(result.ownerId, result.objectId);

    if (userUpdateResult.hasOwnProperty('errorData')) {
        const error = new Error();
        Object.assign(error, userUpdateResult);
        throw error;
    }

    return result;
}

export async function getTeamById(id) {
    return (await fetch(host(endpoints.TEAMS + '/' + id))).json();
}

export async function getTeams() {
    return (await fetch(host(endpoints.TEAMS))).json();
}