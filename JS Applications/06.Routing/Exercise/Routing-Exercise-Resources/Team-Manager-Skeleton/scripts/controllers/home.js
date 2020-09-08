export default async function () {
    //this === Sammy.EventContext
    //console.log(this);
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
    };
    this.partial('./templates/home/home.hbs', this.app.userData);

    // this.loadPartials({
    //     header: './templates/common/header.hbs',
    //     footer: './templates/common/footer.hbs',
    // }).then(function () {
    //     this.partial('./templates/home/home.hbs');
    // });


    // this.render('./templates/register/registerForm.hbs').then(function (html) {
    //     //this === Sammy.RenderContext
    //     //console.log(this);
    //     this.swap(html);
    // });
}