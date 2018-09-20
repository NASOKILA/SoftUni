import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../auth/auth.service';
import { OrderModel } from '../../../models/order.model';
import { UserService } from '../user.service';
import { OrderService } from '../../order/order.service';
import { ToastrService } from 'ngx-toastr';
import  * as $  from 'jquery';
import { faCoffee } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css',
  '../../../app.animations.css', 
  '../../../app.transitions.css', 
  '../../../app.keyframes.css']
})
export class ProfileComponent implements OnInit {


  myOrders: OrderModel[];
  currentUser : any;

  constructor(
    public authService: AuthService,
    private userService: UserService,
    private orderService: OrderService,
    private toastr: ToastrService,
  ) { }

  ngOnInit(): void {

    this.orderService.getAllOrders()
      .then((orders: any) => {
        
        this.userService.getAllUsers()
          .then((users) => {
            let currentUser = users.filter(
              u => u.username === this.authService.username
                && u.email === this.authService.email)[0];
          
                this.currentUser = currentUser;

            this.myOrders = orders
              .filter(o => o._acl.creator === currentUser._id);

          }).catch(err => this.toastr.error(err.responseJSON.error, "Error!"))

      }).catch(err => this.toastr.error(err.responseJSON.error, "Error!"))
  }

  deleteOrder(id: string) {
    this.orderService.deleteOrder(id)
      .then(() => {
        this.orderService.getAllOrders()
          .then((orders: OrderModel[]) => {

            this.myOrders = orders;
            this.toastr.success("Confirmation email sent successfully!", "Success!");
            
          }).catch(err => this.toastr.error(err.responseJSON.error, 'Error!'))
      }).catch(err => this.toastr.error(err.responseJSON.error, 'Error!'))
  }

  verifyEmail(){
    
    //POST /rpc/:appKey/:username/user-email-verification-initiate HTTP/1.1
    this.userService.verifyEmail(this.authService.username)
    .then(res => {

      console.log("VERIFICATION EMAIL SEND")
      console.log(res)
    })
    .catch(err => {
      console.log("ERROR")
      console.log(err)
    })

    $(".verify-email-btn").fadeOut();
    
    $(".email-verification-message").fadeIn();
    
    this.toastr.success("Order deleted successfully!", "Success!");
  }

}
