import { Identifiers } from "@angular/compiler";
import { UserListModel } from "./UserListModel";

export class TaskListModel {
  constructor(
    public id: Identifiers,
    public user: UserListModel,
    public title?: string,
    public description?: string,
    public date?: Date,
    public statusId?: number
    
    //public messages?:messages
  ) { }
}
