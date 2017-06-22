import { Component } from '@angular/core';

@Component({
    selector: 'live-component',
    templateUrl: 'live.component.html'
})

export class LiveComponent {

    public message: string;

    constructor() {
        this.message = 'Hello from LiveComponent';
    }
}
