import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../../core/services/authentication/auth.service';

@Component({
  templateUrl: './login-form.component.html'
})
export class LoginFormComponent implements OnInit {
  constructor(private authService : AuthService) { }

  ngOnInit() { 
  }

  onSubmit() {
    /// Log in User
    this.authService.tryNavigate();
  }
}