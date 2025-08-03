import { ApplicationConfig } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { provideHttpClient, withInterceptors } from '@angular/common/http';
import { provideAuth0, authHttpInterceptorFn } from '@auth0/auth0-angular';

export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(routes),
    provideAnimationsAsync(),
    provideHttpClient(withInterceptors([authHttpInterceptorFn])),
    provideAuth0({
      domain: 'dev-5ryoup5zj6gd68om.us.auth0.com',
      clientId: 'JCQ9zn7mlzRkleQQ02nk5gu99gMrIGnf',
      authorizationParams: {
        redirect_uri: window.location.origin,
        audience: 'https://api.traveltracker.com'
      }
    })
  ]
};
