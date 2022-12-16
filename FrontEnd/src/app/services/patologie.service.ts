import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { GetPatologieResponse, PatologiaDTO, PatologieClient } from './api.client';

@Injectable({
  providedIn: 'root'
})
export class PatologieService {

  constructor(@Inject(PatologieClient) private client: PatologieClient) { }

  getList(): Observable<PatologiaDTO[]> {
    return this.client.getPatologie()
      .pipe(map((result: GetPatologieResponse) => {
        if (result)
          return result.patologie;

        return [];
      }));
  }
}
