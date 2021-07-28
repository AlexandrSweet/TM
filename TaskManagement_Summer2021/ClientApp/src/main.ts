import { enableProdMode } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { AppModule } from './app/app.module';
import { environment } from './environments/environment';

export function getBaseUrl() {
  return 'https://localhost:44379/';
}



if (environment.production) {
  enableProdMode();
}
//const bootstrap = () => platformBrowserDynamic(providers).bootstrapModule(AppModule);
platformBrowserDynamic().bootstrapModule(AppModule).catch(err => console.error(err));
