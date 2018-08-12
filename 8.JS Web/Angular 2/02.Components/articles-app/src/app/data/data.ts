
import { data } from '../data/seed';
import { Article } from '../models/article.model';

export class ArticleData {

    //getData() is a function which returns an array of Articles
    getData() : Article [] {

        let articles : Article[] = [];

        //we create an Article for each obj in data.ts file
        for(let i = 0; i < data.length; i++){
            articles[i] = new Article(
                data[i].title, 
                data[i].description,
                data[i].author, data[i].imageUrl);
        }

        //we return the list of articles
        return articles;
    }
}
