import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { 
  AccountsClient, 
  AccountDTO, 
  CreateAccountRequest, 
  UpdateAccountRequest, 
  GetAccountsResponse, 
  ICreateAccountRequest, 
  IUpdateAccountRequest, 
} from './api.client';

@Injectable({
  providedIn: 'root'
})
export class AccountsService {

  constructor(@Inject(AccountsClient) private client: AccountsClient) { }

  getList(roleType): Observable<AccountDTO[]> {
    return this.client.getAccounts(roleType)
      .pipe(map((result: GetAccountsResponse) => {
        if (result)
          return result.accounts;

        return [];
      }));
  }

  createAccount(request: ICreateAccountRequest): Observable<boolean> {
    return this.client.createAccount(new CreateAccountRequest(request))
      .pipe(map((result) => {
        return true;
      }));
  }

  updateAccount(id: number, requestData: IUpdateAccountRequest): Observable<boolean> {
    return this.client.updateAccount(id, new UpdateAccountRequest(requestData))
      .pipe(map((result) => {
        return true;
      }));
  }

  deleteAccount(id: number): Observable<boolean>{
    return this.client.deleteAccount(id)
      .pipe(map((result) => {
        return true;
      }));
  }
}
