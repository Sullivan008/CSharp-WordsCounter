import { Observable } from 'rxjs';
import { Component } from '@angular/core';

import { WordsCounterService } from '../../../services/words-counter.service';

import { TextAnalysisDataModel } from 'src/app/modules/words-counter/models/text-analysis-data.model';

@Component({
  selector: 'words-counter-text-analysis',
  templateUrl: './text-analysis.component.html',
  styleUrls: ['./text-analysis.component.scss'],
})
export class TextAnalysisComponent {
  //#region GETTERS

  public get textAnalysisData$(): Observable<TextAnalysisDataModel> {
    return this.wordsCounterService.textAnalysisData$;
  }

  //#endregion

  public constructor(private wordsCounterService: WordsCounterService) {}
}
