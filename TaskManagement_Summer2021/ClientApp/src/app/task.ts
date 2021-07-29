import { DatePipe } from "@angular/common";
import { Identifiers } from "@angular/compiler";

export class Task {
  constructor(
    public id: Identifiers,
    public title?: string,
    public description?: string,
    public date?: DatePipe,
    public statusId?: number,
    public userId?: Identifiers
    //public messages?:messages
  ) { }
}
