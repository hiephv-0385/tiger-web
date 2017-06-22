import { Routes, RouterModule } from '@angular/router';
import { ProductComponent } from './product/components/product.component';
import { LiveComponent } from './live/components/live.component';

export const routes: Routes = [
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    {
        path: 'about', loadChildren: './about/about.module#AboutModule',

    },
    { path: 'products', component: ProductComponent },
    { path: 'live', component: LiveComponent }
];

export const AppRoutes = RouterModule.forRoot(routes);
