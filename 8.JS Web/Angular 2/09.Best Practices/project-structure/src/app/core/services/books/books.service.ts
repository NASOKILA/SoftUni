import { Injectable } from "@angular/core";
import { Book } from "../../models/view-models/book.view.model";

@Injectable()
export class BooksService {
  private books : Book[] = [ 
    new Book(1, "First Book", "First Author", 12, "Nice Description"),
    new Book(2, "Second Book", "Second Book", 60, "Very cool description"),
    new Book(3, "Third Book", "Third Author", 123, "Description")
  ];

  getAll() : Book[] {
    return this.books;
  }

  getById(id : number) : Book {
    return this.books.find(b => b.id === id);
  }
}