import { Component, OnInit } from '@angular/core';
import { LoginRequest } from './login.request';
import { AuthService } from '../auth.service';
import { TokenService } from '../../shared/auth/token.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  vm: LoginRequest = {
    email: 'pero2@peric.com',
    password: 'neki!@!@#2323'
  } as LoginRequest;

  constructor(
    private authService: AuthService,
    private tokenService: TokenService,
    private router: Router,
    private toastr: ToastrService
  ) { }

  ngOnInit(): void {
  }

  onLogin() {
    this.authService.login(this.vm)
      .subscribe(result => {
        this.tokenService.setToken(result.token);
        this.router.navigate(['']);
        // this.tokenService.setUser(result.user);
      }, _ => {
        this.vm.password = '';
        this.toastr.error('Kriva kombinacija emaila/lozinke.');
      })
  }

}
