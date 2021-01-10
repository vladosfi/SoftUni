import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';

export function emailValidator(control: AbstractControl): ValidationErrors | null {
    const value = (control.value as string);
    if (!value) { return null; }

    const isValidEmail = /[a-zA-Z\.-]{6,}@\w+\.(com|bg)$/.test(control.value as string);
    return isValidEmail ? null : { emailValidator: true };
}