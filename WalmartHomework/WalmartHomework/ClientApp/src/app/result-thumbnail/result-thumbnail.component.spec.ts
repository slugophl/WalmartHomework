import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ResultThumbnailComponent } from './result-thumbnail.component';

describe('ResultThumbnailComponent', () => {
  let component: ResultThumbnailComponent;
  let fixture: ComponentFixture<ResultThumbnailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ResultThumbnailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ResultThumbnailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
