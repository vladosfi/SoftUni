class Article {
    constructor(title, creator) {
        this.title = title;
        this.creator = creator;
        this._comments = [];
        this._likes = [];
    }

    get likes() {
        if (this._likes.length === 0) {
            return `${this.title} has 0 likes`;
        } else if (this._likes.length === 1) {
            return `${this._likes[0]} likes this article!`;
        } else {
            return `${this._likes[0]} and ${this._likes.length - 1} others like this article!`;
        }
    }

    like(username) {
        if (this._likes.find(u => u === username)) {
            throw new Error('You can\'t like the same article twice!');
        } else if (username === this.creator) {
            throw new Error('You can\'t like your own articles!');
        } else {
            this._likes.push(username);
            return `${username} liked ${this.title}!`;
        }
    }

    dislike(username) {
        if (this._likes.find(u => u === username) === undefined) {
            throw new Error('You can\'t dislike this article!');
        }

        this._likes.splice(this._likes.indexOf(username), 1);
        return `${username} disliked ${this.title}`;
    }

    comment(username, content, id) {
        const comment = this._comments.find(c => c.id === id);

        if (comment === undefined) {
            const newComment = {
                username,
                content,
                id: this._comments.length + 1,
                replies: []
            };

            this._comments.push(newComment);

            return `${username} commented on ${this.title}`;

        } else if (comment !== undefined) {
            const reply = {
                id: `${comment.id}.${comment.replies.length + 1}`,
                username,
                content
            }

            comment.replies.push(reply);

            return 'You replied successfully';
        }
    }

    toString(sortingType) {

        if (sortingType == 'asc') {
            this._comments.sort((a, b) => (a.id > b.id) ? 1 : -1);
            this._comments.forEach(c => {
                c.replies.sort((a, b) => (a.id > b.id) ? 1 : -1);
            });
        } else if (sortingType == 'desc') {
            this._comments.sort((a, b) => (a.id > b.id) ? -1 : 1);
            this._comments.forEach(c => {
                c.replies.sort((a, b) => (a.id > b.id) ? -1 : 1);
            });
        }
        else {
            this._comments.sort((a, b) => (a.username > b.username) ? 1 : -1);
            this._comments.forEach(c => {
                c.replies.sort((a, b) => (a.username > b.username) ? 1 : -1);
            });
        }

        const result = [];
        result.push(`Title: ${this.title}`);
        result.push(`Creator: ${this.creator}`);
        result.push(`Likes: ${this._likes.length}`)

        if (this._comments.length > 0) {
            result.push('Comments:');
            this._comments.forEach(c => {
                result.push(`-- ${c.id}. ${c.username}: ${c.content}`);
                c.replies.forEach(r => {
                    result.push(`--- ${r.id}. ${r.username}: ${r.content}`);
                });
            });
        }

        return result.join('\n');
    }
}


let art = new Article("My Article", "Anny");
art.like("John");
console.log(art.likes);
art.dislike("John");
console.log(art.likes);
art.comment("Sammy", "Some Content");
console.log(art.comment("Ammy", "New Content"));
art.comment("Zane", "Reply", 1);
art.comment("Jessy", "Nice :)");
console.log(art.comment("SAmmy", "Reply@", 1));
console.log()
console.log(art.toString('username'));
console.log()
art.like("Zane");
console.log(art.toString('desc'));