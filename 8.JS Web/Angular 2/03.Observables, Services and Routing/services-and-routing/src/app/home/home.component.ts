import { Component, OnInit } from '@angular/core';
import { HomeService } from './homeService';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
  //providers: [HomeService]
})

export class HomeComponent implements OnInit {
  
  public someData: string;
  private homeService : HomeService;
  private gitgubProfileData;
  
  //we inject the dependency for the homeService we have to inject it first
  constructor(homeService:HomeService, private httpClient:HttpClient) {
    this.homeService = homeService;
    this.someData = this.homeService.getData();
   }

  ngOnInit() {
    console.log(this.someData);
  
    //we can catch errors in the subscribe
    this.homeService
      .getGitHubProfile("NASOKILA")
      .subscribe(
        data => { this.gitgubProfileData = data },
        err => { console.log(err) });
  }
}


