import { Component, OnInit } from '@angular/core';
import { AccountService } from 'src/app/core/services/data/account.service';
import { FormControl, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'ai-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {
  emailFormControl = new FormControl({ value: '', disabled: true }, [
  ]);
  firstNameFormControl = new FormControl('', [
    Validators.required,
    Validators.minLength(2),
  ]);
  lastNameFormControl = new FormControl('', [
    Validators.required,
    Validators.minLength(2),
  ]);

  constructor(private accountService: AccountService, private toastr: ToastrService, private router: Router) {  
  }

  ngOnInit(): void {
    this.accountService.getUser().subscribe(
      response => {
        this.emailFormControl.setValue(response.data.email);
        this.firstNameFormControl.setValue(response.data.firstName);
        this.lastNameFormControl.setValue(response.data.lastName);
        console.log(response);
      })
  }
  save() {

    const data = {
      email: this.emailFormControl.value,
      firstName: this.firstNameFormControl.value,
      lastName: this.lastNameFormControl.value,
    };

    this.accountService
      .saveUser(data)
      .subscribe((response) => {
        this.router.navigate(['products/profile']);
      }, (error) => {
        this.toastr.error(`${error.error.Message}`);              

        // console.error('Registration failed', error);
        // Handle error, such as displaying an error message to the user
      });
  }  

}
