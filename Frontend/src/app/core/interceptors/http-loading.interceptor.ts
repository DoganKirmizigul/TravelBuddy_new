import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpResponse,
  HttpErrorResponse
} from '@angular/common/http';
import { Observable, catchError, finalize, tap, throwError } from 'rxjs';
import { HttpLoadingService } from '../services/data/http-loading.service';
import { ToastrService } from 'ngx-toastr';

@Injectable()
export class HttpLoadingInterceptor implements HttpInterceptor {

  constructor(private loadingService: HttpLoadingService, private toastr: ToastrService) {}

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    this.loadingService.setLoading(true);

    return next.handle(req).pipe(
      tap(event => {
        if (event instanceof HttpResponse) {
          if (event && event.body && event.body.error) {
            this.toastr.error(`${event.body.error}`);
          }
          this.loadingService.setLoading(false);
        }
      }),
      catchError((error: HttpErrorResponse) => {
        this.loadingService.setLoading(false);
        // alert(`HTTP Error: ${error.status} ${error.statusText}`);
        this.toastr.error(`There was an error`);
        return throwError(error);
      }),
      finalize(() => this.loadingService.setLoading(false))
    );
  }
}
