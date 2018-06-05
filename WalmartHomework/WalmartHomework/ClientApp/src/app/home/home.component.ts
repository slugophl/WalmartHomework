import { Component, OnInit } from '@angular/core';
import { WalmartHomeworkService } from '../../shared/services/walmart-homework.service';
import { IItem } from '../../shared/models/item.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  query: string;
  results: IItem[];
  showLoader: boolean = false;

  constructor(private walmartHomeworkService: WalmartHomeworkService) { }

  ngOnInit() {
    this.query = "";
  }

  search(form) {
    this.results = [];
    this.showLoader = true;
    let formValues = form.value;
    this.walmartHomeworkService.search(formValues.query).subscribe(s => {
      this.showLoader = false;
      this.results = s.items;
    });
  }
}
