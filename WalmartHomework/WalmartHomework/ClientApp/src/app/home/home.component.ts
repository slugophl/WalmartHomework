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
  errorMessage: string;

  constructor(private walmartHomeworkService: WalmartHomeworkService) { }

  ngOnInit() {
    this.query = "";
    this.errorMessage = null;
  }

  search(form) {
    this.results = [];
    this.errorMessage = null;
    this.showLoader = true;
    let formValues = form.value;
    this.walmartHomeworkService.search(formValues.query).subscribe(s => {
      this.showLoader = false;

      if (s.items && s.items.length > 0)
        this.results = s.items;

      if (s.totalResults === 0 && s.numItems === 0)
        this.errorMessage = s.message;

      if (s.errors && s.errors.length > 0)
        this.errorMessage = s.errors[0].message;
    });
  }
}
