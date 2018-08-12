import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-template-driven-forms',
  templateUrl: './template-driven-forms.component.html',
  styleUrls: ['./template-driven-forms.component.css']
})
export class TemplateDrivenFormsComponent implements OnInit {

  model : any;
  constructor() {
    this.model = {
      "email" : "",
      "password" : "",
    }
   }
  
  login(formData){
      console.log(formData.value);
  }

  ngOnInit() {
    console.log(this.model)
  }

}
