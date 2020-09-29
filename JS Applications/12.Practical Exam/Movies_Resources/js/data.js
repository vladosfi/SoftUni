import { showError } from './notifocation.js';
import API from './api.js';

const endpoints = {
    MOVIES: 'data/movies',
    MOVIE_BY_ID: 'data/movies/',
    MOVIE_COUNT: 'data/movies/count'
};

const api = new API(
    '8FD13186-05E1-537E-FFD2-8E367B9C7400',
    '28EBBFAA-E8A6-4481-B118-B46676C48369',
);

export const login = api.login.bind(api);
export const logout = api.logout.bind(api);
export const register = api.register.bind(api);

// Get all recipes
export async function getAll(page) {

    const pagingQuery = `pageSize=9&offset=${(page - 1) * 9}`;

    return api.get(endpoints.RECIPES + '?' + pagingQuery);
}

export function checkResult(result) {
    if (result.hasOwnProperty('errorData')) {
        const error = new Error();
        Object.assign(error, result);
        throw error;
    }
}