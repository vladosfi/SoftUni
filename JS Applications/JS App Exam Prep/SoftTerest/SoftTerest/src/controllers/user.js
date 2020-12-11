import { showError, showInfo } from '../notofocation.js';
import { register, login } from "../data.js";
import { addPartials, clearUserData } from "../util.js";

export async function registerPage() {
    await addPartials(this);
    this.partial('/templates/user/registerPage.hbs');
}

export async function logoutPage() {
    clearUserData();
    this.app.userData = null;
    this.redirect('#/home');
    showInfo('Logout successful.')
}

export async function loginPage() {
    await addPartials(this);
    this.partial('/templates/user/loginPage.hbs');
}

export async function postRegister(ctx) {
    const { email, password, repeatPassword } = ctx.params;

    try {
        if (email.length < 3 || password.length < 3) {
            throw new Error('The username and password should be at least 3 characters long!');
        } else if (password != repeatPassword) {
            throw new Error('Password don\'t match!');
        } else {
            const result = await register(email, password);
            ctx.app.userData = result;
            showInfo('User registration successful.')
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
            showInfo('Login successful.')
            ctx.redirect('#/home');
        }
    } catch (err) {
        showError(err.message);
    }
}