import { Identifiers } from "@angular/compiler";

export class UserListModel {
  constructor(
    public id: Identifiers,
    public firstName: string,
    public lastName: string,
    public email: string,
    public roleId: number,
  ) { }
}
