import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { AlgoritmiClient, AlgoritmoDTO, GetAlgoritmiResponse } from './api.client';

@Injectable({
  providedIn: 'root'
})
export class AlgoritmiService {

  constructor(@Inject(AlgoritmiClient) private client: AlgoritmiClient) { }

  getList(): Observable<AlgoritmoDTO[]> {
    return this.client.getAlgoritmi()
      .pipe(map((result: GetAlgoritmiResponse) => {
        if (result)
          return result.algoritmi;

        return [];
      }));
  }
}
