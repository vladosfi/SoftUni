import { setUserData, getUserId, getUserData, objectToArray } from "./util.js";

const apiKey = 'AIzaSyCnHxCLGWpkop5xf31Uc74XP5W2Jh7nbQ0';
const databaseUrl = 'https://shoes-ace8a-default-rtdb.firebaseio.com/';

const endpoints = {
    LOGIN: 'https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key=',
    REGISTER: 'https://identitytoolkit.googleapis.com/v1/accounts:signUp?key=',
    SHOES: 'shoes',
    SHOE_BY_ID: 'shoes/'
};


function host(url) {
    let result = databaseUrl + url + '.json';
    const auth = getUserData();
    if (auth !== null) {
        result += `?auth=${auth.idToken}`;
    }
    return result;
}

export const request = async (url, method, body) => {
    let options = {
        method,
    };

    if (body) {
        Object.assign(options, {
            headers: {
                'content-type': 'application/json'
            },
            body: JSON.stringify(body)
        });
    }

    let response = await fetch(url, options);

    let data = await response.json();

    if (data && data.hasOwnProperty('error')) {
        let message = data.error.message;
        if(message == undefined){
            message = data.error;
        }
        throw new Error(message);
    }

    return data;
}

async function get(url) {
    return request(url, 'GET');
}

async function post(url, body) {
    return request(url, 'POST', body);
}

async function del(url) {
    return request(url, 'DELETE');
}

async function patch(url, body) {
    return request(url, 'PATCH', body);
}

export async function login(email, password) {
    let response = await post(endpoints.LOGIN + apiKey, {
        email,
        password,
        returnSecureToken: true,
    });

    setUserData(response);

    return response;
}

export async function register(email, password) {
    let response = await post(endpoints.REGISTER + apiKey, {
        email,
        password,
        returnSecureToken: true,
    });

    setUserData(response);

    return response;
}

export async function getAll() {
    const records = await get(host(endpoints.SHOES));
    //const sorted = records.sort((a,b) => a.title.localeCompare(b.title));
    return objectToArray(records);
}

export async function getById(id) {
    const record = await get(host(endpoints.SHOE_BY_ID + id));
    record._id = id;
    return record;
}

export async function createShoe(shoe) {
    const data = Object.assign({ _ownerId: getUserId() }, shoe);
    return post(host(endpoints.SHOES), data);
}

export async function editArticle(id, shoe) {
    return patch(host(endpoints.SHOE_BY_ID + id), shoe);
}

export async function deleteById(id) {
    return del(host(endpoints.SHOE_BY_ID + id));
}