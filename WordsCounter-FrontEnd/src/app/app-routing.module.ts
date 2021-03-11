import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const appRoutes: Routes = [
  { path: '', redirectTo: 'words-counter', pathMatch: 'full' },
  {
    path: 'words-counter',
    loadChildren: () => import('./modules/words-counter/words-counter.module').then(x => x.WordsCounterModule),
  },
  {
    path: 'page-not-found',
    loadChildren: () => import('./modules/page-not-found/page-not-found.module').then(x => x.PageNotFoundModule),
  },
  { path: '**', redirectTo: 'page-not-found', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(appRoutes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
