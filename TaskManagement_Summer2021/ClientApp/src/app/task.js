"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Task = void 0;
var Task = /** @class */ (function () {
    function Task(id, title, description, date, requirement, statusId, userId) {
        this.id = id;
        this.title = title;
        this.description = description;
        this.date = date;
        this.requirement = requirement;
        this.statusId = statusId;
        this.userId = userId;
    }
    return Task;
}());
exports.Task = Task;
//# sourceMappingURL=task.js.map