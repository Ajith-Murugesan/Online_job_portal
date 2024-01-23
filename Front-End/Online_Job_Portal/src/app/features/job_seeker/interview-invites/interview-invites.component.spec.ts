import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InterviewInvitesComponent } from './interview-invites.component';

describe('InterviewInvitesComponent', () => {
  let component: InterviewInvitesComponent;
  let fixture: ComponentFixture<InterviewInvitesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [InterviewInvitesComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(InterviewInvitesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
