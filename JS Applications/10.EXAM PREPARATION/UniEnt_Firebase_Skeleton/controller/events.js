import { close, create, get, update } from '../models/events.js';
import { setHeader } from './auth.js';
import commonPartials from './partials.js';

export function getCreate(ctx) {
    setHeader(ctx);
    ctx.loadPartials(commonPartials).partial('./view/events/create.hbs');
}

export function postCreate(ctx) {
    const { name, dateTime, description, imageURL } = ctx.params;
    const organizer = sessionStorage.getItem('user');

    create({ name, dateTime, description, imageURL, organizer, interestedIn: 0 })
        .then(resp => {
            console.log(resp);
            ctx.redirect('#/home');
        })
        .catch(e => console.log(e));
}

export function getDetails(ctx) {
    const id = ctx.params.id;
    setHeader(ctx);

    get(id)
        .then(resp => {
            ctx.event = { ...resp.data(), id: resp.id };
            ctx.isOrganizer = ctx.event.organizer === sessionStorage.getItem('user');
            ctx.loadPartials(commonPartials).partial('./view/events/details.hbs');
        })
        .catch(e => console.log(e));
}

export function getEdit(ctx) {
    const id = ctx.params.id;

    get(id)
        .then(resp => {
            ctx.event = { ...resp.data(), id: resp.id };
            ctx.loadPartials(commonPartials).partial('./view/events/edit.hbs');
        })
        .catch(e => console.log(e));
}

export function postEdit(ctx) {
    const id = ctx.params.id;
    const { name, dateTime, description, imageURL } = ctx.params;

    update(id, { name, dateTime, description, imageURL })
        .then(ctx.redirect(`#/details/${id}`))
        .catch(e => console.log(e));
}

export function getClose(ctx) {
    const id = ctx.params.id;

    close(id)
        .then(res => {
            ctx.redirect(`#/home`);
        })
        .catch(e => console.log(e));
}

export function getJoin(ctx) {
    const id = ctx.params.id;

    get(id)
        .then(resp => {
            ctx.event = { ...resp.data(), id: resp.id };
            const interestedIn = ++ctx.event.interestedIn;

            update(id, { interestedIn })
                .then(res => {
                    ctx.redirect(`#/details/${id}`);
                })
                .catch(e => console.log(e));
        })
        .catch(e => console.log(e));

}