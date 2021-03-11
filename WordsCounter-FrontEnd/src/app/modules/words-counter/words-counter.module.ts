import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { BasicDataComponent } from './container/components/basic-data/basic-data.component';
import { WordsCounterComponent } from './container/words-counter.component';
import { WordsCounterRoutingModule } from './words-counter-routing.module';

@NgModule({
  declarations: [WordsCounterComponent, BasicDataComponent],
  imports: [WordsCounterRoutingModule, SharedModule],
})
export class WordsCounterModule {}
