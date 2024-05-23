import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Observable, catchError, debounceTime, filter, of, switchMap } from 'rxjs';
import { RentalService } from '../../core/services/data/rental.service';

@Component({
  selector: 'ai-rental',
  templateUrl: './rental.component.html',
  styleUrls: ['./rental.component.scss']
})
export class RentalComponent implements OnInit {
  form: FormGroup;
  filteredFromOptions: Observable<any[]>;
  filteredToOptions: Observable<any[]>;
  submitted = false;
  searchResult = []

  

  constructor(private rentalService: RentalService, private formBuilder: FormBuilder) { }
  
  ngOnInit(): void {
    this.form = this.formBuilder.group({
      from: ['', [Validators.required]],
      to: ['', [Validators.required]],
      fromDate: ['', [Validators.required]],
      toDate: ['', [Validators.required]],
    });

    this.form.get('from')!.valueChanges.pipe(
      debounceTime(800),
      filter(value => typeof value === 'string'), // Proceed only if the value is a string
      switchMap(value => this.handleFromAutoComplete(value)),
      catchError(error => {
        console.error('Error occurred:', error);
        return of([]);
      })
    ).subscribe(data => {
      this.filteredFromOptions = of(data);
    });

    this.form.get('to')!.valueChanges.pipe(
      debounceTime(600),
      filter(value => typeof value === 'string'), // Proceed only if the value is a string
      switchMap(value => this.handleToAutoComplete(value)),
      catchError(error => {
        console.error('Error occurred:', error);
        return of([]);
      })
    ).subscribe(data => {
      this.filteredToOptions = of(data);
    });


  }

  handleFromAutoComplete(value: any): Observable<any[]> {

    if (!value) {
      return of([]); // Return observable of empty array if no value
    }
    // Replace with your actual API URL
    return this.rentalService.autoComplete(typeof value === 'string' ? value : value.id)
  }

  handleToAutoComplete(value: any): Observable<any[]> {

    if (!value) {
      return of([]); // Return observable of empty array if no value
    }
    // Replace with your actual API URL
    return this.rentalService.autoComplete(typeof value === 'string' ? value : value.id)
  }

  displayFn(option: any): string {
    return option && option.name ? option.name : '';
  }

  get f() { return this.form.controls; }

  onSubmit() {
    this.submitted = true;
   

    if (this.form.invalid){
      return;
    }
    else{
      this.rentalService.search(this.f['from'].value['id'], 
      this.f['to'].value['id'],
      this.f['fromDate'].value,
      this.f['toDate'].value).subscribe(
        response => {
          if(response.data !== null && response.data.search_results !== null && response.data.search_results.length > 0){
            this.searchResult = response.data.search_results
          }
          else{
            this.searchResult = []
          }
          
        })
    }
  }

}
