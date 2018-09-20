import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../auth/auth.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { UserService } from '../../user/user.service';

@Component({
  selector: 'app-userchange',
  templateUrl: './userchange.component.html',
  styleUrls: ['./userchange.component.css',
  '../../../app.animations.css', 
  '../../../app.transitions.css', 
  '../../../app.keyframes.css']
})
export class UserchangeComponent implements OnInit {

  user: any;

  constructor(
    private authService: AuthService,
    private userService: UserService,
    private router: Router,
    private toastr: ToastrService
  ) { }

  ngOnInit() {

    this.userService.getAllUsers()
      .then(users => {
        let currentUser = users.filter(u => u.email === this.authService.email && u.username === this.authService.username)[0];
        this.user = currentUser;
      })
      .catch(err => {
        console.log(err);
      });

  }

  private validateForm(username: string, email: string) {

    if (username === null || username === "" || username.trim() === "") {
      this.toastr.error('Invalid username input!', "Error!")
      return false;
    }
    else if (email === null || email === "" || email.trim() === "" || !email.includes("@") || !email.includes(".")) {
      this.toastr.error('Invalid email input!', "Error!")
      return false;
    }

    return true;
  }

  updateUser() {

    if (this.validateForm(this.user.username, this.user.email)) {

      this.authService.update(this.user)
        .toPromise()
        .then((data: any) => {

          this.toastr.success('User update successfull!', 'Success!');

          this.authService.authtoken = data._kmd.authtoken;
          this.authService.username = data.username;
          this.authService.email = data.email;
          this.authService.avatarUrl = data.avatarUrl;

          localStorage.setItem('authtoken', this.authService.authtoken);
          localStorage.setItem("username", this.authService.username);
          localStorage.setItem("email", this.authService.email);
          localStorage.setItem("avatar", this.authService.avatarUrl);

          this.router.navigate(['/user/profile']);
        })
        .catch((err) => this.toastr.error(err.error.error, 'Error!'));
    }
  }
}
