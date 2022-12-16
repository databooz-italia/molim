import { Component, OnInit } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { locale as itLocale } from './i18n/it';
import { locale as enLocale } from './i18n/en';


@Component({
  // tslint:disable-next-line
  selector: 'body',
  template: '<router-outlet></router-outlet>'
})
export class AppComponent implements OnInit {
  title = 'CoreUI 2 for Angular 8';
  constructor(
    private router: Router,
    private _translateService: TranslateService
  ) { }

  ngOnInit() {
    this.router.events.subscribe((evt) => {
      if (!(evt instanceof NavigationEnd)) {
        return;
      }
      window.scrollTo(0, 0);
    });

    this._translateService.addLangs(['it']);
    this._translateService.addLangs(['en']);

    let locales = [itLocale, enLocale];

    locales.forEach((l) => {
      this._translateService.setTranslation(l.lang, l.data, true);
    });

    if (localStorage.getItem('defaultLanguage')) {
      this._translateService.setDefaultLang(localStorage.getItem('defaultLanguage'));
      this._translateService.use(localStorage.getItem('defaultLanguage'));
    }
    else {
      this._translateService.setDefaultLang('it');
      this._translateService.use('it');
    }
  }
}
