import { Component, OnInit, Input } from '@angular/core';
import { IItem } from '../../shared/models/item.model';

@Component({
  selector: 'result-thumbnail',
  templateUrl: './result-thumbnail.component.html',
  styleUrls: ['./result-thumbnail.component.css']
})
export class ResultThumbnailComponent implements OnInit {
  @Input() result: IItem;

  constructor() { }

  ngOnInit() {
  }
}
