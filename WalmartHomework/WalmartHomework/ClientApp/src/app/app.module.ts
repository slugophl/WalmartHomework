import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { ResultsListComponent } from './results-list/results-list.component';
import { ResultThumbnailComponent } from './result-thumbnail/result-thumbnail.component';
import { WalmartHomeworkService } from '../shared/services/walmart-homework.service';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { ProductResolverService } from './product-details/product-resolver.service';
import { TruncatePipe } from '../shared/custompipes/truncate.pipe';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ResultsListComponent,
    ResultThumbnailComponent,
    ProductDetailsComponent,
    TruncatePipe
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'products/:id', component: ProductDetailsComponent, resolve: {product: ProductResolverService} }
    ])
  ],
  providers: [
    WalmartHomeworkService,
    ProductResolverService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
