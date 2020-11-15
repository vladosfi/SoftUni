import { ClassField } from "@angular/compiler";

export class Article {
    constructor (
        public title: string,
        public description: string,
        public author: string,
        public imageUrl: string){}
}