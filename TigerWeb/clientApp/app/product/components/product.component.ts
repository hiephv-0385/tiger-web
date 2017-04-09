import { ProductService } from './../../core/services/product-data.service';
import { CategoryService } from './../../core/services/category-data.service';
import { Product } from './../../models/product';
import { Category } from './../../models/category';
import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'product-component',
    templateUrl: 'product.component.html'
})

export class ProductComponent implements OnInit {

    public message: string;
    public products: Product[] = [];
    public product: Product = new Product();
    public categories: Category[] = [];

    constructor(private categoryService: ProductService, private productService: ProductService) {
        this.message = 'Products from the Tiger web';
    }

    ngOnInit() {
        this.getAllProducts();
    }

    public addProduct() {
        this.productService
            .Add(this.product)
            .subscribe(() => {
                this.getAllProducts();
                this.product = new Product();
            }, (error) => {
                console.log(error);
            });
    }

    public deleteProduct(product: Product) {
        this.productService
            .Delete(product.id)
            .subscribe(() => {
                this.getAllProducts();
            }, (error) => {
                console.log(error);
            });
    }

    private getAllProducts() {
        this.productService
            .GetAll()
            .subscribe(
            data => this.products = data,
            error => console.log(error),
            () => console.log('Get all products complete')
            );
    }

    private getAllCategories() {
        this.categoryService
            .GetAll()
            .subscribe(
            data => this.categories = data,
            error => console.log(error),
            () => console.log('Get all categories complete')
            );
    }
}
