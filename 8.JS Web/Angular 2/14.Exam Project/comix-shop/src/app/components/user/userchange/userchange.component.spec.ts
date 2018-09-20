import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UserchangeComponent } from './userchange.component';

describe('UserchangeComponent', () => {
  let component: UserchangeComponent;
  let fixture: ComponentFixture<UserchangeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UserchangeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UserchangeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
