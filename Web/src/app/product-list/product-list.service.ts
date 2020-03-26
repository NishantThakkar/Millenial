import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {environment} from '../../environments/environment';
import { Observable } from 'rxjs';
import { ProductList } from './product-list.model';
import { SortDirection } from '@angular/material/sort';
@Injectable({
  providedIn: 'root'
})
export class ProductListService {

  constructor(private http: HttpClient ) { }
  getProducts(take: number, page: number,sortBy: string, sortDirection: SortDirection,search: string | null): Observable<ProductList>{
    return this.http.get<ProductList>(`${environment.serverUrl}/api/Product?take=${take}&page=${page}&sortBy=${sortBy}&sortDirection=${sortDirection}&search=${search}`);
  }
}
