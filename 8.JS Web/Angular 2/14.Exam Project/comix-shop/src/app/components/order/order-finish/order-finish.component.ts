import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { OrderService } from '../order.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-order-finish',
  templateUrl: './order-finish.component.html',
  styleUrls: ['./order-finish.component.css',
  '../../../app.animations.css', 
  '../../../app.transitions.css', 
  '../../../app.keyframes.css']
})
export class OrderFinishComponent implements OnInit {

  public orderId: string;
  public buyer: string;
  public comix: string;

  constructor(
    private orderService: OrderService,
    private toastr: ToastrService,
    private route: ActivatedRoute) { }

  ngOnInit() {

    let id = this.route.snapshot.params["id"];

    this.orderService.getOrderById(id)
      .then((selectedOrder: any) => {

        this.orderId = selectedOrder._id;
        this.buyer = selectedOrder.buyer;        
        this.comix = selectedOrder.comix;        
      })
      .catch(err => this.toastr.error(err.responseJSON.error, "Error!"));
  }
}