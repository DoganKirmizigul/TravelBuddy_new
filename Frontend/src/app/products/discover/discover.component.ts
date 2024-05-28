import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from 'src/app/core/services/data/account.service';

@Component({
  selector: 'ai-discover',
  templateUrl: './discover.component.html',
  styleUrls: ['./discover.component.scss']
})
export class DiscoverComponent implements OnInit {

  constructor(private accountService: AccountService, private toastr: ToastrService) { }

  data: any;
  isLoading = true;

  ngOnInit(): void {
    this.accountService.getDiscover().subscribe(
      response => {
        this.data = response;
        this.isLoading = false;
      })
  }

}