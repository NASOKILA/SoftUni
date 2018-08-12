import { Component, OnInit } from '@angular/core';
import { RegisterModel } from '../models/register.model';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  
  public model: RegisterModel;
  public error : Boolean;
  public errorMessage : String;

  constructor(private authService: AuthService, private router : Router) {
    this.model = new RegisterModel("", "", "", "", "", 18);
    this.error = false;
    this.errorMessage = "";
  }

  ngOnInit() {
  }

  register() {
    //we delete the confirmPassword property from the model cause we dont need it anymore 
    //and for kinvey we dont want to have an extra property which we dont need.
    //delete this.model['confirmPassword'];

    this.authService
      .register(this.model)
      .toPromise()
      .then((res : any) => {
        console.log("REGISTERED")
        console.log(res)

      
        //redirect to home page, it wants an array
        this.router.navigate([
          '/login'
        ]);

      }).catch(err => {
        console.log("ERROR")
        console.log(err);
        this.error = true; 
        this.errorMessage = err.error.description; 
      });
  }
}
