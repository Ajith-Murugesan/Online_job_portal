import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PendingusersComponent } from './pendingusers.component';

describe('PendingusersComponent', () => {
  let component: PendingusersComponent;
  let fixture: ComponentFixture<PendingusersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [PendingusersComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PendingusersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
