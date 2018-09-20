import { Component, OnInit } from '@angular/core';
import { UserService } from '../user.service';
import { AuthService } from '../../auth/auth.service';
import  * as $  from 'jquery';
import { ToastrService } from '../../../../../node_modules/ngx-toastr';
import { Router } from '../../../../../node_modules/@angular/router';

@Component({
  selector: 'app-changepassword',
  templateUrl: './changepassword.component.html',
  styleUrls: ['./changepassword.component.css',
  '../../../app.animations.css', 
  '../../../app.transitions.css', 
  '../../../app.keyframes.css']
})
export class ChangepasswordComponent implements OnInit {

  constructor(
    private userService : UserService,
    private authService : AuthService,
    private toastr: ToastrService,
    private router: Router
  ) { }

  ngOnInit() {
  }

  sendEmail(){
  
      this.userService.changePassword(this.authService.username)
      .then(data => {

        console.log("EMAIL SENT")
        
        $(".reset-password-btn").fadeOut();
        
        $(".reset-pass-email-sent").fadeIn();
        
        this.toastr.success('Email sent successfully!', 'Success!');

        this.authService.logout()
        .toPromise()
        .then(() => {
          this.authService.authtoken = null;
          this.authService.email = null;
          this.authService.role = null;
          this.authService.username = null;
          localStorage.clear();
  
          this.router.navigate(['/auth/login']);
          this.toastr.success('Logout successfull!', 'Success!');
        }).catch(err => this.toastr.error(err.error.error, 'Error!'));

      })
      .catch(err => console.log(err))
  }
}
