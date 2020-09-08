export default async function () {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
        team: await this.load('./templates/catalog/team.hbs'),
    };

    const data = Object.assign({}, this.app.userData);
    data.teams = [
        {
            teamId: '123',
            name: 'Cherry',
            comment: 'Some comment',
        },
        {
            teamId: '1234',
            name: 'Apple',
            comment: 'Some comment',
        },
        {
            teamId: '12345',
            name: 'Banana',
            comment: 'Some comment',
        },
    ];

    this.partial('./templates/catalog/teamCatalog.hbs', data);
}