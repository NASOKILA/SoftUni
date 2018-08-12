import { Component, OnInit, Input } from '@angular/core';
import { Movie } from '../models/movie';

@Component({
  selector: 'app-movieModel',
  templateUrl: './model.component.html',
  styleUrls: ['./model.component.css']
})

export class ModelComponent implements OnInit {
  
  //input variable `movie` which waits for the father component to pass it a value
  @Input('movie') movie : Movie;
  constructor() { }

  ngOnInit() { }

}
