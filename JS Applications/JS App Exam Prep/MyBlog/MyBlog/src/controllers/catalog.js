import { getAll, createArticle, getById, editArticle, deleteById } from "../data.js";
import { addPartials, mapCategories, categoryMap, getUserId } from "../util.js";

export async function homePage() {
    if (window.location.pathname == "/index.html") {
        window.location.href = '/'; 
     }

    await addPartials(this);

    const data = mapCategories(await getAll());
    const context = data;

    context.user = this.app.userData;

    console.log(context);

    this.partial('/templates/catalog/homePage.hbs', context);
}

export async function deleteArticle() {
    try {
        const result = await deleteById(this.params.id);
        this.redirect('#/home');
    } catch (err) {
        alert(err.message);
    }
}

export async function detailsPage() {
    await addPartials(this);

    const post = await getById(this.params.id);
    const context = {
        user: this.app.userData,
        post: post,
        canEdit: post._ownerId == getUserId()
    }
    // console.log(article._ownerId);
    // console.log(getUserId());

    this.partial('/templates/catalog/detailsPage.hbs', context);
}

export async function editPage(id) {
    await addPartials(this);

    const post = await getById(this.params.id);
    if (post._ownerId !== getUserId()) {
        this.redirect('#/home');
    } else {
        const context = {
            user: this.app.userData,
            post: post
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

export async function postCreate(ctx) {
    const { title, category, content } = ctx.params;

    try {
        if (title.length == 0 || category.length == 0 || content.length == 0) {
            throw new Error('All fields are required!');
        } else {
            const result = await createArticle({ title, category, content });
            ctx.redirect('#/home');
        }
    } catch (err) {
        alert(err.message);
    }
}

export async function postEdit(ctx) {
    const { title, category, content } = ctx.params;

    try {
        if (title.length == 0 || category.length == 0 || content.length == 0) {
            throw new Error('All fields are required!');
        } else {
            const result = await editArticle(ctx.params.id, { title, category, content });
            ctx.redirect('#/home');
        }
    } catch (err) {
        alert(err.message);
    }
}