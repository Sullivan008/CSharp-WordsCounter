import { Subscription } from 'rxjs';
import { debounceTime } from 'rxjs/operators';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup } from '@angular/forms';

import { WordsCounterService } from '../services/words-counter.service';

import { GetBasicDataRequestModel } from '../models/request-models/get-basic-data-request.model';

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
        })
    );
  }

  public ngOnDestroy(): void {
    this.subscriptions.forEach(x => x.unsubscribe());
  }
}
