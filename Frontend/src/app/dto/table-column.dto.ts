import { Type } from "@angular/core";

export enum ContentMode {
    Default,
    DynamicPipe,
    TrueOrFalse,
    Buttons,
    Photo
}

export interface TableColumnDto {
    title: string; // title in header column
    objectField?: string; // name of object fied which data should be taken from
    pipeValues?: { pipe: Type<any>, pipeArgs?: any }; // value for dynamic pipe
    contentMode?: ContentMode;
}