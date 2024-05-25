import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { AccountService } from 'src/app/core/services/data/account.service';
import { FormControl, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import * as $ from 'jquery'; // I faced issue in using jquery's popover

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

  @ViewChild("INSPIRO") firstChild: ElementRef;

  adminData: any;
  
  constructor(private accountService: AccountService, private toastr: ToastrService, private router: Router) {  

  }

  ngOnInit(): void {
    this.accountService.getAdmin().subscribe(
      response => {
        this.adminData = response;
        // console.log(response);

        var win = window as any;
        win.INSPIRO.elements.counters();
      })
  }


}