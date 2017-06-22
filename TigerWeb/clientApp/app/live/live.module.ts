import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LiveRoutes } from './live.routes';
import { LiveComponent } from './components/live.component';

@NgModule({
    imports: [
        CommonModule,
        LiveRoutes
    ],

    declarations: [
        LiveComponent
    ],

})

export class LiveModule { }