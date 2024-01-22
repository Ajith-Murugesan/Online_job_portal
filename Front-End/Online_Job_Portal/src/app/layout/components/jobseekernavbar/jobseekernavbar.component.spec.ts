import { ComponentFixture, TestBed } from '@angular/core/testing';

import { JobseekernavbarComponent } from './jobseekernavbar.component';

describe('JobseekernavbarComponent', () => {
  let component: JobseekernavbarComponent;
  let fixture: ComponentFixture<JobseekernavbarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [JobseekernavbarComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(JobseekernavbarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
