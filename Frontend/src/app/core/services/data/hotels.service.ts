import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '@environments/environment';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HotelsService {
  productBaseUrl =
    environment.apiBaseUrl + '/api/Hotel';
  constructor(private httpClient: HttpClient,) { }

  autoComplete(query: string) {
    
    return this.httpClient.get<any>(`${this.productBaseUrl}/auto-complete/?query=${query}`)
    .pipe(
      map(response => response) // Extract the 'data' array from the response
    );
  }

  search(locationId: string, from: any, to:any){
    return this.httpClient.post<any>(`${this.productBaseUrl}/search`, {
      "locationId": locationId,
      "checkinDate": from,
      "checkoutDate": to
    })
    .pipe(
      map(response => response) // Extract the 'data' array from the response
    );
  }
}
