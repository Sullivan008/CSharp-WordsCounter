import { debounceTime } from 'rxjs/operators';
import { Observable, Subscription } from 'rxjs';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup } from '@angular/forms';

import { WordsCounterService } from '../services/words-counter.service';

import { KeywordDensityItem } from '../models/keyword-density-item.model';
import { GetBasicDataRequestModel } from '../models/request-models/get-basic-data-request.model';
import { GetTextAnalysisDataRequestModel } from '../models/request-models/get-text-analysis-data-request.model';
import { GetKeywordDensityDataRequestModel } from '../models/request-models/get-keyword-density-data-request.model';

@Component({
  selector: 'app-main-module',
  templateUrl: './words-counter.component.html',
  styleUrls: ['./words-counter.component.scss'],
})
export class WordsCounterComponent implements OnInit, OnDestroy {
  private subscriptions: Subscription[] = [];

  public inputForm: FormGroup;

  //#region GETTERS

  public inputText(): AbstractControl {
    return this.inputForm.get('inputText');
  }

  public get topKeywordDensityData(): Observable<KeywordDensityItem[]> {
    return this.wordsCounterService.topKeywordDensityData$;
  }

  public get allKeywordDensityData(): Observable<KeywordDensityItem[]> {
    return this.wordsCounterService.allKeywordDensityData$;
  }

  //#endregion

  public constructor(private wordsCounterService: WordsCounterService) {}

  public ngOnInit(): void {
    this.inputForm = new FormGroup({
      inputText: new FormControl(null),
    });

    this.subscriptions.push(
      this.inputText()
        .valueChanges.pipe(debounceTime(300))
        .subscribe(text => {
          this.wordsCounterService.getBasicData({ inputText: text } as GetBasicDataRequestModel);

          this.wordsCounterService.getTextAnalysisData({ inputText: text } as GetTextAnalysisDataRequestModel);

          this.wordsCounterService.getKeywordDensityData({ inputText: text } as GetKeywordDensityDataRequestModel);
        })
    );
  }

  public ngOnDestroy(): void {
    this.subscriptions.forEach(x => x.unsubscribe());
  }
}
