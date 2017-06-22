import { CategoryService } from './../../core/services/category-data.service';
import { Category } from './../../models/category';
import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'home-component',
    templateUrl: 'home.component.html'
})

export class HomeComponent implements OnInit {

    public message: string;
    public categories: Category[] = [];
    public category: Category = new Category();

    constructor(private dataService: CategoryService) {
        this.message = 'Categories from the ASP.NET Core API';
    }

    ngOnInit() {
        this.getAllCategories();
    }

    public addCategory() {
        this.dataService
            .Add(this.category)
            .subscribe(() => {
                this.getAllCategories();
                this.category = new Category();
            }, (error) => {
                console.log(error);
            });
    }

    public deleteCategory(category: Category) {
        this.dataService
            .Delete(category.id)
            .subscribe(() => {
                this.getAllCategories();
            }, (error) => {
                console.log(error);
            });
    }

    private getAllCategories() {
        this.dataService
            .GetAll()
            .subscribe(
            data => this.categories = data,
            error => console.log(error),
            () => console.log('Get all complete')
            );
    }
}
