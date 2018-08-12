import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MoviesService } from '../service/movies.service';
import { Movie } from '../models/movie';

@Component({
  selector: 'app-movie',
  templateUrl: './movie.component.html',
  styleUrls: ['./movie.component.css']
})
export class MovieComponent implements OnInit {

  public movie: Movie; 

  constructor(private route : ActivatedRoute, private MoviesService : MoviesService) { }

  ngOnInit() {
    this.route.params.subscribe((params) => {
      let id = params['id'];
      this.MoviesService.getMovie(id).subscribe(selectedMovie => {
        console.log(selectedMovie)
        this.movie = selectedMovie;
      });
    })
  }

}
