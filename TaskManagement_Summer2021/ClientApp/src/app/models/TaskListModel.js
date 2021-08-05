"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.TaskListModel = void 0;
var TaskListModel = /** @class */ (function () {
    function TaskListModel(id, user, title, description, date, statusId
    //public messages?:messages
    ) {
        this.id = id;
        this.user = user;
        this.title = title;
        this.description = description;
        this.date = date;
        this.statusId = statusId;
    }
    return TaskListModel;
}());
exports.TaskListModel = TaskListModel;
//# sourceMappingURL=TaskListModel.js.map