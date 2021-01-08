import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ValidationErrors, Validators } from '@angular/forms';

function passwordMatch(c: AbstractControl): ValidationErrors | null {
  return c.value.password === c.value.repeatPassword ? null : { passwordMatch: true };
}

@Component({
  selector: 'app-register-reactive-form',
  templateUrl: './register-reactive-form.component.html',
  styleUrls: ['./register-reactive-form.component.css']
})
export class RegisterReactiveFormComponent implements OnInit {
  registerForm: FormGroup;

  constructor(fb: FormBuilder) {
    this.registerForm = fb.group({
      fullName: ['', [Validators.required]],
      email: ['', [Validators.required, Validators.email]],
      phone: ['', [Validators.required]],
      ext: ['+971', [Validators.required]],
      role: ['', [Validators.required]],
      passwords: fb.group({
        password: ['', [Validators.required]],
        repeatPassword: ['', [Validators.required]],
      }, { validators: [passwordMatch] })
      // addresses: fb.array([fb.group({}), fb.group({})])
    });
  }

  ngOnInit(): void {
  }

  loginHandler(){
    console.log(this.registerForm.value)
  }
}
