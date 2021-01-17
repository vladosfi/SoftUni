import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HTTP_INTERCEPTORS } from "@angular/common/http";
import { Injectable, Provider } from "@angular/core";
import { Observable } from "rxjs";

import { environment } from '../environments/environment';

@Injectable()
export class AppInterceptor implements HttpInterceptor {
    apiURL = environment.apiUrl;

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        if (!req.url.includes('http://' && 'https://')) {
            req = req.clone({ url: `${this.apiURL}${req.url}`, withCredentials: true });
        }

        return next.handle(req);
    }
}

export const appInterceptorProvider: Provider = {
    provide: HTTP_INTERCEPTORS,
    useClass: AppInterceptor,
    multi: true
}