function host(endpoint) {
    return `https://api.backendless.com/7C4FA567-B589-16DB-FF0D-458BD6ABA000/FFB4645E-2CE6-4514-B1BF-0941FB2ABEDA${endpoint}`;
}

const endpoints = {
    REGISTER: '/users/register',
    LOGIN: '/users/login',
};

export async function register(username, password) {
    return (await fetch(host(endpoints.REGISTER), {
        method: 'POST',
        headers: {
            'content-type': 'application/json'
        },
        body: JSON.stringify({
            email: username,
            password: password,
        })
    })).json();
}

function login(username, password) {

}