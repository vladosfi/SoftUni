import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoaderComponent } from './loader/loader.component';
import { AsideComponent } from './aside/aside.component';
import { EmailValidatorDirective } from './email-validator.directive';
import { ShortenTextPipe } from './shorten-text.pipe';
import { TimeDiffPipe } from './time-diff.pipe';



@NgModule({
  declarations: [
    LoaderComponent,
    AsideComponent,
    EmailValidatorDirective,
    ShortenTextPipe,
    TimeDiffPipe
  ],
  imports: [
    CommonModule
  ],
  exports:[
    LoaderComponent,
    AsideComponent,
    EmailValidatorDirective,
    ShortenTextPipe,
    TimeDiffPipe
  ]
})
export class SharedModule { }
