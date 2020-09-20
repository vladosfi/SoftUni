import commonPartial from './partials.js';
import { registerUser, login, logout } from '../models/user.js';
import { saveUserInfo, setHeader } from './auth.js';

export function getLogin(ctx) {
    setHeader(ctx);
    ctx.loadPartials(commonPartial).partial('../view/user/login.hbs');
}

export function getRegister(ctx) {
    setHeader(ctx);
    ctx.loadPartials(commonPartial).partial('../view/user/register.hbs');
}

export function getProfile(ctx) {
    setHeader(ctx);
    ctx.loadPartials(commonPartial).partial('../view/user/profile.hbs');
}

export function postRegister(ctx) {
    const { username, password, rePassword } = ctx.params;
    //console.log(ctx);

    if (password !== rePassword) {
        throw new Error('Password dont match!');
        return;
    }

    registerUser(username, password)
        .then(res => {
            //console.log(res.user.email);
            saveUserInfo(res.user.email);
            notify('Registration successfull!', '#successBox');
            ctx.redirect('#/home');
        })
        .catch(e => notify(e.message, '#errorBox'));
}

export function postLogin(ctx) {
    const { username, password } = ctx.params;
    login(username, password)
        .then(res => {
            saveUserInfo(res.user.email);
            ctx.redirect('#/home');
        })
        .catch(e => notify(e.message, '#errorBox'));
}

export function getLogout(ctx) {
    logout()
        .then(res => {
            sessionStorage.clear();
            notify('Successfully logedout!', '#successBox');
            ctx.redirect('#/login');
        })
        .catch(e => notify(e.message, '#errorBox'));
}

function notify(message, selector) {
    const notification = document.querySelector(selector);
    notification.textContent = message;
    notification.addEventListener('click', () => {
        notification.style.display = 'none';
    });

    notification.style.display = 'block';

    setTimeout(() => {
        notification.style.display = 'none';
    }, 5000);
}