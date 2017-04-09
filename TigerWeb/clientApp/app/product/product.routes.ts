import { Routes, RouterModule } from '@angular/router';

import { ProductComponent } from './components/product.component';

const routes: Routes = [
    { path: 'products', component: ProductComponent }
];

export const ProductRoutes = RouterModule.forChild(routes);