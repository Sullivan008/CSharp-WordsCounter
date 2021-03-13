import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { BasicDataComponent } from './container/components/basic-data/basic-data.component';
import { KeywordDensityItemComponent } from './container/components/keyword-density/keyword-density-item/keyword-density-item.component';
import { KeywordDensityComponent } from './container/components/keyword-density/keyword-density.component';
import { TextAnalysisItemComponent } from './container/components/text-analysis/text-analysis-item/text-analysis-item.component';
import { TextAnalysisComponent } from './container/components/text-analysis/text-analysis.component';
import { WordsCounterComponent } from './container/words-counter.component';
import { WordsCounterRoutingModule } from './words-counter-routing.module';

@NgModule({
  declarations: [
    WordsCounterComponent,
    BasicDataComponent,
    TextAnalysisComponent,
    TextAnalysisItemComponent,
    KeywordDensityComponent,
    KeywordDensityItemComponent,
  ],
  imports: [WordsCounterRoutingModule, SharedModule],
})
export class WordsCounterModule {}
