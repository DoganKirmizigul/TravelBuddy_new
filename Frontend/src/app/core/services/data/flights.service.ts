import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '@environments/environment';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FlightsService {
  productBaseUrl =
  environment.apiBaseUrl + '/api/Flight';
  constructor(private httpClient: HttpClient,) { }

  autoComplete(query: string) {
    
    return this.httpClient.get<any>(`${this.productBaseUrl}/auto-complete/?query=${query}`)
    .pipe(
      map(response => response.data) // Extract the 'data' array from the response
    );
  }

  search(from: string, to: any, date:any){
    return this.httpClient.post<any>(`${this.productBaseUrl}/search`, {
      "from": from,
      "to":to,
      "departureDate": date
    })
    .pipe(
      map(response => response) // Extract the 'data' array from the response
    );
  }
}
