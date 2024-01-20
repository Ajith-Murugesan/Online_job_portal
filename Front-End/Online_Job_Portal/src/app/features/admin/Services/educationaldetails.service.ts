import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IEducationalDetail } from './Models/IEducationalDetail';
import { environment } from '../../../../environments/environment';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
  providedIn: 'root'
})
export class EducationaldetailsService {

  constructor(private httpClient: HttpClient) {}

  getAllEducationalDetails():Observable<IEducationalDetail[]> {
    return this.httpClient.get<IEducationalDetail[]>(environment.API_endpoints.educationalDetails+"GetAll");
  }

  getEducationalDetails(id:number):Observable<IEducationalDetail> {
    return this.httpClient.get<IEducationalDetail>(environment.API_endpoints.educationalDetails+`GetEducationalDetail/${id}`);
  }
}
