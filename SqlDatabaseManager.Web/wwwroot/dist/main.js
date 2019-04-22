(window["webpackJsonp"] = window["webpackJsonp"] || []).push([["main"],{

/***/ "./src/$$_lazy_route_resource lazy recursive":
/*!**********************************************************!*\
  !*** ./src/$$_lazy_route_resource lazy namespace object ***!
  \**********************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

function webpackEmptyAsyncContext(req) {
	// Here Promise.resolve().then() is used instead of new Promise() to prevent
	// uncaught exception popping up in devtools
	return Promise.resolve().then(function() {
		var e = new Error("Cannot find module '" + req + "'");
		e.code = 'MODULE_NOT_FOUND';
		throw e;
	});
}
webpackEmptyAsyncContext.keys = function() { return []; };
webpackEmptyAsyncContext.resolve = webpackEmptyAsyncContext;
module.exports = webpackEmptyAsyncContext;
webpackEmptyAsyncContext.id = "./src/$$_lazy_route_resource lazy recursive";

/***/ }),

/***/ "./src/app/app.component.css":
/*!***********************************!*\
  !*** ./src/app/app.component.css ***!
  \***********************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ".database-explorer-nav {\r\n  width:400px;\r\n}\r\n\r\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvYXBwLmNvbXBvbmVudC5jc3MiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IkFBQUE7RUFDRSxXQUFXO0FBQ2IiLCJmaWxlIjoic3JjL2FwcC9hcHAuY29tcG9uZW50LmNzcyIsInNvdXJjZXNDb250ZW50IjpbIi5kYXRhYmFzZS1leHBsb3Jlci1uYXYge1xyXG4gIHdpZHRoOjQwMHB4O1xyXG59XHJcbiJdfQ== */"

/***/ }),

/***/ "./src/app/app.component.html":
/*!************************************!*\
  !*** ./src/app/app.component.html ***!
  \************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div class=\"database-explorer-nav\">\r\n  <app-database-explorer-nav></app-database-explorer-nav>\r\n</div>\r\n"

/***/ }),

/***/ "./src/app/app.component.ts":
/*!**********************************!*\
  !*** ./src/app/app.component.ts ***!
  \**********************************/
/*! exports provided: AppComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AppComponent", function() { return AppComponent; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");


var AppComponent = /** @class */ (function () {
    function AppComponent() {
        this.title = 'Angular';
    }
    AppComponent = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Component"])({
            selector: 'app-root',
            template: __webpack_require__(/*! ./app.component.html */ "./src/app/app.component.html"),
            styles: [__webpack_require__(/*! ./app.component.css */ "./src/app/app.component.css")]
        })
    ], AppComponent);
    return AppComponent;
}());



/***/ }),

/***/ "./src/app/app.module.ts":
/*!*******************************!*\
  !*** ./src/app/app.module.ts ***!
  \*******************************/
/*! exports provided: AppModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AppModule", function() { return AppModule; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_platform_browser_animations__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/platform-browser/animations */ "./node_modules/@angular/platform-browser/fesm5/animations.js");
/* harmony import */ var _angular_platform_browser__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/platform-browser */ "./node_modules/@angular/platform-browser/fesm5/platform-browser.js");
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/forms */ "./node_modules/@angular/forms/fesm5/forms.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var _angular_material_expansion__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/material/expansion */ "./node_modules/@angular/material/esm5/expansion.es5.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _app_component__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ./app.component */ "./src/app/app.component.ts");
/* harmony import */ var _database_database_explorer_nav_database_explorer_nav_component__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! ./database/database-explorer-nav/database-explorer-nav.component */ "./src/app/database/database-explorer-nav/database-explorer-nav.component.ts");
/* harmony import */ var _security_security_module__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! ./security/security.module */ "./src/app/security/security.module.ts");
/* harmony import */ var _database_table_explorer_nav_table_explorer_nav_component__WEBPACK_IMPORTED_MODULE_10__ = __webpack_require__(/*! ./database/table-explorer-nav/table-explorer-nav.component */ "./src/app/database/table-explorer-nav/table-explorer-nav.component.ts");











var AppModule = /** @class */ (function () {
    function AppModule() {
    }
    AppModule = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_6__["NgModule"])({
            declarations: [
                _app_component__WEBPACK_IMPORTED_MODULE_7__["AppComponent"],
                _database_database_explorer_nav_database_explorer_nav_component__WEBPACK_IMPORTED_MODULE_8__["DatabaseExplorerNavComponent"],
                _database_table_explorer_nav_table_explorer_nav_component__WEBPACK_IMPORTED_MODULE_10__["TableExplorerNavComponent"],
            ],
            imports: [
                _angular_platform_browser_animations__WEBPACK_IMPORTED_MODULE_1__["BrowserAnimationsModule"],
                _angular_platform_browser__WEBPACK_IMPORTED_MODULE_2__["BrowserModule"],
                _angular_forms__WEBPACK_IMPORTED_MODULE_3__["FormsModule"],
                _angular_common_http__WEBPACK_IMPORTED_MODULE_4__["HttpClientModule"],
                _angular_material_expansion__WEBPACK_IMPORTED_MODULE_5__["MatExpansionModule"],
                _security_security_module__WEBPACK_IMPORTED_MODULE_9__["SecurityModule"]
            ],
            providers: [],
            bootstrap: [_app_component__WEBPACK_IMPORTED_MODULE_7__["AppComponent"]]
        })
    ], AppModule);
    return AppModule;
}());



/***/ }),

/***/ "./src/app/database/database-explorer-nav/database-explorer-nav.component.css":
/*!************************************************************************************!*\
  !*** ./src/app/database/database-explorer-nav/database-explorer-nav.component.css ***!
  \************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL2RhdGFiYXNlL2RhdGFiYXNlLWV4cGxvcmVyLW5hdi9kYXRhYmFzZS1leHBsb3Jlci1uYXYuY29tcG9uZW50LmNzcyJ9 */"

/***/ }),

/***/ "./src/app/database/database-explorer-nav/database-explorer-nav.component.html":
/*!*************************************************************************************!*\
  !*** ./src/app/database/database-explorer-nav/database-explorer-nav.component.html ***!
  \*************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<h1>Databases!</h1>\r\n\r\n<p>This component demonstrates fetching data from the server.</p>\r\n\r\n<mat-accordion *ngIf=\"databases$ | async as databases; else skeleton\">\r\n  <mat-expansion-panel *ngFor=\"let database of databases\">\r\n    <mat-expansion-panel-header>\r\n      <mat-panel-title>\r\n        {{ database.name }}\r\n      </mat-panel-title>\r\n    </mat-expansion-panel-header>\r\n      <app-table-explorer-nav [databaseName]=\"database.name\"></app-table-explorer-nav>\r\n  </mat-expansion-panel>\r\n</mat-accordion>\r\n\r\n<ng-template #skeleton>\r\n  <p><em>Loading...</em></p>\r\n</ng-template>\r\n"

/***/ }),

/***/ "./src/app/database/database-explorer-nav/database-explorer-nav.component.ts":
/*!***********************************************************************************!*\
  !*** ./src/app/database/database-explorer-nav/database-explorer-nav.component.ts ***!
  \***********************************************************************************/
/*! exports provided: DatabaseExplorerNavComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "DatabaseExplorerNavComponent", function() { return DatabaseExplorerNavComponent; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _shared_database_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../shared/database.service */ "./src/app/database/shared/database.service.ts");



var DatabaseExplorerNavComponent = /** @class */ (function () {
    function DatabaseExplorerNavComponent(databaseService) {
        this.databaseService = databaseService;
    }
    DatabaseExplorerNavComponent.prototype.ngOnInit = function () {
        this.databases$ = this.databaseService.getDatabases();
    };
    DatabaseExplorerNavComponent = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Component"])({
            selector: 'app-database-explorer-nav',
            template: __webpack_require__(/*! ./database-explorer-nav.component.html */ "./src/app/database/database-explorer-nav/database-explorer-nav.component.html"),
            styles: [__webpack_require__(/*! ./database-explorer-nav.component.css */ "./src/app/database/database-explorer-nav/database-explorer-nav.component.css")]
        }),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", [_shared_database_service__WEBPACK_IMPORTED_MODULE_2__["DatabaseService"]])
    ], DatabaseExplorerNavComponent);
    return DatabaseExplorerNavComponent;
}());



/***/ }),

/***/ "./src/app/database/shared/database.service.ts":
/*!*****************************************************!*\
  !*** ./src/app/database/shared/database.service.ts ***!
  \*****************************************************/
/*! exports provided: DatabaseService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "DatabaseService", function() { return DatabaseService; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var src_app_shared_kernel_api_helper__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! src/app/shared-kernel/api.helper */ "./src/app/shared-kernel/api.helper.ts");




var DatabaseService = /** @class */ (function () {
    function DatabaseService(http) {
        this.http = http;
    }
    DatabaseService.prototype.getDatabases = function () {
        return this.http.get(Object(src_app_shared_kernel_api_helper__WEBPACK_IMPORTED_MODULE_3__["apiUrl"])('Database', 'GetDatabases'));
    };
    DatabaseService.prototype.getTables = function (databaseName) {
        var httpParams = new _angular_common_http__WEBPACK_IMPORTED_MODULE_1__["HttpParams"]().append("databaseName", databaseName);
        return this.http.get(Object(src_app_shared_kernel_api_helper__WEBPACK_IMPORTED_MODULE_3__["apiUrl"])('Database', 'GetTables'), { params: httpParams });
    };
    DatabaseService = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_2__["Injectable"])({
            providedIn: 'root'
        }),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", [_angular_common_http__WEBPACK_IMPORTED_MODULE_1__["HttpClient"]])
    ], DatabaseService);
    return DatabaseService;
}());



/***/ }),

/***/ "./src/app/database/table-explorer-nav/table-explorer-nav.component.css":
/*!******************************************************************************!*\
  !*** ./src/app/database/table-explorer-nav/table-explorer-nav.component.css ***!
  \******************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ".table-explorer-nav {\r\n  text-indent: 30px;\r\n}\r\n\r\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvZGF0YWJhc2UvdGFibGUtZXhwbG9yZXItbmF2L3RhYmxlLWV4cGxvcmVyLW5hdi5jb21wb25lbnQuY3NzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiJBQUFBO0VBQ0UsaUJBQWlCO0FBQ25CIiwiZmlsZSI6InNyYy9hcHAvZGF0YWJhc2UvdGFibGUtZXhwbG9yZXItbmF2L3RhYmxlLWV4cGxvcmVyLW5hdi5jb21wb25lbnQuY3NzIiwic291cmNlc0NvbnRlbnQiOlsiLnRhYmxlLWV4cGxvcmVyLW5hdiB7XHJcbiAgdGV4dC1pbmRlbnQ6IDMwcHg7XHJcbn1cclxuIl19 */"

/***/ }),

/***/ "./src/app/database/table-explorer-nav/table-explorer-nav.component.html":
/*!*******************************************************************************!*\
  !*** ./src/app/database/table-explorer-nav/table-explorer-nav.component.html ***!
  \*******************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div *ngIf=\"tables$ | async as tables; else skeleton\">\r\n  <div *ngFor=\"let table of tables\">\r\n    <div class=\"table-explorer-nav\">\r\n      {{ table.name }}\r\n    </div>\r\n  </div>\r\n</div>\r\n\r\n<ng-template #skeleton>\r\n  <p><em>Loading...</em></p>\r\n</ng-template>\r\n"

/***/ }),

/***/ "./src/app/database/table-explorer-nav/table-explorer-nav.component.ts":
/*!*****************************************************************************!*\
  !*** ./src/app/database/table-explorer-nav/table-explorer-nav.component.ts ***!
  \*****************************************************************************/
/*! exports provided: TableExplorerNavComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "TableExplorerNavComponent", function() { return TableExplorerNavComponent; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _shared_database_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../shared/database.service */ "./src/app/database/shared/database.service.ts");



var TableExplorerNavComponent = /** @class */ (function () {
    function TableExplorerNavComponent(databaseService) {
        this.databaseService = databaseService;
    }
    TableExplorerNavComponent.prototype.ngOnInit = function () {
        this.tables$ = this.databaseService.getTables(this.databaseName);
    };
    tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Input"])(),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:type", String)
    ], TableExplorerNavComponent.prototype, "databaseName", void 0);
    TableExplorerNavComponent = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Component"])({
            selector: 'app-table-explorer-nav',
            template: __webpack_require__(/*! ./table-explorer-nav.component.html */ "./src/app/database/table-explorer-nav/table-explorer-nav.component.html"),
            styles: [__webpack_require__(/*! ./table-explorer-nav.component.css */ "./src/app/database/table-explorer-nav/table-explorer-nav.component.css")]
        }),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", [_shared_database_service__WEBPACK_IMPORTED_MODULE_2__["DatabaseService"]])
    ], TableExplorerNavComponent);
    return TableExplorerNavComponent;
}());



/***/ }),

/***/ "./src/app/security/security.module.ts":
/*!*********************************************!*\
  !*** ./src/app/security/security.module.ts ***!
  \*********************************************/
/*! exports provided: SecurityModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "SecurityModule", function() { return SecurityModule; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _security_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./security.service */ "./src/app/security/security.service.ts");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");



var SecurityModule = /** @class */ (function () {
    function SecurityModule() {
    }
    SecurityModule = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_2__["NgModule"])({
            providers: [
                _security_service__WEBPACK_IMPORTED_MODULE_1__["SecurityService"]
            ]
        })
    ], SecurityModule);
    return SecurityModule;
}());



/***/ }),

/***/ "./src/app/security/security.service.ts":
/*!**********************************************!*\
  !*** ./src/app/security/security.service.ts ***!
  \**********************************************/
/*! exports provided: SecurityService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "SecurityService", function() { return SecurityService; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");



var SecurityService = /** @class */ (function () {
    function SecurityService(http) {
        this.http = http;
    }
    SecurityService.prototype.login = function (loginDto) {
        return this.http.post("/api/login", loginDto);
    };
    SecurityService = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Injectable"])({ providedIn: "root" }),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", [_angular_common_http__WEBPACK_IMPORTED_MODULE_2__["HttpClient"]])
    ], SecurityService);
    return SecurityService;
}());



/***/ }),

/***/ "./src/app/shared-kernel/api.helper.ts":
/*!*********************************************!*\
  !*** ./src/app/shared-kernel/api.helper.ts ***!
  \*********************************************/
/*! exports provided: apiUrl */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "apiUrl", function() { return apiUrl; });
function apiUrl() {
    var url = [];
    for (var _i = 0; _i < arguments.length; _i++) {
        url[_i] = arguments[_i];
    }
    return "/api/" + url.join("/");
}


/***/ }),

/***/ "./src/environments/environment.ts":
/*!*****************************************!*\
  !*** ./src/environments/environment.ts ***!
  \*****************************************/
/*! exports provided: environment */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "environment", function() { return environment; });
// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.
var environment = {
    production: false
};
/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.


/***/ }),

/***/ "./src/main.ts":
/*!*********************!*\
  !*** ./src/main.ts ***!
  \*********************/
/*! exports provided: getBaseUrl */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "getBaseUrl", function() { return getBaseUrl; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_platform_browser_dynamic__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/platform-browser-dynamic */ "./node_modules/@angular/platform-browser-dynamic/fesm5/platform-browser-dynamic.js");
/* harmony import */ var _app_app_module__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./app/app.module */ "./src/app/app.module.ts");
/* harmony import */ var _environments_environment__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./environments/environment */ "./src/environments/environment.ts");




function getBaseUrl() {
    return document.getElementsByTagName('base')[0].href;
}
var providers = [
    {
        provide: 'BASE_URL',
        useFactory: getBaseUrl,
        deps: []
    }
];
if (_environments_environment__WEBPACK_IMPORTED_MODULE_3__["environment"].production) {
    Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["enableProdMode"])();
}
Object(_angular_platform_browser_dynamic__WEBPACK_IMPORTED_MODULE_1__["platformBrowserDynamic"])(providers).bootstrapModule(_app_app_module__WEBPACK_IMPORTED_MODULE_2__["AppModule"])
    .catch(function (err) { return console.error(err); });


/***/ }),

/***/ 0:
/*!***************************!*\
  !*** multi ./src/main.ts ***!
  \***************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

module.exports = __webpack_require__(/*! R:\Users\sfzbfd\source\repos\SqlDatabaseManager\SqlDatabaseManager.Web\Angular\src\main.ts */"./src/main.ts");


/***/ })

},[[0,"runtime","vendor"]]]);
//# sourceMappingURL=main.js.map