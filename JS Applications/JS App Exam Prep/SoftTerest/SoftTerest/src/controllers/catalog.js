import { showError, showInfo } from '../notofocation.js';

import { getAll, createArticle, getById, editArticle, deleteById } from "../data.js";
import { addPartials, mapCategories, categoryMap, getUserId } from "../util.js";

export async function homePage() {
    if (window.location.pathname == "/index.html") {
        window.location.href = '/';
    }
    const context = {};
    await addPartials(this);
    context.user = this.app.userData;

    this.partial('/templates/catalog/homePage.hbs', context);
}

export async function deleteArticle() {
    try {
        const result = await deleteById(this.params.id);
        showInfo('Idea deleted successfully.')
        this.redirect('#/home');
    } catch (err) {
        showError(err.message);
    }
}

export async function likeArticle() {

    const idea = await getById(this.params.id);
    const likes = idea.likes + 1;
    try {
        if(idea._ownerId != getUserId()){
            const result = await editArticle(this.params.id, { likes });
        }
        this.redirect('#/details/' + this.params.id);

    } catch (err) {
        showError(err.message);
    }
}

export async function detailsPage() {
    await addPartials(this);

    const idea = await getById(this.params.id);
    const context = {
        user: this.app.userData,
        idea: idea,
        canEdit: idea._ownerId == getUserId()
    }
    // console.log(idea._ownerId);
    // console.log(getUserId());

    this.partial('/templates/catalog/detailsPage.hbs', context);
}


export async function createPage() {
    await addPartials(this);

    const context = {
        user: this.app.userData
    }

    this.partial('/templates/catalog/createPage.hbs', context);
}


export async function dashboardPage() {
    if(getUserId()){
        await addPartials(this);

        const data = mapCategories(await getAll());
        const context = data;
    
        context.user = this.app.userData;
    
        this.partial('/templates/catalog/dashboardPage.hbs', context);
    } else{
        this.redirect('#/home');
    }    
}


export async function postCreate(ctx) {
    const { title, description, imageURL } = ctx.params;
    const likes = 0;
    const comments = [];

    try {
        if (title.length < 6 || description.length < 10) {
            throw new Error('All fields are required!');
        } else if (imageURL.slice(0, 7) !== 'http://' && imageURL.slice(0, 8) !== 'https://') {
            throw new Error('The image URL should start with "http://" or "https://".');
        } else {
            const result = await createArticle({ title, description, imageURL, likes, comments });
            showInfo('Idea created successfully.');
            ctx.redirect('#/home');
        }
    } catch (err) {
        showError(err.message);
    }
}