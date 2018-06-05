import { Component, OnInit } from '@angular/core';
import { IItem } from '../../shared/models/item.model';
import { WalmartHomeworkService } from '../../shared/services/walmart-homework.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {
  product: IItem;
  recommendations: IItem[]; // Recommendations

  constructor(private walmartHomeworkService: WalmartHomeworkService, private route: ActivatedRoute, private location: Location) {
  }

  ngOnInit() {
    this.route.data.forEach((data) => {
      this.recommendations = [];
      this.product = data['product'];
      this.walmartHomeworkService.getRecommendations(this.product.itemId).subscribe(r => {
        this.recommendations = r;
      });
    });
  }

  goBack() {
    this.location.back();
    return false;
  }

}
