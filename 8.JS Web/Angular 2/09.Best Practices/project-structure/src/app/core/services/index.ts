import { AuthService } from './authentication/auth.service';
import { HttpClientService } from './http-client.service';
import { BooksService } from './books/books.service';

export const allServices = [ AuthService, HttpClientService, BooksService ]