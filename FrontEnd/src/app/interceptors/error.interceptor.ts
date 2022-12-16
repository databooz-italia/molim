import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { AuthService } from '../services/auth.service';
import { environment } from '../../environments/environment';
import Swal from 'sweetalert2';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
    constructor(private authenticationService: AuthService, private router: Router, private _translateService: TranslateService) { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(request).pipe(catchError((err: HttpErrorResponse) => {

            if (err.status === 401) {
                Swal.fire({
                    icon: 'error',
                    title: 'Oops...',
                    text: this._translateService.instant('ERRORS.SESSION_OVER')
                });

                // auto logout if 401 response returned from api
                this.authenticationService.removeSession(false);
                this.router.navigate(['/login']);
            }

            if (err instanceof HttpErrorResponse && err.error instanceof Blob && err.error.type === "application/json") {
                // https://github.com/angular/angular/issues/19888
                // When request of type Blob, the error is also in Blob instead of object of the json data

                let error = undefined;

                return new Promise<any>((resolve, reject) => {
                    let reader = new FileReader();
                    reader.onload = (e: Event) => {
                        try {
                            error = JSON.parse((<any>e.target).result);
                            let toThrow = null;

                            if (error.errors.length && error.errors.length > 0) {
                                for (let e of error.errors) {

                                    const errorCode = e.code;
                                    const errorDescription = e.description;

                                    let translatedError = this._translateService.instant('ERRORS.' + errorCode);

                                    Swal.fire({
                                        icon: 'error',
                                        title: 'Oops...',
                                        text: translatedError
                                    });

                                    if (!environment.production && errorDescription && errorDescription != null)
                                        Swal.fire({
                                            icon: 'error',
                                            title: 'Oops...',
                                            text: errorDescription
                                        });

                                    if (toThrow == null)
                                        toThrow = "ERRORS." + errorCode;
                                }
                            }

                            reject(toThrow);
                        } catch (e) {
                            reject(err);
                        }
                    };
                    reader.onerror = (e) => {
                        reject(err);
                    };
                    reader.readAsText(err.error);
                });
            }

            return throwError('ERRORS.Generic');
        }))
    }
}