import { Type } from "@angular/core";

export interface TableColumnDto {
    title: string;
    objectField?: string;
    customContent?: Type<any>;
    usePipe?: boolean;
    pipeValues?: { pipe: Type<any>, pipeArgs?: any };
}