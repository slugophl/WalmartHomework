import { Injectable } from '@angular/core';
import { Subject, Observable } from 'rxjs/RX';
import { HttpClient, HttpResponse, HttpHeaders, HttpParams } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { IItem } from '../models/item.model';
import { ISearch } from '../models/search.model';

@Injectable()
export class WalmartHomeworkService {

  constructor(private http: HttpClient) { }

  search(query: string): Observable<ISearch> {
    return this.http.get<ISearch>('/api/products/search?query=' + query)
      .pipe(catchError(this.handleError<ISearch>('search', null)));
  }

  lookup(id: number): Observable<IItem> {
    return this.http.get<IItem>('/api/products/' + id + '/lookup')
      .pipe(catchError(this.handleError<IItem>('lookup', null)));
  }

  getRecommendations(id: number): Observable<IItem[]> {
    return this.http.get<IItem[]>('/api/products/' + id + '/recommendations')
      .pipe(catchError(this.handleError<IItem[]>('getRecommendations', [])));
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);
      return Observable.of(result as T);
    }
  }
}
