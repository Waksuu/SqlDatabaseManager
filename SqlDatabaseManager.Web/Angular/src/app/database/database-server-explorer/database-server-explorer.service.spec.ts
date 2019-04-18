import { TestBed } from '@angular/core/testing';

import { DatabaseServerExplorerService } from './database-server-explorer.service';

describe('DatabaseService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: DatabaseServerExplorerService = TestBed.get(DatabaseServerExplorerService);
    expect(service).toBeTruthy();
  });
});
