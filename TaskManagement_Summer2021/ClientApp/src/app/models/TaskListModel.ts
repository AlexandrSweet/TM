import { Identifiers } from "@angular/compiler";
import { User } from "./User";

export class TaskListModel {
  constructor(
    public id: Identifiers,
    public title?: string,
    public description?: string,
    public date?: Date,
    public statusId?: number,
    public user?: User
    //public messages?:messages
  ) { }
}