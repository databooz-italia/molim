import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { VersionClient } from './api.client';

@Injectable({
  providedIn: 'root'
})
export class VersionService {

  constructor(@Inject(VersionClient) private client: VersionClient) { }

  getVersion(): Observable<string> {
    return this.client.getVersion()
      .pipe(map((result: string) => {
        if (result)
          return result;

        return undefined;
      }));
  }

}
