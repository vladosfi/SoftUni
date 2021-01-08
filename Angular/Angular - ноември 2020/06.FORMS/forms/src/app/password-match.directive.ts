import { Directive } from '@angular/core';
import { AbstractControl, ValidationErrors, Validator, NG_VALIDATORS } from '@angular/forms';
import { passwordMatch } from './validators';

@Directive({
  selector: '[appPasswordMatch][ngModelGroup]',
  providers:[
    {
      provide:NG_VALIDATORS,
      useExisting: PasswordMatchDirective,
      multi: true
    }
  ]
})
export class PasswordMatchDirective implements Validator {

  constructor() { }

  validate(control: AbstractControl): ValidationErrors | null {
    return passwordMatch(control);
  }

}
