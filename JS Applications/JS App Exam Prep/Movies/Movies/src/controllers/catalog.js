import { getAll, createMovie, getById, editMovie, deleteById } from "../data.js";
import { addPartials, mapCategories, getUserId } from "../util.js";
import { showError, showInfo, beginRequest, endRequest } from '../notofocation.js';

export async function homePage() {
    await addPartials(this);
    this.partials.article = await this.load('/templates/catalog/homePage.hbs');

    beginRequest();
    const data = mapCategories(await getAll());
    //const data = await getAll();
    endRequest();

    const context = data;

    // const context = {
    //     js: [
    //         {
    //             title: 'Article1',
    //             category: 'JavaScript',
    //             content: 'Lorem ipsum ',
    //         },
    //         {
    //             title: 'Article2',
    //             category: 'JavaScript',
    //             content: 'Lorem ipsum ',
    //         }
    //     ],
    //     java: [
    //         {
    //             title: 'Article1',
    //             category: 'Java',
    //             content: 'Lorem ipsum ',
    //         }
    //     ],
    // }

    context.user = this.app.userData;
    //console.log(context);
    this.partial('/templates/catalog/homePage.hbs', context);
}

export async function deleteMovie() {
    try {
        const result = await deleteById(this.params.id);
        this.redirect('#/home');
    } catch (err) {
        showError(err.message);
        //alert(err.message);
    }
}

export async function likePage() {

    const { title, description, likes } = await getById(this.params.id);
    likes.push(this.app.userData.email);

    //const result = await editMovie(movie._id, { movie.likes });
    const result = await editMovie(this.params.id, { title, description, likes });


    this.redirect('#/details/' + this.params.id);

    showInfo('Liked successfully');
}

export async function detailsPage() {
    await addPartials(this);

    const movie = await getById(this.params.id);
    movie.likesCount = movie.likes.length - 1;
    const context = {
        user: this.app.userData,
        movie: movie,
        canEdit: movie._ownerId == getUserId(),
        canLike: !movie.likes.includes(this.app.userData.email),
    }
    // console.log(movie._ownerId);
    console.log(context);

    this.partial('/templates/catalog/detailsPage.hbs', context);
}

export async function editPage(id) {
    await addPartials(this);

    const movie = await getById(this.params.id);
    if (movie._ownerId !== getUserId()) {
        this.redirect('#/home');
    } else {
        const context = {
            user: this.app.userData,
            movie
        }

        this.partial('/templates/catalog/editPage.hbs', context);
    }
}


export async function createPage() {
    await addPartials(this);

    const context = {
        user: this.app.userData
    }

    if (context.user) {
        this.partial('/templates/catalog/createPage.hbs', context);
    } else {
        this.redirect('#/home');
    }
}

export async function postCreate(ctx) {
    const { title, description, imageUrl } = ctx.params;
    const creator = getUserId();
    const likes = [''];

    try {
        if (title.length == 0 || description.length == 0 || imageUrl.length == 0) {
            throw new Error('All fields are required!');
        } else if (creator === null) {
            throw new Error('User must be logged in!');
        } else {
            const result = await createMovie({ title, description, imageUrl, likes });
            ctx.redirect('#/home');
            showInfo('Created successfully!');
        }
    } catch (err) {
        showError(err.message);
        //alert(err.message);
    }
}

export async function postEdit(ctx) {
    const { title, description, imageUrl } = ctx.params;

    try {
        if (title.length == 0 || description.length == 0 || imageUrl.length == 0) {
            throw new Error('All fields are required!');
        } else {
            const result = await editMovie(ctx.params.id, { title, description, imageUrl });
            ctx.redirect('#/details/' + ctx.params.id);
        }
    } catch (err) {
        showError(err.message);
        //alert(err.message);
    }
}