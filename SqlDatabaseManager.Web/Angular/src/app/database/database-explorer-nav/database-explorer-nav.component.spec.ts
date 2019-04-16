import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DatabaseExplorerNavComponent } from './database-explorer-nav.component';

describe('DatabaseExplorerNavComponent', () => {
  let component: DatabaseExplorerNavComponent;
  let fixture: ComponentFixture<DatabaseExplorerNavComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DatabaseExplorerNavComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DatabaseExplorerNavComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
