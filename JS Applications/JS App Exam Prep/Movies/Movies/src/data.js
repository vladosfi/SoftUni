import { beginRequest, endRequest, showError } from './notofocation.js';
import { setUserData, getUserId, getUserData, objectToArray } from "./util.js";

const apiKey = 'AIzaSyDek3fNQauqbrjPV8x_OihmliSD1JlbC2Y';
const databaseUrl = 'https://movie-ep-default-rtdb.europe-west1.firebasedatabase.app/';

const endpoints = {
    LOGIN: 'https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key=',
    REGISTER: 'https://identitytoolkit.googleapis.com/v1/accounts:signUp?key=',
    MOVIES: 'movies',
    MOVIES_BY_ID: 'movies/'
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
    const records = await get(host(endpoints.MOVIES));
    //const sorted = records.sort((a,b) => a.title.localeCompare(b.title));
    return objectToArray(records);
}

export async function getById(id) {
    const record = await get(host(endpoints.MOVIES_BY_ID + id));
    record._id = id;
    return record;
}

export async function createMovie(movie) {
    const data = Object.assign({ _ownerId: getUserId() }, movie);
    return post(host(endpoints.MOVIES), data);
}

export async function editMovie(id, movie) {
    return patch(host(endpoints.MOVIES_BY_ID + id), movie);
}

export async function deleteById(id) {
    return del(host(endpoints.MOVIES_BY_ID + id));
}