import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CarInsertComponent } from './car-insert.component';

describe('CarInsertComponent', () => {
  let component: CarInsertComponent;
  let fixture: ComponentFixture<CarInsertComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CarInsertComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CarInsertComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
