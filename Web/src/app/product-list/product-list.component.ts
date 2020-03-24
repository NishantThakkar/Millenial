import { Component, OnInit,ViewChild, ChangeDetectorRef, AfterViewInit } from '@angular/core';
import { ProductViewModel } from './product-list.model';
import { ProductListService } from './product-list.service';
import { PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table/table-data-source';
import {MatPaginator} from '@angular/material/paginator';
import { Observable , merge} from 'rxjs';
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
  length : number = 1;
  pageSize: number = 5;
  pageSizeOptions: number[] = [5, 10, 25, 100];
  displayedColumns: string[] = ['productId', 'prodName', 'productCategory', 'prodDescription', 'actions'];
  @ViewChild(MatPaginator , {static:true}) paginator: MatPaginator;  
   @ViewChild(MatSort, {static:true}) sort: MatSort;
  filterValue: string = null;
  dataSource: ProductDataSource;
  //  obs: Observable<any>;
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

    // when paginator event is invoked, retrieve the related data
    merge(this.paginator.page , this.sort.sortChange)
    .pipe(
       tap(() => this.dataSource.loadProducts(this.paginator.pageIndex, this.paginator.pageSize,this.sort.active , this.sort.direction,this.filterValue))
    )
    .subscribe();
  }
  applyFilter(event: Event){
     this.filterValue = (event.target as HTMLInputElement).value;
    debounceTime(1000);
    distinctUntilChanged();
  
      this.paginator.pageIndex = 0;
      this.dataSource.loadProducts(this.paginator.pageIndex, this.paginator.pageSize, 'prodName', 'asc',this.filterValue); 
  
  }
  view(row: ProductViewModel){
    console.log(row);
  }
  // pageEvent: PageEvent;
  
  // setPageSizeOptions(setPageSizeOptionsInput: string) {

  //   console.log(this.pageEvent);
  //   if (setPageSizeOptionsInput) {
  //     this.pageSizeOptions = setPageSizeOptionsInput.split(',').map(str => +str);
  //   }
  // }

  

  ngOnInit(): void {    
    // console.log(this.pageEvent);
    // //get products
    // this.productService.getProducts(10, 1).subscribe(res => {
    //   this.products = res;
    // });
    // set paginator page size
    this.paginator.pageSize = this.pageSize; 
    this.dataSource = new ProductDataSource(this.productService);
    this.dataSource.loadProducts(this.paginator.pageIndex, this.paginator.pageSize, 'prodName', 'asc',null); 
    // this.obs = this.dataSource.connect();
  }

}
