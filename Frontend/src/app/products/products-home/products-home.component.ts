import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/core/services/auth.service';
import { ProductService } from 'src/app/core/services/data/product.service';
import { IProduct } from 'src/app/shared/interfaces';

@Component({
  selector: 'ai-products-home',
  templateUrl: './products-home.component.html',
  styleUrls: ['./products-home.component.scss'],
})
export class ProductsHomeComponent implements OnInit {
  products: IProduct[];
  displayedColumns: string[] = [
    'name',
    'barcode',
    'description',
    'rate',
    'action',
  ];
  constructor(
    private productService: ProductService,
    private authService: AuthService,
    private router: Router
  ) {}

  ngOnInit(): void {
    if (!this.authService.isAuthenticated()) {
      
      this.router.navigate(['login']);

      return;
    }

    this.loadProducts();
  }

  loadProducts() {
    this.productService.getAll(1, 100).subscribe((resp) => {
      this.products = resp.data;
    });
  }

  delete(product: IProduct) {
    this.productService.delete(product.id).subscribe((t) => {
      alert('Success');
      this.loadProducts();
    });
  }

  create() {
    const productData = <IProduct>{
      name: this.randomString(5),
      barcode: this.randomString(8),
      description: this.randomString(20),
      rate: Math.floor(Math.random() * 99 + 1),
    };

    this.productService.create(productData).subscribe((t) => {
      alert('Success');
      this.loadProducts();
    });
  }

  randomString(length) {
    var randomChars =
      'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
    var result = '';
    for (var i = 0; i < length; i++) {
      result += randomChars.charAt(
        Math.floor(Math.random() * randomChars.length)
      );
    }
    return result;
  }
}
