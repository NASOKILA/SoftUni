import { Injectable } from '@angular/core';

//we need it for the requests
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { Movies } from '../models/movies';
import { Movie } from '../models/movie';


const apiKey : string = '6bdd1cfe28af911694df7f2bbef53d9f';

@Injectable({
  providedIn: 'root'
})
export class MoviesService {

  private path: string = 'https://api.themoviedb.org/3/';
  private popular: string = 'discover/movie?sort_by=popularity.desc';
  private inTheaters: string = 'discover/movie?primary_release_date.gte=2014-09-15&primary_release_date.lte=2014-10-22';
  private kids: string = 'discover/movie?certification_country=US&certification.lte=G&sort_by=popularity.desc';
  private dramas: string = 'discover/movie?with_genres=18&sort_by=vote_average.desc&vote_count.gte=10';
  
  private authentication: string = '&api_key=';
  private movie: string = 'movie/';
  private movieAuth: string = '?api_key=';

  constructor(private http : HttpClient) {}

  getPopular() : Observable<Movies> {
    return this.http.get<Movies>(this.path + this.popular + this.authentication + apiKey);
  }  

  getTheaters() : Observable<Movies> {
    return this.http.get<Movies>(this.path + this.inTheaters + this.authentication + apiKey);
  }
  
  getKids() : Observable<Movies> {
    return this.http.get<Movies>(this.path + this.kids + this.authentication + apiKey);
  }

  getDramas() : Observable<Movies> {
    return this.http.get<Movies>(this.path + this.dramas + this.authentication + apiKey);
  }

  getMovie(id:string) {
    return this.http.get<Movie>(this.path + this.movie + id + this.movieAuth + apiKey)
  }

  findAMovie(search) {
    console.log(search.search)
    return this.http.get('https://api.themoviedb.org/3/search/movie?query=' + search.search +'&api_key='+ apiKey);
  }

}
