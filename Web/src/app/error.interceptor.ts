import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import {NotificationService} from './notification.service';
import { Injectable } from '@angular/core';
@Injectable()
export class ErrorInterceptor implements HttpInterceptor  {
    
    constructor(private notificationService: NotificationService ) {
    }
    intercept(request: HttpRequest<any>, next: HttpHandler):  Observable<HttpEvent<any>> {
        return next.handle(request).pipe(
            retry(1),
            catchError((error : HttpErrorResponse) => {
                let errorMessage = '';
                if (error.error instanceof ErrorEvent) {
                    errorMessage = `Error= ${error.error.message}`;
                }
                else{
                    errorMessage = `Error code= ${error.status}\nMessage= ${error.message}`;
                    
                }
                this.notificationService.showError(errorMessage , 'Error');
                
                
                return throwError(errorMessage);
            })
        )
    }
    
}