import { showInfo, showError } from '../notofocation.js'
import { createMovie, getMovies, buyTicket as apiBuyTicket, getMoviesByOwner, getMoviesById, updateMovie, deleteMovie as apiDelete } from '../data.js';

export default async function catalog() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
        movie: await this.load('./templates/movie/movie.hbs'),
        controls: await this.load('./templates/movie/movieControls.hbs'),
    };

    const search = this.params.search || '';
    const movies = await getMovies(search);
    this.app.userData.movies = movies;

    const context = Object.assign({ origin: encodeURIComponent('#/catalog'), search }, this.app.userData)

    this.partial('./templates/movie/catalog.hbs', context);
}

export async function create() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
    };

    this.partial('./templates/movie/create.hbs', this.app.userData);
}

export async function myMovies() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
        movie: await this.load('./templates/movie/movie.hbs'),
        controls: await this.load('./templates/movie/ownMovieControls.hbs'),
        movieControls: await this.load('./templates/movie/movieControls.hbs'),
    };

    const movies = await getMoviesByOwner();

    this.app.userData.movies = movies;

    const context = Object.assign({ myMovies: true, origin: encodeURIComponent('#/my_movies') }, this.app.userData);

    this.partial('./templates/movie/catalog.hbs', context);
}


export async function createPost() {
    try {
        if (this.params.title.length === 0) {
            throw new Error('Title required');
            return;
        }

        const movie = {
            title: this.params.title,
            description: this.params.description,
            image: this.params.image,
            genres: this.params.genres,
            tickets: Number(this.params.tickets),
        }

        const result = await createMovie(movie);

        if (result.hasOwnProperty('errorData')) {
            const error = new Error();
            Object.assign(error, result);
            throw error;
        }

        showInfo('Movie created');
        this.redirect('#/details/' + result.objectId);
    } catch (err) {
        //alert(err.message);
        showError(err.message);
    }
}

export async function details() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
    };

    const movieId = this.params.id;
    let movie = this.app.userData.movies.find(m => m.objectId == movieId);
    if (movie === undefined) {
        movie = await getMoviesById(movieId);
    }

    const context = Object.assign({ movie, origin: encodeURIComponent('#/details/' + movieId) }, this.app.userData);
    this.partial('./templates/movie/details.hbs', context);
}

export async function edit() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
    };

    const movieId = this.params.id;

    let movie = this.app.userData.movies.find(m => m.objectId == movieId);
    if (movie === undefined) {
        movie = await getMoviesById(movieId);
    }

    const context = Object.assign({ movie }, this.app.userData)
    this.partial('./templates/movie/edit.hbs', context);
}

export async function editPost() {
    const movieId = this.params.id;

    try {
        if (this.params.title.length === 0) {
            throw new Error('Title required');
            return;
        }

        let movie = {
            title: this.params.title,
            description: this.params.description,
            image: this.params.image,
            genres: this.params.genres,
            tickets: Number(this.params.tickets),
        }

        const result = await updateMovie(movieId, movie);

        if (result.hasOwnProperty('errorData')) {
            const error = new Error();
            Object.assign(error, result);
            throw error;
        }

        for (let i = 0; i <= this.app.userData.movies.length - 1; i++) {
            if (this.app.userData.movies[i].objectId == movieId) {
                this.app.userData.movies.splice(i, 1, result);
            }
        }

        showInfo('Movie edited');
        this.redirect('#/details/' + result.objectId);
    } catch (err) {
        //alert(err.message);
        showError(err.message);
    }
}

export async function buyTicket() {
    const movieId = this.params.id;
    let movie = this.app.userData.movies.find(m => m.objectId == movieId);

    if (movie === undefined) {
        movie = await getMoviesById(movieId);
    }

    try {
        if (movie.tickets < 0) {
            showInfo('No available tickets');
            return;
        }

        const result = await apiBuyTicket(movie);

        if (result.hasOwnProperty('errorData')) {
            const error = new Error();
            Object.assign(error, result);
            throw error;
        }

        this.redirect(this.params.origin);
        showInfo(`Bought ticket for ${movie.title}`);
    } catch (err) {
        //alert(err.message);
        showError(err.message);
    }
}

export async function deleteMovie() {

    if (confirm('Are you shure you want to delete this movie?') == false) {
        return this.redirect('#/my_movies');
    }

    const movieId = this.params.id;
    let movie = this.app.userData.movies.find(m => m.objectId == movieId);

    try {
        const result = await apiDelete(movieId);

        if (result.hasOwnProperty('errorData')) {
            const error = new Error();
            Object.assign(error, result);
            throw error;
        }


        showInfo(`Movie ${movie.title} deleted`);
        this.redirect('#/my_movies');
    } catch (err) {
        //alert(err.message);
        showError(err.message);
    }
}