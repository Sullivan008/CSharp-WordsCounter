import { map } from 'rxjs/operators';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

import { WordsCounterHttpService } from './words-counter-http.service';

import { BasicDataModel } from '../models/basic-data.model';
import { GetBasicDataRequestModel } from '../models/request-models/get-basic-data-request.model';
import { GetBasicDataResponseModel } from '../models/response-models/get-basic-data-response.model';

@Injectable({
  providedIn: 'root',
})
export class WordsCounterService {
  private basicDataSubject = new BehaviorSubject<BasicDataModel>({
    charactersCount: 0,
    charactersWithoutSpacesCount: 0,
    wordsCount: 0,
    sentencesCount: 0,
  } as BasicDataModel);

  //#region

  public get basicData$(): Observable<BasicDataModel> {
    return this.basicDataSubject.asObservable();
  }

  //#endregion

  public constructor(private wordsCounterHttpService: WordsCounterHttpService) {}

  public getBasicData(requestModel: GetBasicDataRequestModel): void {
    this.wordsCounterHttpService
      .getBasicData(requestModel)
      .pipe(
        map((response: GetBasicDataResponseModel) => {
          return {
            charactersCount: response.charactersCount,
            charactersWithoutSpacesCount: response.charactersWithoutSpacesCount,
            wordsCount: response.wordsCount,
            sentencesCount: response.sentencesCount,
          } as BasicDataModel;
        })
      )
      .subscribe((response: BasicDataModel) => {
        this.basicDataSubject.next(response);
      });
  }
}
