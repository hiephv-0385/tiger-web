import { Component } from '@angular/core';

// AoT compilation doesn't support 'require'.
import './app.component.scss';
import '../styles/app.scss';

@Component({
    selector: 'tiger-app',
    templateUrl: 'app.component.html'
})

export class AppComponent { }