export class ProductViewModel{
    productId: number = 0;
  prodName: string;
  prodDescription: string | null;
  productCategory: string | null;
}
export class ProductList{
  products: ProductViewModel[];
  count: number;
}
