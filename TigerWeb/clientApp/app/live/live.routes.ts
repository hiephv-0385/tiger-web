import { Routes, RouterModule } from '@angular/router';

import { LiveComponent } from './components/live.component';

const routes: Routes = [
    { path: '', component: LiveComponent }
];

export const LiveRoutes = RouterModule.forChild(routes);