import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AcaoeditComponent } from './acaoedit.component';

describe('AcaoeditComponent', () => {
  let component: AcaoeditComponent;
  let fixture: ComponentFixture<AcaoeditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AcaoeditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AcaoeditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
