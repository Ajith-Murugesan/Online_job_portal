import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ApprovedusersComponent } from './approvedusers.component';

describe('ApprovedusersComponent', () => {
  let component: ApprovedusersComponent;
  let fixture: ComponentFixture<ApprovedusersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ApprovedusersComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ApprovedusersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
