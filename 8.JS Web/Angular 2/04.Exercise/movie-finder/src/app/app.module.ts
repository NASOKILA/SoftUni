import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { MoviesComponent } from './movies/movies.component';
import { NavigationComponent } from './navigation/navigation.component';

import { MoviesService } from './service/movies.service';
import { HttpClientModule } from '@angular/common/http';
import { ModelComponent } from './model/model.component';
import { MovieComponent } from './movie/movie.component';

import { RouterModule } from "@angular/router";
import { FormsModule } from "@angular/forms";
import { AboutComponent } from './about/about.component';

//import { HttpModule } from '@angular/http';
//this is older

@NgModule({
  declarations: [
    AppComponent,
    MoviesComponent,
    NavigationComponent,
    ModelComponent,
    MovieComponent,
    AboutComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot([
      {path: '', component: MoviesComponent},
      {path: 'movie/:id', component: MovieComponent},
      {path: 'about', component: AboutComponent},
    ]),
    FormsModule
  ],
  providers: [MoviesService],
  bootstrap: [AppComponent]
})
export class AppModule { }
