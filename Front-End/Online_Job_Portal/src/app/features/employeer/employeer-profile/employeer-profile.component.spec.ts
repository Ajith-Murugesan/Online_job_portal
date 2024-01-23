import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmployeerProfileComponent } from './employeer-profile.component';

describe('EmployeerProfileComponent', () => {
  let component: EmployeerProfileComponent;
  let fixture: ComponentFixture<EmployeerProfileComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [EmployeerProfileComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(EmployeerProfileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
