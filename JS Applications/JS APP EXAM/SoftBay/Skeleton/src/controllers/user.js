import { showError, showInfo } from '../notofocation.js';

import { register, login, getProductBuyById, editProductBuyById, createProduct } from "../data.js";
import { addPartials, clearUserData, getUserId } from "../util.js";

export async function registerPage() {
    await addPartials(this);
    this.partial('/templates/user/registerPage.hbs');
}

export async function logoutPage() {
    clearUserData();
    this.app.userData = null;
    this.redirect('#/home');
}

export async function loginPage() {
    await addPartials(this);
    this.partial('/templates/user/loginPage.hbs');
}

export async function postRegister(ctx) {
    const { email, password, repeatPassword } = ctx.params;

    try {
        if (email.length == 0 || password.length == 0) {
            throw new Error('All fields are required!');
        } else if (password != repeatPassword) {
            throw new Error('Password don\'t match!');
        } else {
            const result = await register(email, password);
            ctx.app.userData = result;
            showInfo('Registration successful!')
            ctx.redirect('#/home');
        }
    } catch (err) {
        showError(err.message);
    }
}


export async function postLogin(ctx) {
    const { email, password } = ctx.params;

    try {
        if (email.length == 0 || password.length == 0) {
            throw new Error('All fields are required!');
        } else {
            const result = await login(email, password);
            ctx.app.userData = result;
            showInfo('Logged in successfully!')
            ctx.redirect('#/home');
        }
    } catch (err) {
        showError(err.message);
    }
}


export async function profilePage(ctx) {
    try {
        await addPartials(this);

        const context = {
            user: this.app.userData
        }

        this.partial('/templates/user/profilePage.hbs', context);
    } catch (err) {
        showError(err.message);
    }
}

export async function buyPage(ctx) {
    try {
        const resultBuy = await getProductBuyById(getUserId());
        console.log(resultBuy)
        if (resultBuy && resultBuy.boughtProducts) {
            resultBuy.boughtProducts = resultBuy.boughtProducts + 1;
            const editBuy = await editProductBuyById(getUserId());
        } else {
            createBuy = await createProduct();;
        }

        showInfo(`Product ${ctx.product} successfully bought!`)
    } catch (err) {
        showError(err.message);
    }
}