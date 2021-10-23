import { Type } from "@angular/core";

export enum ContentMode {
    default,
    dynamicPipe,
    custom
}

export interface TableColumnDto {
    title: string; // title in header column
    objectField?: string; // name of object fied which data should be taken from
    customContent?: Type<any>; // custom content that will be displayed in cell
    injectorType?: Type<any>; // injector for custom content
    pipeValues?: { pipe: Type<any>, pipeArgs?: any }; // value for dynamic pipe
    contentMode?: ContentMode;
}