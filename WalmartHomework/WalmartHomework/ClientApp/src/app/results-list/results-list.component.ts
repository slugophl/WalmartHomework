import { Component, OnInit, Input } from '@angular/core';
import { IItem } from '../../shared/models/item.model';

@Component({
  selector: 'results-list',
  templateUrl: './results-list.component.html',
  styleUrls: ['./results-list.component.css']
})
export class ResultsListComponent implements OnInit {
  @Input() results: IItem[];

  constructor() { }

  ngOnInit() {
  }
}
