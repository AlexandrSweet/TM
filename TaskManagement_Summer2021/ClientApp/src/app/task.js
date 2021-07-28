"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Task = void 0;
var Task = /** @class */ (function () {
    function Task(id, title, description, date, statusId, userId
    //public messages?:messages
    ) {
        this.id = id;
        this.title = title;
        this.description = description;
        this.date = date;
        this.statusId = statusId;
        this.userId = userId;
    }
    return Task;
}());
exports.Task = Task;
//# sourceMappingURL=task.js.map