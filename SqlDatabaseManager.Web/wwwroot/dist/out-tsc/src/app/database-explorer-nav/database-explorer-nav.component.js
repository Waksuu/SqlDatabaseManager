import * as tslib_1 from "tslib";
import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
var DatabaseExplorerNavComponent = /** @class */ (function () {
    function DatabaseExplorerNavComponent(http, baseUrl) {
        var _this = this;
        http.get(baseUrl + 'api/Database/GetDatabases').subscribe(function (result) {
            _this.databases = result;
        }, function (error) { return console.error(error); });
    }
    DatabaseExplorerNavComponent.prototype.ngOnInit = function () {
    };
    DatabaseExplorerNavComponent = tslib_1.__decorate([
        Component({
            selector: 'app-database-explorer-nav',
            templateUrl: './database-explorer-nav.component.html',
            styleUrls: ['./database-explorer-nav.component.css']
        }),
        tslib_1.__param(1, Inject('BASE_URL')),
        tslib_1.__metadata("design:paramtypes", [HttpClient, String])
    ], DatabaseExplorerNavComponent);
    return DatabaseExplorerNavComponent;
}());
export { DatabaseExplorerNavComponent };
//# sourceMappingURL=database-explorer-nav.component.js.map