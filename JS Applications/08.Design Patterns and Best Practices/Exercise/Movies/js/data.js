import { beginRequest, endRequest, showError } from './notofocation.js';
import API from './api.js';

const endpoints = {
    MOVIES: 'data/movies',
    MOVIE_BY_ID: 'data/movies/',
};

const api = new API(
    '86A5F958-32F7-ECB1-FF4C-4F443615C900',
    'CD074802-0601-46DD-871E-FDCFF39A29D5',
    beginRequest,
    endRequest);

export const login = api.login.bind(api);
export const logout = api.logout.bind(api);
export const register = api.register.bind(api);

// get all movies
export async function getMovies(search) {
    if (!search) {
        return api.get(endpoints.MOVIES);
    } else {
        return api.get(endpoints.MOVIES + `?where=${escape(`genres LIKE '%${search}%'`)}`);
    }
}

// get movie by ID
export async function getMoviesById(id) {
    return api.get(endpoints.MOVIE_BY_ID + id);
}

// create movie
export async function createMovie(movie) {
    return api.post(endpoints.MOVIES, movie);
}

// edit movie
export async function updateMovie(id, updatedProps) {
    return api.put(endpoints.MOVIE_BY_ID + id, updatedProps);
}


// delete movie
export async function deleteMovie(id) {
    return api.delete(endpoints.MOVIE_BY_ID + id);
}

// get movies by userID
export async function getMoviesByOwner() {
    const ownerId = localStorage.getItem('userId');

    return api.get(endpoints.MOVIES + `?where=ownerId%3D%27${ownerId}%27`)
}


// buy ticket
export async function buyTicket(movie) {
    const newTickets = movie.tickets - 1;
    const movieId = movie.objectId;

    const result = updateMovie(movieId, { tickets: newTickets });
    return result;
}