import { Identifiers } from "@angular/compiler";

export class Task {
  constructor(
    public id?: Identifiers,
    public title?: string,
  // public description?: string,
    public userId?: Identifiers) { }
}
