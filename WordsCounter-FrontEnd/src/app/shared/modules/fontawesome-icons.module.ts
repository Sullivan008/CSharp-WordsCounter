import { NgModule } from '@angular/core';

import { FaIconLibrary } from '@fortawesome/angular-fontawesome';
import { faChevronDown, faChevronUp } from '@fortawesome/free-solid-svg-icons';

@NgModule({})
export class FontAwesomeIconsModule {
  constructor(library: FaIconLibrary) {
    library.addIcons(faChevronDown, faChevronUp);
  }
}
