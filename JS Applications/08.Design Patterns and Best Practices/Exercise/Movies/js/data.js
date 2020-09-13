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

function getOptions() {
    const token = localStorage.getItem('userToken');

    const options = { headers: {} };

    if (token !== null) {
        options.headers = {
            'user-token': token
        };
    }

    return options;
}

async function get(endpoint) {
    beginRequest();
    const result = await fetch(host(endpoint), getOptions());
    endRequest();

    return result;
}

async function post(endpoint, body) {
    const options = getOptions();
    options.method = 'POST';
    options.headers['Content-Type'] = 'application/json';
    options.body = JSON.stringify(body);

    beginRequest();
    const result = (await fetch(host(endpoint), options)).json();
    endRequest();

    return result;
}

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

    const result = await (await fetch(host(endpoints.LOGIN), {
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
    localStorage.setItem('userId', result.objectId);

    endRequest();

    return result;
}

export async function logout() {
    localStorage.removeItem('userToken');
    return get(endpoints.LOGOUT);
}


// get all movies
export async function getMovies(search) {
    const token = localStorage.getItem('userToken');

    if (token) {
        beginRequest();

        let result;

        if (!search) {
            result = (await fetch(host(endpoints.MOVIES), {
                headers: {
                    'user-token': token
                }
            })).json();
        } else {
            result = (await fetch(host(endpoints.MOVIES + `?where=${escape(`genres LIKE '%${search}%'`)}`), {
                headers: {
                    'user-token': token
                }
            })).json();
        }


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
    return post(endpoints.MOVIES, movie);
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
export async function getMoviesByOwner() {
    const token = localStorage.getItem('userToken');
    const ownerId = localStorage.getItem('userId');

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
    const result = updateMovie(movieId, { tickets: newTickets });
    endRequest();
    return result;
}