export default async function home() {
    this.partials = {
        notifications: await this.load('../../templates/common/notifications.hbs'),
        header: await this.load('../../templates/common/header.hbs'),
        footer: await this.load('../../templates/common/footer.hbs'),
    }

    this.partial('../../templates/home.hbs', this.app.userData);
}