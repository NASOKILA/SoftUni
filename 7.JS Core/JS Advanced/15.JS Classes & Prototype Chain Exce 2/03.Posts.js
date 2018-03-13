


function solve() {

    class Post {
        constructor(title, content) {
            this.title = title;
            this.content = content;
        }

        toString() {
            return `Post: ${this.title}\nContent: ${this.content}`;
        }
    }

    class SocialMediaPost extends Post {
        constructor(title, content, likes, dislikes) {
            super(title, content);
            this.likes = Number(likes);
            this.dislikes = Number(dislikes);
            this.comments = [];
        }

        addComment(comment) {
            this.comments.push(comment);
        }

        toString() {
            let result = `${super.toString()}\nRating: ${this.likes - this.dislikes}`;

            if(this.comments.length > 0)
                result += `\nComments:`;

            for (let comm of this.comments) {
                result += `\n * ${comm}`;
            }
            return result;
        }
    }

    class BlogPost extends Post {
        constructor(title, content, views) {
            super(title, content);
            this.views = Number(views);
        }

        view() {
            this.views++;
            return this;
        }

        toString() {
            return `${super.toString()}\nViews: ${this.views}`;
        }

    }

    return { Post, SocialMediaPost, BlogPost }
}


/*
let result = solve();

let post = new result.Post("Post", "Content");

console.log(post.toString());

// Post: Post
// Content: Content

let scm = new result.SocialMediaPost("TestTitle", "TestContent", 25, 30);

scm.addComment("Good post");
scm.addComment("Very good post");
scm.addComment("Wow!");

console.log(scm.toString());

// Post: TestTitle
// Content: TestContent
// Rating: -5
// Comments:
//  * Good post
//  * Very good post
//  * Wow!
*/


/*
let classes = solve();

let test = new classes.SocialMediaPost("TestTitle", "TestContent", 5, 10);

test.addComment("1");
test.addComment("2");
test.addComment("3");

console.log(test.toString());

console.log();

let test2 = new classes.SocialMediaPost("TestTitle", "TestContent", 5, 10);
console.log(test2.toString());
*/



let classes = solve();
let test = new classes.BlogPost("TestTitle", "TestContent", 5);
test.view().view().view();
console.log(test.toString());
