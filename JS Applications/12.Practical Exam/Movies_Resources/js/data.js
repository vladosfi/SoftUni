import { beginRequest, endRequest, showError } from './notofocation.js';
import API from './api.js';

const endpoints = {
    RECIPES: 'data/recipes',
    RECIPE_BY_ID: 'data/recipes/',
    RECIPE_COUNT: 'data/recipes/count'
};

const api = new API(
    '348DBB66-8E64-4EEC-FFEA-D8566B435400',
    '03201775-FFE1-45C6-8B99-8763AF936DCD',
    beginRequest,
    endRequest);

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