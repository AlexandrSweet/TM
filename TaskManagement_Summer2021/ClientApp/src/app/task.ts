import { DatePipe } from "@angular/common";
import { Identifiers } from "@angular/compiler";

export class Task {
  constructor(
    public id: Identifiers,
    public title?: string,
    public description?: string,
    public date?: Date,
    public statusId?: number|any,
    public userId?: Identifiers
    //public messages?:messages
  ) { }
}
