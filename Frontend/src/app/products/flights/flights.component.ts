import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Observable, catchError, debounceTime, filter, of, switchMap } from 'rxjs';
import { FlightsService } from '../../core/services/data/flights.service';

@Component({
  selector: 'ai-flights',
  templateUrl: './flights.component.html',
  styleUrls: ['./flights.component.scss']
})
export class FlightsComponent implements OnInit {
  form: FormGroup;
  filteredFromOptions: Observable<any[]>;
  filteredToOptions: Observable<any[]>;
  submitted = false;
  searchResult = []


  constructor(private flightService: FlightsService, private formBuilder: FormBuilder) { }
  
  ngOnInit(): void {
    this.form = this.formBuilder.group({
      from: ['', [Validators.required]],
      to: ['', [Validators.required]],
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
    return this.flightService.autoComplete(typeof value === 'string' ? value : value.iataCode).pipe(
      catchError(error => {
        console.error('Error occurred:', error);
        return of([]);
      })
    )
  }

  handleToAutoComplete(value: any): Observable<any[]> {

    if (!value) {
      return of([]); // Return observable of empty array if no value
    }
    // Replace with your actual API URL
    return this.flightService.autoComplete(typeof value === 'string' ? value : value.iataCode).pipe(
      catchError(error => {
        console.error('Error occurred:', error);
        return of([]);
      })
    )
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
      this.flightService.search(this.f['from'].value['iataCode'], 
      this.f['to'].value['iataCode'],
      this.f['toDate'].value).subscribe(
        response => {
          if(response.data !== null && response.data.flights !== null && response.data.flights.length > 0){
            if (this.f['sortBy'].value == 'asc') {
              this.searchResult = response.data.flights.sort(function(a,b) { return a.travelerPrices[0].price.price.value - b.travelerPrices[0].price.price.value})
            } else {
              this.searchResult = response.data.flights.sort(function(a,b) { return b.travelerPrices[0].price.price.value - a.travelerPrices[0].price.price.value})
            }

            
            this.searchResult.map(x => {
              switch (x.bounds[0].segments[0].operatingCarrier.code) {
                case 'AA':
                  x.airlineImage = 'https://www.gotogate.com/system/spa/ibeclient/static/media/AA.9da723fc.png';
                  break;
                case 'UA':
                  x.airlineImage = 'https://cdn.airpaz.com/cdn-cgi/image/w=1024,h=1024,f=webp,fit=scale-down/rel-0275/airlines/201x201/UA.png';
                  break;
                case 'NK':
                  x.airlineImage = 'https://content.spirit.com/a/1679';
                  break;
                case 'BA':
                  x.airlineImage = 'https://cdn.freelogovectors.net/wp-content/uploads/2023/09/british_airways_logo-freelogovectors.net_.png';
                  break;
                case 'VS':
                  x.airlineImage = 'https://i.pinimg.com/564x/0a/2a/12/0a2a12a6df3b43adc555a9e2768bd577.jpg';
                  break;
                case 'Z0':
                  x.airlineImage = 'https://mb.cision.com/Public/21212/0/8cbcf0f7597a0574_800x800ar.png';
                  break;
                default:
                  console.log('Missing logo of airline code=', x.bounds[0].segments[0].operatingCarrier.code, x.bounds[0].segments[0].operatingCarrier.name);
                  break;
              }
            });
          }
          else{
            this.searchResult = []
          }
          
        })
    }
  }

}