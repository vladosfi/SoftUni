import { register, login } from "../data.js";
import { addPartials, clearUserData } from "../util.js";

export async function registerPage() {
    await addPartials(this);
    this.partial('/templates/user/registerPage.hbs');
}

export async function logoutPage(){
    clearUserData();
    this.app.userData = null;
    this.redirect('#/home');
}

export async function loginPage() {
    await addPartials(this);
    this.partial('/templates/user/loginPage.hbs');
}

export async function postRegister(ctx) {
    const { email, password, rePass } = ctx.params;

    try {
        if (email.length == 0 || password.length == 0) {
            throw new Error('All fields are required!');
        } else if (password != rePass) {
            throw new Error('Password don\'t match!');
        } else {
            const result = await register(email, password);
            ctx.app.userData = result;
            ctx.redirect('#/home');
        }
    } catch (err) {
        alert(err.message);
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
            ctx.redirect('#/home');
        }
    } catch (err) {
        alert(err.message);
    }
}