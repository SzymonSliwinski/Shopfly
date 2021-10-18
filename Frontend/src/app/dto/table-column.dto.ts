import { Type } from "@angular/core";

export interface TableColumnDto {
    title: string;
    objectField: string;
    additionalContent: any;
    usePipe?: boolean;
    pipeValues?: { pipe: Type<any>, pipeArgs?: any };
}