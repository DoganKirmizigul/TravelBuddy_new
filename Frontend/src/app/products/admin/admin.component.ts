import { Component, OnInit } from '@angular/core';
import { AccountService } from 'src/app/core/services/data/account.service';
import { FormControl, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'ai-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss']
})
export class AdminComponent implements OnInit {
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

  adminData: any;
  
  constructor(private accountService: AccountService, private toastr: ToastrService, private router: Router) {  

  }

  ngOnInit(): void {
    this.accountService.getAdmin().subscribe(
      response => {
        this.adminData = response;
        console.log(response);
      })
  }


}