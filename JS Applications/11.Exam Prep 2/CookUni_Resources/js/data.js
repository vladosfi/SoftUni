import { beginRequest, endRequest, showError } from './notofocation.js';
import API from './api.js';

const endpoints = {
    RECIPES: 'data/recipes',
    RECIPE_BY_ID: 'data/recipes/',

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
export async function getAll() {
    return api.get(endpoints.RECIPES);
}

// Create (share) recipe
export async function createRecipe(recipe) {
    return api.post(endpoints.RECIPES, recipe);
}

// Get recipe by ID
export async function getRecipeByID(id) {
    return api.get(endpoints.RECIPE_BY_ID + id)
}

// Edit recipe by ID
export async function editRecipe(id, recipe) {
    return api.put(endpoints.RECIPE_BY_ID + id, recipe);
}

// Delete recipe by ID
export async function deleteRecipe(id){
    await api.delete(endpoints.RECIPE_BY_ID + id);
}

// Like recipe by ID
export async function likeRecipe(id) {
    const recepie = await getRecipeByID(id);
    return await editRecipe(id, { likes: recepie.likes + 1 });
}

export function checkResult (result){
    if (result.hasOwnProperty('errorData')) {
        const error = new Error();
        Object.assign(error, result);
        throw error;
    }
}