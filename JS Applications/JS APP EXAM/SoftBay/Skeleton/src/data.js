import { setUserData, getUserId, getUserData, objectToArray } from "./util.js";

const apiKey = 'AIzaSyAKzyhDz2hM8s5ct0J5yQDr6z1fkRI2WxA';
const databaseUrl = 'https://softbay-4e82f-default-rtdb.firebaseio.com/';

const endpoints = {
    LOGIN: 'https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key=',
    REGISTER: 'https://identitytoolkit.googleapis.com/v1/accounts:signUp?key=',
    OFFERS: 'offers',
    OFFER_BY_ID: 'offers/',
    USERS: 'users',
    USER_BY_ID: 'users/',
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
        const message = data.error.message;
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
    const records = await get(host(endpoints.OFFERS));
    return objectToArray(records);
}

export async function getById(id) {
    const record = await get(host(endpoints.OFFER_BY_ID + id));
    record._id = id;
    return record;
}

export async function createOffer(offer) {
    const data = Object.assign({ _ownerId: getUserId() }, offer);
    return post(host(endpoints.OFFERS), data);
}

export async function editOffer(id, offer) {
    return patch(host(endpoints.OFFER_BY_ID + id), offer);
}

export async function deleteById(id) {
    return del(host(endpoints.OFFER_BY_ID + id));
}

export async function getUsers() {
    const records = await get(host(endpoints.USERS));
    return objectToArray(records);
}





export async function getProductBuyById(id) {
    const record = await get(host(endpoints.USER_BY_ID + id));
    record._id = id;
    return record;
}

export async function editProductBuyById(id) {
    return patch(host(endpoints.USER_BY_ID + id), offer);
}


export async function createProduct(id) {
    const data = Object.assign({ _ownerId: getUserId() }, 1);
    return post(host(endpoints.OFFERS), data);
}
