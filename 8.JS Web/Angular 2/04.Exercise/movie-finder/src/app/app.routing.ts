
import { Routes, RouterModule } from "@angular/router";
import { ModuleWithProviders } from "@angular/core";
import { MoviesComponent } from "./movies/movies.component";
import { MovieComponent } from "./movie/movie.component";
import { AboutComponent } from "./about/about.component";

const routes: Routes = [
    {path: '', component: MoviesComponent},
    {path: 'movie/:id', component: MovieComponent},
    {path: '/about', component: AboutComponent},
];

export let Routing : ModuleWithProviders = RouterModule.forRoot(routes)
    