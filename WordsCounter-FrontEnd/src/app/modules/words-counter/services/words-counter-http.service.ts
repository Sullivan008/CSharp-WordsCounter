import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

import { GetBasicDataRequestModel } from '../models/request-models/get-basic-data-request.model';
import { GetBasicDataResponseModel } from '../models/response-models/get-basic-data-response.model';

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
}
