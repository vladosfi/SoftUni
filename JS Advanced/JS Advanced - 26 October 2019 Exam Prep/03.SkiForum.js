//https://youtu.be/6jdszM4HVNM?t=10985

class Forum {
    constructor() {
        this._users = [];
        this._questions = [];
        this._id = 1;
        this._currentLoggedInUsers = [];
    }

    register(username, password, repeatPassword, email) {
        if (!(username && password && repeatPassword && email)) {
            throw new Error('Input can not be empty');
        } else if (password !== repeatPassword) {
            throw new Error('Passwords do not match');
        } else if (this._users.find(u => u.username === username) !== undefined ||
            this._users.find(u => u.email === email) !== undefined) {
            throw new Error('This user already exists!');
        }

        this._users.push({
            username,
            password,
            email
        });

        return `${username} with ${email} was registered successfully!`;
    }


    login(username, password) {
        const user = this._users.find(u => u.username === username);

        if (user === undefined) {
            throw new Error('There is no such user');
        } else if (user.username == username && password === user.password) {
            this._currentLoggedInUsers.push(username);
            return 'Hello! You have logged in successfully';
        }
    }

    logout(username, password) {
        const user = this._users.find(u => u.username === username);

        if (user === undefined) {
            throw new Error('There is no such user');
        } else if (password === user.password) {
            this._currentLoggedInUsers = this._currentLoggedInUsers.filter(u => u !== username);            
            return 'You have logged out successfully';
        }
    }

    postQuestion(username, question) {
        const user = this._users.find(u => u.username === username);

        if (user === undefined || !this._currentLoggedInUsers.includes(username)) {
            throw new Error('You should be logged in to post questions');
        } else if (!question) {
            throw new Error('Invalid question');
        }

        this._questions.push({
            id: this._id,
            question,
            answers: [],
            postedBy: user.username
        });

        this._id++;
        return 'Your question has been posted successfully';
    }

    postAnswer(username, questionId, answer) {
        const user = this._users.find(u => u.username === username);

        if (user === undefined || !this._currentLoggedInUsers.includes(username)) {
            throw new Error('You should be logged in to post answers');
        }

        if (!answer) {
            throw new Error('Invalid answer');
        }

        const questionRef = this._questions.find(q => q.id === questionId);

        if (!questionRef) {
            throw new Error('There is no such question');
        }

        questionRef.answers.push({
            answer,
            answerdBy: username
        });

        return 'Your answer has been posted successfully';
    }

    showQuestions() {
        const result = [];

        this._questions.forEach(q => {
            result.push(`Question ${q.id} by ${q.postedBy}: ${q.question}`);
            q.answers.forEach(a => {
                result.push(`---${a.answerdBy}: ${a.answer}`);
            });
        });

        return result.join('\n');
    }
}


let forum = new Forum();

forum.register('Michael', '123', '123', 'michael@abv.bg');
forum.register('Stoyan', '123ab7', '123ab7', 'some@gmail@.com');
forum.login('Michael', '123');
forum.login('Stoyan', '123ab7');

forum.postQuestion('Michael', 'Can I rent a snowboard from your shop?');
forum.postAnswer('Stoyan', 1, 'Yes, I have rented one last year.');
forum.postQuestion('Stoyan', 'How long are supposed to be the ski for my daughter?');
forum.postAnswer('Michael', 2, 'How old is she?');
forum.postAnswer('Michael', 2, 'Tell us how tall she is.');

console.log(forum.showQuestions());


// let forum = new Forum();

// forum.register('Jonny', '12345', '12345', 'jonny@abv.bg');
// forum.register('Peter', '123ab7', '123ab7', 'peter@gmail@.com');
// forum.login('Jonny', '12345');
// forum.login('Peter', '123ab7');

// forum.postQuestion('Jonny', "Do I need glasses for skiing?");
// forum.postAnswer('Peter', 1, "Yes, I have rented one last year.");
// forum.postAnswer('Jonny', 1, "What was your budget");
// forum.postAnswer('Peter', 1, "$50");
// forum.postAnswer('Jonny', 1, "Thank you :)");

// console.log(forum.showQuestions());
