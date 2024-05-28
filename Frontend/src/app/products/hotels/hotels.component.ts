import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Observable, catchError, debounceTime, distinctUntilChanged, filter, of, startWith, switchMap } from 'rxjs';
import { HotelsService } from '../../core/services/data/hotels.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'ai-hotels',
  templateUrl: './hotels.component.html',
  styleUrls: ['./hotels.component.scss']
})
export class HotelsComponent implements OnInit {
  form: FormGroup;
  filteredOptions: Observable<any[]>;
  submitted = false;
  searchResult = []
  constructor(private hotelService: HotelsService, private formBuilder: FormBuilder, private toastr: ToastrService ) {
    
  }
  ngOnInit(): void {
    this.form = this.formBuilder.group({
      location: ['', [Validators.required]],
      fromDate: ['', [Validators.required]],
      toDate: ['', [Validators.required]],
      sortBy: ['price', [Validators.required]],
    });

    this.form.get('location')!.valueChanges.pipe(
      debounceTime(800),
      filter(value => typeof value === 'string'), // Proceed only if the value is a string
      switchMap(value => this.handleHotelAutoComplete(value)),
      catchError(error => {
        // console.error('Error occurred:', error);
        this.toastr.error('There was an error, please type atleast 2 characters');
        return of([]);
      })
    ).subscribe(data => {
      this.filteredOptions = of(data);
    });

  }


  handleHotelAutoComplete(value: any): Observable<any[]> {

    if (!value) {
      return of([]); // Return observable of empty array if no value
    } else if (value.length < 2) {
      this.toastr.info(`Please type atleast 2 characters`);
      return of([]); // Return observable of empty array if no value
    } else {
      // Replace with your actual API URL
      return this.hotelService.autoComplete(typeof value === 'string' ? value : value.dest_id).pipe(
        catchError(error => {
          console.error('Error occurred:', error);
          return of([]);
        })
  
      )
    }
  }

  displayFn(option: any): string {
    return option && option.label ? option.label : '';
  }

  get f() { return this.form.controls; }

  onSubmit() {
    this.submitted = true;
   

    if (this.form.invalid){
      return;
    }
    else{
      this.hotelService.search(this.f['location'].value['dest_id']      , 
      this.f['fromDate'].value,
      this.f['toDate'].value, this.f['sortBy'].value).subscribe(
        response => {
          if(response.result !== null && response.result.length > 0){
            if (this.f['sortBy'].value == 'popularity') {
              this.searchResult = response.result.sort(function(a, b){return b.review_score-a.review_score});
            } else {
              this.searchResult = response.result.sort(function(a, b){return a.price_breakdown.gross_price - b.price_breakdown.gross_price});
            }
          }
          else{
            this.searchResult = []
          }
          
        })
    }
  }
}