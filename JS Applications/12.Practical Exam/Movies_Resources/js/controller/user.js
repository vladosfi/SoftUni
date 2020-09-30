import { showError, showInfo } from '../notifocation.js';
import { register, checkResult, login, logout as apiLogout } from '../data.js';

export async function registerPage() {
    this.partials = {
        header: await this.load('../../templates/common/header.hbs'),
        footer: await this.load('../../templates/common/footer.hbs'),
    }
    this.partial('../../templates/user/register.hbs');
}

export async function loginPage() {
    this.partials = {
        header: await this.load('../../templates/common/header.hbs'),
        footer: await this.load('../../templates/common/footer.hbs'),

    }
    this.partial('../../templates/user/login.hbs');
}


export async function registerPost() {

    try {
        if (this.params.email.length < 1) {
            throw new Error('The email should be feeled');
        }

        if (this.params.password.length < 6) {
            throw new Error('The password should be at least 6 characters long');
        }

        if (this.params.password !== this.params.repeatPassword) {
            throw new Error('The repeat password should be equal to the password');
        }

        const result = await register(
            this.params.email,
            this.params.password);

        checkResult(result);

        showInfo('Successful registration!');

        const loginResult = await login(
            this.params.email,
            this.params.password
        );

        checkResult(loginResult);

        this.app.userData.username = loginResult.username;
        this.app.userData.userId = loginResult.objectId;

        showInfo('Login successful.');

        this.redirect('#/home');

    } catch (err) {
        showError(err.message);
    }
}


export async function loginPost() {
    try {
        const result = await login(
            this.params.email,
            this.params.password
        );

        checkResult(result);

        this.app.userData.username = result.username;
        this.app.userData.userId = result.objectId;

        showInfo('Login successful.');

        this.redirect('#/home');
    } catch (err) {
        showError(err.message);
    }
}

export async function logout() {
    try {
        await apiLogout();

        this.app.userData.username = '';
        this.app.userData.userId = '';
        this.app.userData.names = '';

        showInfo('Successful logout');
        this.redirect('#/home');
    } catch (err) {
        showError(err.message);
    }
}