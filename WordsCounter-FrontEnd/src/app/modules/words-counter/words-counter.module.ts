import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { WordsCounterComponent } from './container/words-counter.component';
import { WordsCounterRoutingModule } from './words-counter-routing.module';

@NgModule({
  declarations: [WordsCounterComponent],
  imports: [WordsCounterRoutingModule, SharedModule],
})
export class WordsCounterModule {}
