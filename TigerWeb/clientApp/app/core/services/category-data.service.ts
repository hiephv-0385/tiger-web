import { Category } from './../../models/category';
import { Configuration } from './../../app.constants';
import { Injectable } from '@angular/core';
import { Http, Response, Headers } from '@angular/http';
import 'rxjs/add/operator/map';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class CategoryService {

    private actionUrl: string;
    private headers: Headers;

    constructor(private http: Http, private configuration: Configuration) {

        this.actionUrl = configuration.Server + 'api/categories/';

        this.headers = new Headers();
        this.headers.append('Content-Type', 'application/json');
        this.headers.append('Accept', 'application/json');
    }

    public GetAll = (): Observable<Category[]> => {
        return this.http.post(this.actionUrl + 'all/', '', { headers: this.headers }).map((response: Response) => <Category[]>response.json());
    }

    public GetSingle = (id: number): Observable<Category> => {
        return this.http.get(this.actionUrl + id).map(res => <Category>res.json());
    }

    public Add = (categoryToAdd: Category): Observable<Category> => {
        let toAdd = JSON.stringify({ name: categoryToAdd.name });

        return this.http.post(this.actionUrl, toAdd, { headers: this.headers }).map(res => <Category>res.json());
    }

    public Update = (id: number, itemToUpdate: any): Observable<Category> => {
        return this.http
            .put(this.actionUrl + id, JSON.stringify(itemToUpdate), { headers: this.headers })
            .map(res => <Category>res.json());
    }

    public Delete = (id: number): Observable<any> => {
        return this.http.delete(this.actionUrl + id);
    }
}