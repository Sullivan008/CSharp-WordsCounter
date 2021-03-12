import { NgModule } from '@angular/core';
import { ToastrModule } from 'ngx-toastr';
import { CommonModule } from '@angular/common';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppRoutingModule } from '../app-routing.module';
import { AccordionModule } from 'ngx-bootstrap/accordion';
import { BrowserModule, Title } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RibbonToastrComponent } from '../shared/utilities/ribbon-toastr/container/ribbon-toastr.component';

import { ErrorHandlerInterceptor } from './error-handler/interceptors/error-handler.interceptor';

@NgModule({
  imports: [
    CommonModule,
    AppRoutingModule,
    BrowserModule,
    BrowserAnimationsModule,
    AccordionModule.forRoot(),
    ToastrModule.forRoot({
      positionClass: 'toast-top-right',
      toastComponent: RibbonToastrComponent,
    }),
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ErrorHandlerInterceptor,
      multi: true,
    },
    Title,
  ],
})
export class CoreModule {}
