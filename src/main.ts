import { bootstrapApplication } from '@angular/platform-browser';
import { appConfig } from './app/app.config';
import { AppComponent } from './app/app.component';
import { provideHttpClient } from '@angular/common/http';
import { provideRouter } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { importProvidersFrom } from '@angular/core';
import { appRoutes } from './app/app.routes';

/*bootstrapApplication(AppComponent, appConfig)
  .catch((err) => console.error(err));*/

  bootstrapApplication(AppComponent, {
    providers: [
      provideHttpClient(),
      provideRouter(appRoutes)
      //,importProvidersFrom(ReactiveFormsModule)
    ]
  });
