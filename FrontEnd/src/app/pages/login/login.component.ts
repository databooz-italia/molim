import { Component } from '@angular/core';

import { navItems } from '../../navigation/navItems';
import { TranslateService } from '@ngx-translate/core';

import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { IAuthenticationRequest } from '../../services/api.client';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  loginForm: FormGroup;
  loginError: string;
  isBusy: boolean;

  constructor(private formBuilder: FormBuilder, private router: Router, private auth: AuthService) {
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  get f() { return this.loginForm.controls; }

  onSubmit() {
    let authReq: IAuthenticationRequest = this.loginForm.value;
    this.isBusy = true;

    this.auth.login(authReq, false)
      .pipe(finalize(() => {
        this.isBusy = false;
      }))
      .subscribe((x) => {
        if (x) {
          this.loginError = "";
          this.router.navigate(['/dashboard']);
        }
      },
        error => {
          console.log(error);
          this.loginForm.get('password').reset();
          this.loginError = error;
        }
      );
    /*
  console.log(this.loginForm.value);
  let val = this.loginForm.value;
  if (val.username == "admin" && val.password == "admin") {
    this.loginError = "";
    this.router.navigate(['/dashboard']);
  }
  else
    this.loginError = "Authentication failed, check your credentials!";
*/
  }
}
