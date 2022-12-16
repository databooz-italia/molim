import { Component } from '@angular/core';

import { navItems } from '../../navigation/navItems';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-dashboard',
  templateUrl: './default-layout.component.html'
})
export class DefaultLayoutComponent {
  showAppSidebar: boolean = true;
  minimized = false;
  public navItemsLocal = [];

  availableLanguages: string[];
  selectedLanguage: string;

  constructor(private _translateService: TranslateService) {
    //DEEP COPY OF OBJECTS
    this.navItemsLocal = JSON.parse(JSON.stringify(navItems));
    this.navItemsLocal.forEach(element => {
      if (element.name)
        element.name = _translateService.instant(element.name);
    });

    this.availableLanguages = _translateService.getLangs();
    this.selectedLanguage = _translateService.currentLang;
  }

  toggleMinimize(e) {
    this.minimized = e;
  }

  onLanguageChange(l) {
    localStorage.setItem('defaultLanguage', l);

    window.location.reload();

    /*
    this._translateService.use(l);
    this._translateService.setDefaultLang(l);    

    this.selectedLanguage = this._translateService.defaultLang;

    this.showAppSidebar = false;

    this.navItemsLocal = JSON.parse(JSON.stringify(navItems));
    this.navItemsLocal.forEach(element => {
      if (element.name)
        element.name = this._translateService.instant(element.name);
    });

    setTimeout(() => {
      this.showAppSidebar = true;
    });
    */
  }
}
