import { Component, OnInit } from '@angular/core';
import { MoviesService } from '../service/movies.service';
import { Movie } from '../models/movie';
import { Movies } from '../models/movies';

@Component({
  selector: 'app-movies',
  templateUrl: './movies.component.html',
  styleUrls: ['./movies.component.css']
})
export class MoviesComponent implements OnInit {

  public popular : Movies;
  public theaters : Movies;
  public kids : Movies;
  public dramas : Movies;
  public moviesFound : any;
  public isSearch : boolean;

  constructor(private moviesService : MoviesService) { }

  search(myQuery){

    if(myQuery.search.length > 0){
  
      this.moviesService
      .findAMovie(myQuery)
      .subscribe(data => {
        this.moviesFound = data; 
        console.log(this.moviesFound); 
        this.isSearch = true
        
      })
    }
  }

  ngOnInit() {
    //we subscribe  
    this.moviesService
    .getPopular()
    .subscribe(data => {this.popular = data})

    this.moviesService
    .getTheaters()
    .subscribe(data => {this.theaters = data})

    this.moviesService
    .getKids()
    .subscribe(data => {this.kids = data})

    this.moviesService
    .getDramas()
    .subscribe(data => {this.dramas = data})
  }

}