import { Observable } from 'rxjs';
import { Component } from '@angular/core';

import { WordsCounterService } from '../../../services/words-counter.service';

import { BasicDataModel } from '../../../models/basic-data.model';

@Component({
  selector: 'words-counter-basic-data',
  templateUrl: './basic-data.component.html',
  styleUrls: ['./basic-data.component.scss'],
})
export class BasicDataComponent {
  //#region GETTERS

  public get basicData$(): Observable<BasicDataModel> {
    return this.wordsCounterService.basicData$;
  }

  //#endregion

  public constructor(private wordsCounterService: WordsCounterService) {}
}
