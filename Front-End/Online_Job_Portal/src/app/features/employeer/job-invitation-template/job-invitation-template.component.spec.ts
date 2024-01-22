import { ComponentFixture, TestBed } from '@angular/core/testing';

import { JobInvitationTemplateComponent } from './job-invitation-template.component';

describe('JobInvitationTemplateComponent', () => {
  let component: JobInvitationTemplateComponent;
  let fixture: ComponentFixture<JobInvitationTemplateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [JobInvitationTemplateComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(JobInvitationTemplateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
