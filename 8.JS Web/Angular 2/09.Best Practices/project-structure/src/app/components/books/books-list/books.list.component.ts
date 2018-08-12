import { Component, OnInit } from '@angular/core';
import { BooksService } from '../../../core/services/books/books.service';
import { Book } from '../../../core/models/view-models/book.view.model';

@Component({
  templateUrl: './books.list.component.html'
})

export class BooksListComponent implements OnInit {
  public books : Book[];
  
  constructor(
    private booksService : BooksService
  ) { }

  ngOnInit() { 
    this.books = this.booksService.getAll();
  }
}