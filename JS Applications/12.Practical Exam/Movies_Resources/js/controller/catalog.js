import { showError, showInfo } from '../notifocation.js';
import { checkResult, createMovie, getAll, getMovieById, postMovieLike, updateMovie, deleteMovie } from '../data.js';


export default async function home() {
    this.partials = {
        header: await this.load('../../templates/common/header.hbs'),
        footer: await this.load('../../templates/common/footer.hbs'),
        catalog: await this.load('../../templates/catalog/catalog.hbs'),
    }

    const movies = await getAll();
    const context = Object.assign({ movies }, this.app.userData);

    this.partial('../../templates/home.hbs', context);
}

export async function createPage() {
    this.partials = {
        header: await this.load('../../templates/common/header.hbs'),
        footer: await this.load('../../templates/common/footer.hbs'),
    }

    this.partial('../../templates/catalog/create.hbs', this.app.userData);
}


export async function createPost() {
    if (!(this.params.title && this.params.description && this.params.imageUrl)) {
        showError('Invalid inputs!');
    }

    const movie = {
        name: this.params.title,
        description: this.params.description,
        imageUrl: this.params.imageUrl,
        liked: [],
        ownerId: this.app.userData.userId,
    }

    const result = await createMovie(movie);

    checkResult(result);

    showInfo('Created successfully!');

    this.redirect('#/home');
}

export async function editPage() {
    this.partials = {
        header: await this.load('../../templates/common/header.hbs'),
        footer: await this.load('../../templates/common/footer.hbs'),
    }

    const movie = await getMovieById(this.params.id);
    const context = Object.assign({ movie }, this.app.userData);
    checkResult(movie);

    this.partial('../../templates/catalog/edit.hbs', context);
}

export async function editPost() {
    if (!(this.params.title && this.params.description && this.params.imageUrl)) {
        showError('Invalid inputs!');
    }

    const id = this.params.id;

    const movie = {
        name: this.params.title,
        description: this.params.description,
        imageUrl: this.params.imageUrl,
    }

    const result = await updateMovie(id, movie);

    checkResult(result);

    showInfo('Eddited successfully');

    this.redirect('#/details/' + id);
}

export async function detailsPage() {
    this.partials = {
        header: await this.load('../../templates/common/header.hbs'),
        footer: await this.load('../../templates/common/footer.hbs'),
    }

    const movie = await getMovieById(this.params.id);
    checkResult(movie);

    this.app.userData.canLike = true;
    if(movie.liked && movie.liked.includes(this.app.userData.username)){
        this.app.userData.canLike = false;
    }

    this.app.userData.isOwner = this.app.userData.userId === movie.ownerId
    const context = Object.assign({ movie }, this.app.userData);

    this.partial('../../templates/catalog/details.hbs', context);
}

export async function deleteMovieById(){
    const result = await deleteMovie(this.params.id);
    checkResult(result);

    showInfo('Deleted successfully');
    this.redirect('#/home');
}

export async function like() {
    const result = await getMovieById(this.params.id);

    checkResult(result);
    
    if(result.liked && result.liked.includes(this.app.userData.username)){
        return;
    }

    if(!result.liked){
        result.liked = [];
    }

    result.liked.push(this.app.userData.username);

    await postMovieLike(this.params.id, result.liked);
    showInfo('Liked successfully');
    this.redirect('#/details/' + this.params.id);
}