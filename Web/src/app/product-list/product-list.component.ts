import { Component, OnInit,ViewChild, ChangeDetectorRef, AfterViewInit, ElementRef } from '@angular/core';
import { ProductViewModel } from './product-list.model';
import { ProductListService } from './product-list.service';
import { PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table/table-data-source';
import {MatPaginator} from '@angular/material/paginator';
import { Observable , merge, fromEvent} from 'rxjs';
import {ProductDataSource} from './product-list.datasource';
import { tap, debounceTime, distinctUntilChanged } from 'rxjs/operators';
import { MatSort } from '@angular/material/sort';
@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.scss']
})
export class ProductListComponent implements OnInit,AfterViewInit {
  products: ProductViewModel[];
  displayedColumns: string[] = ['productId', 'prodName', 'productCategory', 'prodDescription'];  
  @ViewChild(MatPaginator , {static:true}) paginator: MatPaginator;  
   @ViewChild(MatSort, {static:true}) sort: MatSort;
  filterValue: string | null = '';
  dataSource: ProductDataSource;
  @ViewChild('input') input: ElementRef;  
  
  product: ProductViewModel;
  constructor(private productService: ProductListService) { }
  ngAfterViewInit(): void {
    this.dataSource.counter$
    .pipe(
       tap((count) => {
          this.paginator.length = count;
       })
    )
    .subscribe();

    merge(this.paginator.page , this.sort.sortChange)
    .pipe(
       tap(() => this.loadProducts())
    )
    .subscribe();

    fromEvent(this.input.nativeElement,'keyup')
    .pipe(
        debounceTime(1000),
        distinctUntilChanged(),
        tap(() => {    
          this.filterValue = this.input.nativeElement.value;
            this.paginator.pageIndex = 0;
            this.loadProducts();
        })
    )
    .subscribe();
  }

  ngOnInit(): void {    
    this.paginator.pageSize = 5; 
    this.paginator.pageSizeOptions= [5, 10, 25, 100];
    this.sort.active = 'prodName';
    this.sort.direction = 'asc';
    this.dataSource = new ProductDataSource(this.productService);
    this.loadProducts();  
  }
  loadProducts(){
    this.dataSource.loadProducts(this.paginator.pageIndex, this.paginator.pageSize, this.sort.active, this.sort.direction,this.filterValue); 
  }
}
