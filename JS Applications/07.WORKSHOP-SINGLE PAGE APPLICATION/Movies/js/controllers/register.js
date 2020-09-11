import { showInfo, showError } from '../notofocation.js';
import { register as apiRegister } from '../data.js';

export default async function register() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
        registerForm: await this.load('./templates/user/registerForm.hbs'),
    };

    this.partial('./templates/user/register.hbs', this.app.userData);
}

export async function registerPost() {
    try {
        if (this.params.password !== this.params.repeatPassword) {
            throw new Error('Password should match!');
            return;
        }

        if (this.params.username.length < 3) {
            throw new Error('Username must be atleast 3 characters long!');
            return;
        }

        if (this.params.password.length < 6) {
            throw new Error('Password must be atleast 6 characters long!');
            return;
        }


        const result = await apiRegister(this.params.username, this.params.password);
        if (result.hasOwnProperty('errorData')) {
            const error = new Error();
            Object.assign(error, result);
            throw error;
        }
        showInfo('Successfully registerd!');
        this.redirect('#/login');
    } catch (err) {
        //alert(err.message);
        showError(err.message);
    }
}