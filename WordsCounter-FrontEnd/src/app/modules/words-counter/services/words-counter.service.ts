import { map } from 'rxjs/operators';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

import { WordsCounterHttpService } from './words-counter-http.service';

import { BasicDataModel } from '../models/basic-data.model';
import { KeywordDensityItem } from '../models/keyword-density-item.model';
import { TextAnalysisDataModel } from '../models/text-analysis-data.model';

import { GetBasicDataRequestModel } from '../models/request-models/get-basic-data-request.model';
import { GetBasicDataResponseModel } from '../models/response-models/get-basic-data-response.model';
import { GetTextAnalysisDataRequestModel } from '../models/request-models/get-text-analysis-data-request.model';
import { GetTextAnalysisDataResponseModel } from '../models/response-models/get-text-analysis-data-response.model';
import { GetKeywordDensityDataRequestModel } from '../models/request-models/get-keyword-density-data-request.model';
import { GetKeywordDensityDataResponseModel } from '../models/response-models/get-keyword-density-data-response.model';
import { KeywordDensityListItemResponseModel } from '../models/response-models/keyword-density-list-item-response.model';

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

  private textAnalysisDataSubject = new BehaviorSubject<TextAnalysisDataModel>({
    paragraphsCount: 0,
    alphanumericCharactersCount: 0,
    alphaCharactersCount: 0,
    numericCharactersCount: 0,
    uniqueWordsCount: 0,
    shortWordsCount: 0,
    longWordsCount: 0,
  });

  private topKeywordDensityDataSubject = new BehaviorSubject<KeywordDensityItem[]>([]);
  private allKeywordDensityDataSubject = new BehaviorSubject<KeywordDensityItem[]>([]);

  //#region

  public get basicData$(): Observable<BasicDataModel> {
    return this.basicDataSubject.asObservable();
  }

  public get textAnalysisData$(): Observable<TextAnalysisDataModel> {
    return this.textAnalysisDataSubject.asObservable();
  }

  public get topKeywordDensityData$(): Observable<KeywordDensityItem[]> {
    return this.topKeywordDensityDataSubject.asObservable();
  }

  public get allKeywordDensityData$(): Observable<KeywordDensityItem[]> {
    return this.allKeywordDensityDataSubject.asObservable();
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

  public getTextAnalysisData(requestModel: GetTextAnalysisDataRequestModel): void {
    this.wordsCounterHttpService
      .getTextAnalysisData(requestModel)
      .pipe(
        map((response: GetTextAnalysisDataResponseModel) => {
          return {
            paragraphsCount: response.paragraphsCount,
            alphanumericCharactersCount: response.alphanumericCharactersCount,
            alphaCharactersCount: response.alphaCharactersCount,
            numericCharactersCount: response.numericCharactersCount,
            uniqueWordsCount: response.uniqueWordsCount,
            shortWordsCount: response.shortWordsCount,
            longWordsCount: response.longWordsCount,
          } as TextAnalysisDataModel;
        })
      )
      .subscribe((response: TextAnalysisDataModel) => {
        this.textAnalysisDataSubject.next(response);
      });
  }

  public getKeywordDensityData(requestModel: GetKeywordDensityDataRequestModel): void {
    this.wordsCounterHttpService
      .getKeywordDensityData(requestModel)
      .pipe(
        map((response: GetKeywordDensityDataResponseModel) => {
          return response.keywordDensityList.map(
            (item: KeywordDensityListItemResponseModel) =>
              ({
                keyword: item.keyword,
                quantity: item.quantity,
                percentage: item.percentage,
              } as KeywordDensityItem)
          );
        })
      )
      .subscribe((response: KeywordDensityItem[]) => {
        this.topKeywordDensityDataSubject.next(this.getTopKeywordDensityElements(response));

        this.allKeywordDensityDataSubject.next(response);
      });
  }

  private getTopKeywordDensityElements(items: KeywordDensityItem[]): KeywordDensityItem[] {
    const topKeywordDensityItem: number = 10;

    return items.slice(0, topKeywordDensityItem);
  }
}
