import { Component, OnInit, Input } from '@angular/core';
import { Article } from '../models/article.model';

@Component({
  selector: 'app-article',
  templateUrl: './article.component.html',
  styleUrls: ['./article.component.css']
})
export class ArticleComponent implements OnInit {

  private symbols: number = 250;

 @Input() article : Article;
 @Input() articleDesc : string;

  public descToShow : string;
  public articleDescLen : number;
  public showReadMoreBtn : boolean = true;
  public showHideBtn : boolean = false;
  public imageIsShown : boolean = false;
  public imageButtonTitle : string = "Show Image";

  constructor() { 
    this.articleDescLen = 0;
    this.descToShow = "";
  }

  ngOnInit() {
  }

  readMore(){
    this.articleDescLen += this.symbols;

    if(this.articleDescLen < this.articleDesc.length){
      this.showHideBtn = true;
      this.showReadMoreBtn = false;
      this.descToShow = this.articleDesc.substring(0, this.articleDescLen);    
      console.log(this.descToShow.length)    
    }
    else {
      this.descToShow = this.articleDesc.substring(0, this.articleDescLen);
      console.log(this.descToShow.length)
    }
  }

  toggleImage(){
    this.imageIsShown = !this.imageIsShown;
    this.imageButtonTitle = this.imageButtonTitle === "Show Image" 
      ? "Hide Image" : "Show image";
  }

  hideDesc() : void {
    this.descToShow = "";
    this.articleDescLen = 0;
    this.showReadMoreBtn = true;
    this.showHideBtn = false;
  }

}
