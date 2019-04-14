import { async, TestBed } from '@angular/core/testing';
import { DatabaseExplorerNavComponent } from './database-explorer-nav.component';
describe('DatabaseExplorerNavComponent', function () {
    var component;
    var fixture;
    beforeEach(async(function () {
        TestBed.configureTestingModule({
            declarations: [DatabaseExplorerNavComponent]
        })
            .compileComponents();
    }));
    beforeEach(function () {
        fixture = TestBed.createComponent(DatabaseExplorerNavComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });
    it('should create', function () {
        expect(component).toBeTruthy();
    });
});
//# sourceMappingURL=database-explorer-nav.component.spec.js.map