import { beginRequest, endRequest } from './notofocation.js';

function host(endpoint) {
    return `https://api.backendless.com/86A5F958-32F7-ECB1-FF4C-4F443615C900/CD074802-0601-46DD-871E-FDCFF39A29D5/${endpoint}`;
}

const endpoints = {
    REGISTER: 'users/register',
    LOGIN: 'users/login',
    LOGOUT: 'users/logout',
    MOVIES: 'data/movies',
    MOVIE_BY_ID: 'data/movies/',
};

export async function register(username, password) {
    beginRequest();
    const result = (await fetch(host(endpoints.REGISTER), {
        method: "POST",
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({
            username,
            password
        }),
    })).json();

    endRequest();

    return result;
}

export async function login(username, password) {
    beginRequest();

    const result = (await fetch(host(endpoints.LOGIN), {
        method: "POST",
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({
            login: username,
            password
        }),
    })).json();

    localStorage.setItem('userToken', result['user-token']);
    localStorage.setItem('username', result.username);
    localStorage.setItem('userId', result.onjectId);

    endRequest();

    return result;
}

export async function logout() {
    beginRequest();

    const token = localStorage.getItem('userToken');
    localStorage.removeItem('userToken');

    const result = await fetch(host(endpoints.LOGOUT), {
        headers: {
            'user-token': token
        }
    });

    endRequest();
    return result;
}


// get all movies
export async function getMovies() {
    const token = localStorage.getItem('userToken');

    if (token) {
        beginRequest();

        const result = (await fetch(host(endpoints.MOVIES), {
            headers: {
                'user-token': token
            }
        })).json();

        endRequest();
        return result;
    }
}

// get movie by ID
export async function getMoviesById(id) {
    const token = localStorage.getItem('userToken');

    if (token) {
        beginRequest();

        const result = (await fetch(host(endpoints.MOVIE_BY_ID + id), {
            headers: {
                'user-token': token
            }
        })).json();

        endRequest();
        return result;
    }
}

// create movie
export async function createMovie(movie) {
    const token = localStorage.getItem('userToken');

    if (token) {
        beginRequest();

        const result = (await fetch(host(endpoints.MOVIES), {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'user-token': token
            },
            body: JSON.stringify(movie)
        })).json();

        endRequest();
        return result;
    }
}

// edit movie
export async function updateMovie(id, updatedProps) {
    const token = localStorage.getItem('userToken');

    if (token) {
        beginRequest();

        const result = (await fetch(host(endpoints.MOVIE_BY_ID + id), {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
                'user-token': token
            },
            body: JSON.stringify(updatedProps)
        })).json();

        endRequest();
        return result;
    }
}


// delete movie
export async function deleteMovie(id) {
    const token = localStorage.getItem('userToken');

    if (token) {
        beginRequest();

        const result = (await fetch(host(endpoints.MOVIE_BY_ID + id), {
            method: 'DELETE',
            headers: {
                'Content-Type': 'application/json',
                'user-token': token
            }
        })).json();

        endRequest();
        return result;
    }
}

// get movies by userID
export async function getMoviesByOwner(ownerId) {
    const token = localStorage.getItem('userToken');

    if (token) {
        // return (await fetch(host(endpoints.MOVIES + `?where=ownerId${escape(='ownerId')}`), {
        beginRequest();

        const result = (await fetch(host(endpoints.MOVIES + `?where=ownerId%3D%27${ownerId}%27`), {
            headers: {
                'Content-Type': 'application/json',
                'user-token': token
            }
        })).json();

        endRequest();
        return result;
    }
}


// buy ticket
export async function buyTicket(movie) {
    const newTickets = movie.tickets - 1;
    const movieId = movie.objectId;
    beginRequest();
    return updateMovie(movieId, { tickets: newTickets });
    endRequest();
}