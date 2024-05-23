import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '@environments/environment';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RentalService {
  productBaseUrl =
  environment.apiBaseUrl + '/api/Rental';
  constructor(private httpClient: HttpClient) { }

  autoComplete(query: string) {
    
    return this.httpClient.get<any>(`${this.productBaseUrl}/auto-complete/?query=${query}`)
    .pipe(
      map(response => response.data) // Extract the 'data' array from the response
    );
  }

  search(from: string, to: any, pickupDate:any, dropOffDate:any){
    return this.httpClient.post<any>(`${this.productBaseUrl}/search`, {
      "from": from,
      "to":to,
      "pickupDate": pickupDate,
      "dropOffDate": dropOffDate
    })
    .pipe(
      map(response => response) // Extract the 'data' array from the response
    );
  }
}
