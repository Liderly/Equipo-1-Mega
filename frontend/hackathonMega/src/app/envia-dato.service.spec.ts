import { TestBed } from '@angular/core/testing';

import { EnviaDatoService } from './envia-dato.service';

describe('EnviaDatoService', () => {
  let service: EnviaDatoService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EnviaDatoService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
