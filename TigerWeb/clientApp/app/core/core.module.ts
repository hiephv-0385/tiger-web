import { CategoryService } from './services/category-data.service';
import { ProductService } from './services/product-data.service';
import { NgModule, ModuleWithProviders } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Configuration } from '../app.constants';

@NgModule({
    imports: [
        CommonModule
    ]
})

export class CoreModule {
    static forRoot(): ModuleWithProviders {
        return {
            ngModule: CoreModule,
            providers: [
                CategoryService,
                ProductService,
                Configuration
            ]
        };
    }
}