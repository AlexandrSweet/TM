import { Identifiers } from "@angular/compiler";

export class Task {
  constructor(
    public id?: Identifiers,
    public title?: string,
    public description?: string,
    public taskStatusId?: number,
    public userId?: Identifiers) { }
}
