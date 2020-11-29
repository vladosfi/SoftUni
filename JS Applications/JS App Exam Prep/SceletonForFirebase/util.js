/* globals firebase */
import init from './db-init.js';

export async function extendContext(context) {
    const partials = await Promise.all([
        context.load('./templates/partials/header.hbs'),
        context.load('./templates/partials/footer.hbs')
    ]);

    context.partials = {
        header: partials[0],
        footer: partials[1]
    };
}

export function errorHandler(error) {
    console.log(error);
}

export function saveUserData(data) {
    const { user: { email, uid } } = data;
    localStorage.setItem('user', JSON.stringify({ email, uid }));
}

export function getUserData() {
    const user = localStorage.getItem('user');
    return user ? JSON.parse(user) : null;
}

export function clearUserData() {
    this.localStorage.removeItem('user');
}

init();

export const UserModel = firebase.auth();
export const DB = firebase.firestore();