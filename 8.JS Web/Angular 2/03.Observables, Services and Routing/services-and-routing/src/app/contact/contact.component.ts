import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})

export class ContactComponent implements OnInit {

  constructor(private route : ActivatedRoute) {}

  ngOnInit() {
    //take the prameters information from the route
    this.route.params
      .subscribe(params => console.log(params));
  }

}
