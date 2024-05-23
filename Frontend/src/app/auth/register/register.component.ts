import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AccountService } from 'src/app/core/services/data/account.service';
import { IRegister } from 'src/app/shared/interfaces';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'ai-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;

  get email() {
    return this.registerForm.get('email');
  }
  get name() {
    return this.registerForm.get('name');
  }
  get surname() {
    return this.registerForm.get('surname');
  }
  get password() {
    return this.registerForm.get('password');
  }
  get confirmPassword() {
    return this.registerForm.get('confirmPassword');
  }

  constructor(private accountService: AccountService, private router: Router, private toastr: ToastrService) {}

  ngOnInit(): void {
    this.registerForm = new FormGroup(
      {
        name: new FormControl('', [
          Validators.required,
          Validators.minLength(2),
        ]),
        surname: new FormControl('', [
          Validators.required,
          Validators.minLength(2),
        ]),
        email: new FormControl('', [Validators.required, Validators.email]),
        password: new FormControl('', [
          Validators.required,
          Validators.minLength(8),
        ]),
        confirmPassword: new FormControl('', [
          Validators.required,
          Validators.minLength(8),
        ]),
      },
      this.passwordMatchValidator
    );
  }

  passwordMatchValidator(form: FormGroup) {
    if (form.get('password').invalid || form.get('confirmPassword').invalid) {
      return null;
    }
    return form.get('password').value === form.get('confirmPassword').value
      ? null
      : { passwordMismatch: true };
  }

  register() {
    if (this.registerForm.valid) {
      const registerData = <IRegister>{
        firstName: this.registerForm.value.name,
        lastName: this.registerForm.value.surname,
        email: this.registerForm.value.email,
        userName: this.registerForm.value.email, // Assuming email can be used as username
        password: this.registerForm.value.password,
        confirmPassword: this.registerForm.value.confirmPassword,
      };

      this.accountService.register(registerData).subscribe(
        (response) => {
          console.log('Registration successful', response);
          if (response.succeeded) {
            // Handle success, such as displaying a success message or redirecting the user
            this.router.navigate(['/login']);
          } else {
            response.errors.forEach(element => {
              this.toastr.error(`${element}`);              
            });
          }
        },
        (error) => {
          this.toastr.error(`${error.error.Message}`);              

          // console.error('Registration failed', error);
          // Handle error, such as displaying an error message to the user
        }
      );
    } else {
      // Form is invalid, handle accordingly (e.g., display error messages)
    }
  }
}
