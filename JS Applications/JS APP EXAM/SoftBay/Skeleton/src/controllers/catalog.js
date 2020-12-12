import { showError, showInfo } from '../notofocation.js';
import { getAll, createOffer, getById, editOffer, deleteById } from "../data.js";
import { addPartials, addOffersToArray, getUserId } from "../util.js";

export async function homePage() {

    if (window.location.pathname == "/index.html") {
        window.location.href = '/';
    }

    await addPartials(this);
    const context = {};

    context.user = this.app.userData;
    console.log(context);

    this.partial('/templates/catalog/homePage.hbs', context);
}


export async function dashboardPage() {

    if (window.location.pathname == "/index.html") {
        window.location.href = '/';
    }

    await addPartials(this);
    const data = addOffersToArray(await getAll());


    const context = data;

    context.user = this.app.userData;
    

    //console.log(context);
    // console.log(context._ownerId);
    // console.log(getUserId());
    this.partial('/templates/catalog/dashboardPage.hbs', context);
}



export async function deleteOffer() {
    await addPartials(this);

    const offer = await getById(this.params.id);
    if (offer._ownerId !== getUserId()) {
        this.redirect('#/home');
    } else {
        const context = {
            user: this.app.userData,
            offer: offer
        }

        this.partial('/templates/catalog/deletePage.hbs', context);
    }
}

export async function detailsPage() {
    await addPartials(this);

    const offer = await getById(this.params.id);
    const context = {
        user: this.app.userData,
        offer: offer
    }

    this.partial('/templates/catalog/detailsPage.hbs', context);
}

export async function editPage(id) {
    await addPartials(this);

    const offer = await getById(this.params.id);
    if (offer._ownerId !== getUserId()) {
        this.redirect('#/home');
    } else {
        const context = {
            user: this.app.userData,
            offer: offer
        }

        this.partial('/templates/catalog/editPage.hbs', context);
    }
}


export async function createPage() {
    await addPartials(this);

    const context = {
        user: this.app.userData
    }

    this.partial('/templates/catalog/createPage.hbs', context);
}


export async function postEdit(ctx) {
    const { product, description, price, pictureUrl } = ctx.params;

    try {
        if (product.length == 0) {
            throw new Error('Product field is required!');
        }
        else if (description.length == 0) {
            throw new Error('Description field is required!');
        }
        else if (price.length == 0) {
            throw new Error('Price field is required!');
        }
        else if (pictureUrl.slice(0, 8) !== 'https://') {
            throw new Error('The image URL should start with "https://".');
        } else {
            const result = await editOffer(ctx.params.id, { product, description, price, pictureUrl });
            showInfo('Your offer was edited successfully!')
            ctx.redirect('#/dashboard');
        }
    } catch (err) {
        showError(err.message);
    }
}

export async function postCreate(ctx) {
    const { product, description, price, pictureUrl } = ctx.params;

    try {
        if (product.length == 0) {
            throw new Error('Product field is required!');
        }
        else if (description.length == 0) {
            throw new Error('Description field is required!');
        }
        else if (price.length == 0) {
            throw new Error('Price field is required!');
        }
        else if (pictureUrl.slice(0, 8) !== 'https://') {
            throw new Error('The image URL should start with "https://".');
        } else {
            const result = await createOffer({ product, description, price, pictureUrl });
            showInfo('Your offer was created successfully!')
            ctx.redirect('#/dashboard');
        }
    } catch (err) {
        showError(err.message);
    }
}

export async function postDelete(ctx) {
    try {
        const result = await deleteById(ctx.params.id);
        showInfo('Your offer was deleted!')
        ctx.redirect('#/dashboard');
    } catch (err) {
        showError(err.message);
    }
}
