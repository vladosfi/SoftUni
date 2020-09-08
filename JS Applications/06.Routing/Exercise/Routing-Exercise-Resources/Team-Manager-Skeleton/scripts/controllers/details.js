export default async function () {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
        teamMember: await this.load('./templates/catalog/teamMember.hbs'),
        teamControls: await this.load('./templates/catalog/teamControls.hbs'),
    };

    const data = {
        teamId: '123',
        name: 'Cherry',
        comment: 'Some comment',
        members: [
            { username: 'Ivan' },
            { username: 'Dragan' },
            { username: 'Petkan' },
        ],
        isAuthor: true,
    };

    Object.assign(data, this.app.userData);

    this.partial('./templates/catalog/details.hbs', data);
}