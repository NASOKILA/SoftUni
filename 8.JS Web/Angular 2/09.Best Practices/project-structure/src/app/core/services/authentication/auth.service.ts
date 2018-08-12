import { Injectable } from "@angular/core";
import { LoginInputModel } from "../../models/input-models/login.input.model";
import { HttpClientService } from "../http-client.service";
import { Router } from "@angular/router";

@Injectable()
export class AuthService {
  public redirectUrl : string;

  constructor(
    private httpService : HttpClientService,
    private router : Router
  ) { }

  login(loginModel : LoginInputModel) : void {
    // this.httpService.post()
  }

  register() : void {

  }

  logout() : void {

  }

  isLoggedIn() : boolean {
    return false;
  }

  tryNavigate() {
    if (this.redirectUrl) {
      this.router.navigate([this.redirectUrl]);
    } else {
      this.router.navigate([""]);
    }
  }
}