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
        context = data;
        context.user = userData;
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
    console.log(context.user);
    this.partial('/templates/catalog/homePage.hbs', context);

}

export async function deleteShoes() {
    try {
        const result = await deleteById(this.params.id);
        this.redirect('#/home');
    } catch (err) {
        alert(err.message);
    }
}

export async function detailsPage() {
    await addPartials(this);

    const result = await getById(this.params.id);
    const context = {
        user: this.app.userData,
        shoe: result,
        canEdit: result._ownerId == getUserId()
    }
    // console.log(shoe._ownerId);
    // console.log(getUserId());
    //console.log(context);

    this.partial('/templates/catalog/detailsPage.hbs', context);
}

export async function editPage(id) {
    await addPartials(this);

    const shoe = await getById(this.params.id);
    if (shoe._ownerId !== getUserId()) {
        this.redirect('#/home');
    } else {
        const context = {
            user: this.app.userData,
            shoe
        }
        shoe.name.replace(" ", '&nbsp;');
        console.log(context)
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
    const { name, price, imageUrl, description, brand } = ctx.params;
    const buyers = "";

    console.log(ctx.params);

    try {
        if (name.length == 0 || price.length == 0 || imageUrl.length == 0 || description.length == 0 || brand.length == 0) {
            throw new Error('All fields are required!');
        } else if (!ctx.app.userData) {
            throw new Error('You must be logged in to make purchase!');
        } else {
            const result = await editArticle(ctx.params.id, { name, price, imageUrl, description, brand, buyers });
            ctx.redirect('#/home');
        }
    } catch (err) {
        alert(err.message);
    }
}