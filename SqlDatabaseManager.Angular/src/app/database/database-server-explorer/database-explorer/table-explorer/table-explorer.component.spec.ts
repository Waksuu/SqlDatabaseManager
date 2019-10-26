import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TableExplorerComponent } from './table-explorer.component';

describe('TableExplorerNavComponent', () => {
  let component: TableExplorerComponent;
  let fixture: ComponentFixture<TableExplorerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TableExplorerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TableExplorerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
