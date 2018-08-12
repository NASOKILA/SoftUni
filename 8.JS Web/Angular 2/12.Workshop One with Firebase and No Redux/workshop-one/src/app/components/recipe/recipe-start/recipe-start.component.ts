import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../auth/auth.service';

@Component({
  selector: 'app-recipe-start',
  templateUrl: './recipe-start.component.html',
  styleUrls: ['./recipe-start.component.css']
})
export class RecipeStartComponent implements OnInit {

  public email : string; 

  constructor(private authService : AuthService) { }

  ngOnInit() {
    this.email = this.authService.currentEmail;
  }

}
