//import { showError } from './notifocation.js';
import API from './api.js';

const endpoints = {
    MOVIES: 'data/movies',
    MOVIE_BY_ID: 'data/movies/',
};

const api = new API(
    '8FD13186-05E1-537E-FFD2-8E367B9C7400',
    '28EBBFAA-E8A6-4481-B118-B46676C48369',
);

export const login = api.login.bind(api);
export const logout = api.logout.bind(api);
export const register = api.register.bind(api);

// Get all movies
export async function getAll(search) {
    if (!search) {
        return api.get(endpoints.MOVIES);
    } else {
        return api.get(endpoints.MOVIES + `?where=${escape(`genres LIKE '%${search}%'`)}`);
    }
}

// Create movie
export async function createMovie(movie) {
    return api.post(endpoints.MOVIES, movie);
}

// Movie details
export async function getMovieById(id) {
    return api.get(endpoints.MOVIE_BY_ID + id);
}

// Edit movie
export async function updateMovie(id, data) {
    return api.put(endpoints.MOVIE_BY_ID + id, data);
}

// Delete movie
export async function postMovieLike(id, likes) {
    return api.put(endpoints.MOVIE_BY_ID + id, { liked: likes });
}

// Movie like
export async function deleteMovie(id) {
    return api.delete(endpoints.MOVIE_BY_ID + id);
}

export function checkResult(result) {
    if (result.hasOwnProperty('errorData')) {
        const error = new Error();
        Object.assign(error, result);
        throw error;
    }
}