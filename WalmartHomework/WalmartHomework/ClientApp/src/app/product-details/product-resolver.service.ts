import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { WalmartHomeworkService } from '../../shared/services/walmart-homework.service';

@Injectable()
export class ProductResolverService implements Resolve<any> {

  constructor(private walmartHomeworkService: WalmartHomeworkService) { }

  resolve(route: ActivatedRouteSnapshot) {
    return this.walmartHomeworkService.lookup(route.params['id']);
  }
}
