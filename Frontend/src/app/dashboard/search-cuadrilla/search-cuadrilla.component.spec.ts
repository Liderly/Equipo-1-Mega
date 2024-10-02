import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchCuadrillaComponent } from './search-cuadrilla.component';

describe('SearchCuadrillaComponent', () => {
  let component: SearchCuadrillaComponent;
  let fixture: ComponentFixture<SearchCuadrillaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SearchCuadrillaComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SearchCuadrillaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
