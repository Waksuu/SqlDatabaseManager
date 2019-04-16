import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TableExplorerNavComponent } from './table-explorer-nav.component';

describe('TableExplorerNavComponent', () => {
  let component: TableExplorerNavComponent;
  let fixture: ComponentFixture<TableExplorerNavComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TableExplorerNavComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TableExplorerNavComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
