import { Component, OnInit } from '@angular/core';
import { UserService } from '../user.service';
import { UserModel } from '../../../models/user.model';
import { ToastrService } from 'ngx-toastr';
import * as $ from 'jquery';

@Component({
  selector: 'app-user-all',
  templateUrl: './user-all.component.html',
  styleUrls: ['./user-all.component.css',
  '../../../app.animations.css', 
  '../../../app.transitions.css', 
  '../../../app.keyframes.css']
})
export class UserAllComponent implements OnInit {

  users: UserModel[];

  constructor(
    private userService: UserService,
    private toastr: ToastrService) { }

  ngOnInit() {

    this.userService.getAllUsers()
      .then((users) => {

        users.forEach(user => {
          if (user._kmd.hasOwnProperty('roles')) {
            user.role = "Admin";
          }
          else {
            user.role = "User";
          }
        });

        this.users = users;
      })
      .catch(err => this.toastr.error(err.responseJSON.error, 'Error!'));
  }

diasableUser(e,id: string){
  
  let btn = e.target
  
  this.userService.disableUserById(id)
  .then(res => {
    console.log("DISABLED")
    
    $(btn)
    .replaceWith('<a class="disabled btn btn-outline-success tableDataRotate enable-user blocking">Enable</a>');
    
    this.toastr.success('User disabled successfully!', 'Success!');
  
  }).catch(err => {
    console.log("ERROR");
    console.log(err);
  });
}

enableUser(e,id: string){
  
  let btn = e.target;

  this.userService.enableUserById(id)
  .then(res => {
    console.log("ENABLED")
    
    $(btn)
    .replaceWith('<a  class="disabled btn btn-outline-danger tableDataRotate disable-user blocking">Disable</a>')
    
    this.toastr.success('User enabled successfully!', 'Success!');

  }).catch(err => {
    console.log("ERROR");
    console.log(err);
  });
}

}
