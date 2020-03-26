import { CollectionViewer, DataSource } from "@angular/cdk/collections";
import { Observable, BehaviorSubject, of } from 'rxjs';
import { ProductViewModel, ProductList } from './product-list.model';
import { ProductListService } from './product-list.service';
import { catchError, finalize } from 'rxjs/operators';
import { SortDirection } from '@angular/material/sort';

export class ProductDataSource extends DataSource<ProductViewModel> {
    private productsSubject = new BehaviorSubject<ProductViewModel[]>([]);
    private countSubject = new BehaviorSubject<number>(0);
    public counter$ = this.countSubject.asObservable();

    private loadingSubject = new BehaviorSubject<boolean>(false);
    public loading$ = this.loadingSubject.asObservable();

    constructor(private productService: ProductListService) {
      super();
    }
    connect(): Observable<ProductViewModel[]> {
        return this.productsSubject.asObservable();
    }
    disconnect() { 
        this.productsSubject.complete();
        this.countSubject.complete();
        this.loadingSubject.complete();
    }
    loadProducts(pageIndex: number, pageSize: number, sortBy: string, sortDirection: SortDirection, search: string | null){
      if (sortBy == undefined) {
        sortBy = '';
      }
      this.loadingSubject.next(true);

        return this.productService.getProducts(pageSize , pageIndex,sortBy,sortDirection,search)
        .pipe(
            catchError(() => of([])),
            finalize(() => this.loadingSubject.next(false))
         )         
         .subscribe((result : ProductList) => {
            this.productsSubject.next(result.products);
            this.countSubject.next(result.count);
           }
         );
    }
  }
  