import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CuadrillaComponent } from './cuadrilla.component';

describe('CuadrillaComponent', () => {
  let component: CuadrillaComponent;
  let fixture: ComponentFixture<CuadrillaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CuadrillaComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CuadrillaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
