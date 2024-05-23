import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HotelsService } from '../../core/services/data/hotels.service';
import { Observable, catchError, debounceTime, distinctUntilChanged, filter, finalize, of, startWith, switchMap, tap } from 'rxjs';
import { FormControl } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'ai-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  isLoading: boolean;

  constructor(private router: Router, private hotelService: HotelsService, private toastr: ToastrService) {

    this.filteredOptions = this.myControl.valueChanges.pipe(
      // wait for a pause in typing
      startWith(''),
      debounceTime(600),
      distinctUntilChanged(),
      filter(value => {
        
        if(typeof value !== 'string'){
          return value.id !== this.myControl.value.id
        }
        return true
      }),
      // use switchMap to cancel previous pending requests
      switchMap(value => this.handleHotelAutoComplete(value)),
      catchError(error => {
        // Handle the error
        // console.error('Error occurred:', error);
        this.toastr.error('There was an error, please type atleast 2 characters');
        return [];
      })
    );
   }
  locations = ['New York', 'Chicago', 'San Francisco'];
  destinations = ['Los Angeles', 'Miami', 'Seattle'];

  myControl = new FormControl();
  hotels = new FormControl();
  rentals = new FormControl();
  flights = new FormControl();
  filteredOptions: Observable<any[]>;

  ngOnInit(): void {
    
  } 

  performSearch(){
    
    this.router.navigate(['products/search-result']);
  }

  handleHotelAutoComplete(value: any):Observable<any[]>{
    
    if (!value) {
      return of([]); // Return observable of empty array if no value
    } else if (value.length < 2) {
      this.toastr.info(`Please type atleast 2 characters`);
      return of([]); // Return observable of empty array if no value
    } else {
      // Replace with your actual API URL
      return this.hotelService.autoComplete(typeof value === 'string' ? value : value.id);
    }
  }

  displayFn(option: any): string {
    
    return option && option.label ? option.name : '';
  }

}
