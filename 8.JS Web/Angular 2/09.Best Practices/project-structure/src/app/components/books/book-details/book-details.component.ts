import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from "@angular/router";
import { Book } from '../../../core/models/view-models/book.view.model';
import { BooksService } from '../../../core/services/books/books.service';

@Component({
  templateUrl: './book-details.component.html'
})

export class BookDetailsComponent implements OnInit {
  public book : Book;

  constructor(
    private route : ActivatedRoute,
    private booksService : BooksService
  ) { }

  ngOnInit() {
    let id : number = Number(this.route.snapshot.params["id"]);
    
    this.book = this.booksService.getById(id);
  }
}