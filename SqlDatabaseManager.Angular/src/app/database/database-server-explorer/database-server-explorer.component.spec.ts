import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DatabaseServerExplorerComponent } from './database-server-explorer.component';

describe('DatabaseServerExplorerComponent', () => {
  let component: DatabaseServerExplorerComponent;
  let fixture: ComponentFixture<DatabaseServerExplorerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DatabaseServerExplorerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DatabaseServerExplorerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
