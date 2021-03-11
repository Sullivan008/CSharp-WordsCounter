import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { NgxSpinnerModule } from 'ngx-spinner';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { FontAwesomeIconsModule } from './modules/fontawesome-icons.module';

import { DropDownDirective } from './directives/dropdown.directive';

import { RibbonToastrComponent } from './utilities/ribbon-toastr/container/ribbon-toastr.component';
import { LoadingSpinnerComponent } from './utilities/loading-spinner/container/loading-spinner.component';

@NgModule({
  declarations: [DropDownDirective, RibbonToastrComponent, LoadingSpinnerComponent],
  imports: [RouterModule, ReactiveFormsModule, CommonModule, HttpClientModule, NgxSpinnerModule, FontAwesomeModule],
  exports: [
    RouterModule,
    ReactiveFormsModule,
    CommonModule,
    DropDownDirective,
    NgxSpinnerModule,
    LoadingSpinnerComponent,
    FontAwesomeIconsModule,
    FontAwesomeModule,
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  entryComponents: [RibbonToastrComponent],
})
export class SharedModule {}
