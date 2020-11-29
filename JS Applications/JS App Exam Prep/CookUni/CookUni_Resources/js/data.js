import { beginRequest, endRequest, showError } from './notofocation.js';
import API from './api.js';

const endpoints = {
    RECIPES: 'data/recipes',
    RECIPE_BY_ID: 'data/recipes/',
};

const api = new API(
    '74EE6609-BE92-DA59-FF30-E34BF3E53000',
    '71D772F5-2A43-4F97-8954-CED3F6CF86DF',
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

// get recipe by ID
export async function getRecipeById(id) {
    return api.get(endpoints.RECIPE_BY_ID + id);
}

// edit recipe by ID
export async function editRecipe(id, recipe) {
    return api.put(endpoints.RECIPE_BY_ID + id, recipe);
}

// delete recipe by ID
export async function deleteRecipe(id){
    return api.delete(endpoints.RECIPE_BY_ID + id);
}

// Like recipe by ID
export async function likeRecipe(id) {
    const recipe = await getRecipeById(id);
    return editRecipe(id, {likes: Number(recipe.likes) + 1});
}

export function checkResult (result ){
    if(result.hasOwnProperty('errorData')){
        const error = new Error();
        Object.assign(error, result);
        throw error;
    }
}