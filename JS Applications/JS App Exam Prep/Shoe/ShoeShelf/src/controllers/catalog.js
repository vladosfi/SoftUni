import { getAll, createShoe, getById, editArticle, deleteById } from "../data.js";
import { addPartials, mapCategories, categoryMap, getUserId } from "../util.js";

export async function redirectToHome() {
    this.redirect('/');
}

export async function homePage() {
    await addPartials(this);
    this.partials.shoes = await this.load('/templates/catalog/homePage.hbs');

    const userData = this.app.userData;
    let context = {};

    if (userData && userData.email) {
        const data = mapCategories(await getAll());
        context.user = userData;
        context = data;
    }


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

    console.log(context.shoes);
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

    const article = await getById(this.params.id);
    const context = {
        user: this.app.userData,
        article,
        canEdit: article._ownerId == getUserId()
    }
    console.log(article._ownerId);
    console.log(getUserId());

    this.partial('/templates/catalog/detailsPage.hbs', context);
}

export async function editPage(id) {
    await addPartials(this);

    const article = await getById(this.params.id);
    if (article._ownerId !== getUserId()) {
        this.redirect('#/home');
    } else {
        const context = {
            user: this.app.userData,
            article
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
    const { name, price, imageUrl, description, brand } = ctx.params;
    const buyers = "";

    try {
        if (name.length == 0 || price.length == 0 || imageUrl.length == 0 || description.length == 0 || brand.length == 0) {
            throw new Error('All fields are required!');
        } else if (!ctx.app.userData) {
            throw new Error('You must be logged in to make purchase!');
        } else {
            const result = await createShoe({ name, price, imageUrl, description, brand, buyers });
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
        } else if (categoryMap.hasOwnProperty(category) === false) {
            throw new Error('Invalid category!');
        } else {
            const result = await editArticle(ctx.params.id, { title, category, content });
            ctx.redirect('#/home');
        }
    } catch (err) {
        alert(err.message);
    }
}