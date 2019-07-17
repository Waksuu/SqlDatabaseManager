import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { MatExpansionModule } from '@angular/material/expansion';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';

import { DatabaseExplorerComponent } from './database-explorer.component';
import { DatabaseServerExplorerService } from '../database-server-explorer.service';
import { DatabaseServerExplorerServiceMock } from '../database-server-explorer.service.mock';
import { TableExplorerComponent } from './table-explorer/table-explorer.component';

describe('DatabaseExplorerComponent', () => {
  let component: DatabaseExplorerComponent;
  let fixture: ComponentFixture<DatabaseExplorerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [
        DatabaseExplorerComponent,
        TableExplorerComponent
      ],
      imports: [
        MatExpansionModule,
        NoopAnimationsModule,
      ],
      providers: [
        {
          provide: DatabaseServerExplorerService,
          useClass: DatabaseServerExplorerServiceMock
        }]
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DatabaseExplorerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should initialize database tables', () => {
    component.databases$.subscribe(x => expect(x.length).toBeGreaterThan(0));
  });
});
