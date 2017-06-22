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
    public updatedProduct: Product = new Product();
    public categories: Category[] = [];
    public selectedCategory: Category = new Category();

    constructor(private categoryService: CategoryService, private productService: ProductService) {
        this.message = 'Products from the Tiger web';
    }

    ngOnInit() {
        this.getAllProducts();
    }

    public addProduct() {
        this.product.categoryId = this.selectedCategory.id;
        this.productService
            .Add(this.product)
            .subscribe(() => {
                this.getAllProducts();
                this.product = new Product();
            }, (error) => {
                console.log(error);
            });
    }

    public editProduct(product: Product): void {
        this.updatedProduct = product;
    }

    public saveProduct(productId: number): void {
        this.productService
            .Update(productId, this.updatedProduct)
            .subscribe(() => {
                this.getAllProducts();
                this.updatedProduct = new Product();
            }, (error) => {
                console.log(error);
            });
    }

    public cancel(): void {
        this.updatedProduct = new Product();
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
            data => {
                this.products = data;
                this.getAllCategories();
            },
            error => console.log(error),
            () => console.log('Get all products complete')
            );
    }

    private getAllCategories() {
        this.categoryService
            .GetAll()
            .subscribe(
            data => {
                this.categories = data;
                if (this.categories.length > 0) {
                    this.selectedCategory = this.categories[0];
                }
            },
            error => console.log(error),
            () => console.log('Get all complete')
            );
    }
}
