import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';

import { ProductRoutes } from './product.routes';
import { ProductComponent } from './components/product.component';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        HttpModule,
        ProductRoutes
    ],

    declarations: [
        ProductComponent
    ],

    exports: [
        ProductComponent
    ]
})

export class ProductModule { }