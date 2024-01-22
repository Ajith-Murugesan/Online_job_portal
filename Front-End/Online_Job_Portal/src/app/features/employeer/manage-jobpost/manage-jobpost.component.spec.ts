import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManageJobpostComponent } from './manage-jobpost.component';

describe('ManageJobpostComponent', () => {
  let component: ManageJobpostComponent;
  let fixture: ComponentFixture<ManageJobpostComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ManageJobpostComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ManageJobpostComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
