import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '@environments/environment';
import { Observable } from 'rxjs';
import { IPagedResults, IProduct } from 'src/app/shared/interfaces';
import { StorageService } from '../storage.service';

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  productBaseUrl =
    environment.apiBaseUrl + '/api/v' + environment.apiVersion + '/product';

  constructor(
    private httpClient: HttpClient,
    private storageService: StorageService
  ) {
    console.log(storageService.getFromLocalStorage('jwt'));
  }

  getAll(
    pageNumber: number,
    pageSize: number
  ): Observable<IPagedResults<IProduct>> {
    const parames = new HttpParams()
      .set('pageNumber', pageNumber)
      .set('pageSize', pageSize);

    return this.httpClient.get<IPagedResults<IProduct>>(this.productBaseUrl, {
      params: parames,
    });
  }

  create(data: IProduct) {
    return this.httpClient.post(this.productBaseUrl, data);
  }

  getById(id: number): Observable<IProduct> {
    return this.httpClient.get<IProduct>(`${this.productBaseUrl}/${id}`);
  }

  update(id: number, product: IProduct): Observable<IProduct> {
    return this.httpClient.put<IProduct>(
      `${this.productBaseUrl}/${id}`,
      product
    );
  }

  delete(id: number): Observable<void> {
    return this.httpClient.delete<void>(`${this.productBaseUrl}/${id}`);
  }
}
