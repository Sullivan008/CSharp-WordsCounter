import { Subscription } from 'rxjs';
import { filter } from 'rxjs/operators';
import { Title } from '@angular/platform-browser';
import { Component, OnDestroy } from '@angular/core';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';

import { DEFAULT_BROWSER_TAB_TITLE } from './core/constants/browser-data/browser-data.constants';

import { RouterDataModel } from './core/router/models/router-data.model';
import { BrowserTitleDataModel } from './core/router/models/browser-title-data.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnDestroy {
  private subscriptions: Subscription[] = [];

  public constructor(private router: Router, private activatedRoute: ActivatedRoute, private titleService: Title) {
    this.subscriptions.push(
      this.router.events.pipe(filter(event => event instanceof NavigationEnd)).subscribe(() => {
        const activatedRoute = this.getActivatedRoute(this.activatedRoute);

        activatedRoute.data.subscribe((data: RouterDataModel) => {
          const browserTitleData: BrowserTitleDataModel = data.browserTitle;

          this.titleService.setTitle(browserTitleData?.name ?? DEFAULT_BROWSER_TAB_TITLE);
        });
      })
    );
  }

  public ngOnDestroy(): void {
    this.subscriptions.forEach(x => x.unsubscribe());
  }

  private getActivatedRoute(activatedRoute: ActivatedRoute): ActivatedRoute {
    if (activatedRoute.firstChild) {
      return this.getActivatedRoute(activatedRoute.firstChild);
    } else {
      return activatedRoute;
    }
  }
}
