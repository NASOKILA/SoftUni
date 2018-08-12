import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControlName, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-reactive-forms',
  templateUrl: './reactive-forms.component.html',
  styleUrls: ['./reactive-forms.component.css']
})

export class ReactiveFormsComponent implements OnInit {

  form = new FormGroup({
    "currentPassword": new FormControl('', [Validators.required, Validators.minLength(3), Validators.maxLength(6)]),
    "newPassword": new FormControl('', [Validators.required, Validators.minLength(3), Validators.maxLength(6)]),
    "confirmPassword": new FormControl('', [Validators.required, Validators.minLength(3), Validators.maxLength(6)])
  })
  
  currentPass = "123";
  constructor() { }

  ngOnInit() {
  }

  log(){
    if(this.form.get('currentPassword').value !== this.currentPass){
      alert("Current password is wrong !")
    }
    else if(this.form.get("newPassword").value !== this.form.get("confirmPassword").value){
      console.log()
      alert("Passwords don't match !")      
    }
    else {
      this.currentPass = this.form.get("newPassword").value;
      console.log(this.currentPass)
      alert("Current Password is changed susseccfully !");
    }
  }
}