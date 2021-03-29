import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

import { GetBasicDataRequestModel } from '../models/request-models/get-basic-data-request.model';
import { GetBasicDataResponseModel } from '../models/response-models/get-basic-data-response.model';
import { GetTextAnalysisDataRequestModel } from '../models/request-models/get-text-analysis-data-request.model';
import { GetTextAnalysisDataResponseModel } from '../models/response-models/get-text-analysis-data-response.model';
import { GetKeywordDensityDataRequestModel } from '../models/request-models/get-keyword-density-data-request.model';
import { GetKeywordDensityDataResponseModel } from '../models/response-models/get-keyword-density-data-response.model';

@Injectable({
  providedIn: 'root',
})
export class WordsCounterHttpService {
  private readonly _baseUrl: string;

  constructor(private http: HttpClient) {
    this._baseUrl = `${environment.apiUrl}/v1/WordsCounter`;
  }

  public getBasicData(requestModel: GetBasicDataRequestModel): Observable<GetBasicDataResponseModel> {
    const requestUrl: string = `${this._baseUrl}/GetBasicData`;

    return this.http.post<GetBasicDataResponseModel>(requestUrl, requestModel);
  }

  public getTextAnalysisData(
    requestModel: GetTextAnalysisDataRequestModel
  ): Observable<GetTextAnalysisDataResponseModel> {
    const requestUrl: string = `${this._baseUrl}/GetTextAnalysisData`;

    return this.http.post<GetTextAnalysisDataResponseModel>(requestUrl, requestModel);
  }

  public getKeywordDensityData(
    requestModel: GetKeywordDensityDataRequestModel
  ): Observable<GetKeywordDensityDataResponseModel> {
    const requestUrl: string = `${this._baseUrl}/GetKeywordDensityData`;

    return this.http.post<GetKeywordDensityDataResponseModel>(requestUrl, requestModel);
  }
}
