import { BooksListComponent } from "./books-list/books.list.component";
import { BookDetailsComponent } from "./book-details/book-details.component";

export const bookRoutes = [
  { path: '',  component: BooksListComponent },
  { path: 'details/:id', component: BookDetailsComponent }
]