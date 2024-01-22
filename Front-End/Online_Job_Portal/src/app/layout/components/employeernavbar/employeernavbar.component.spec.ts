import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmployeernavbarComponent } from './employeernavbar.component';

describe('EmployeernavbarComponent', () => {
  let component: EmployeernavbarComponent;
  let fixture: ComponentFixture<EmployeernavbarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [EmployeernavbarComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(EmployeernavbarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
