import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OrdemEditComponent } from './ordem-edit.component';

describe('OrdemEditComponent', () => {
  let component: OrdemEditComponent;
  let fixture: ComponentFixture<OrdemEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OrdemEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OrdemEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
