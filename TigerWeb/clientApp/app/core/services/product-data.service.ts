import { Product } from './../../models/product';
import { Configuration } from './../../app.constants';
import { Injectable } from '@angular/core';
import { Http, Response, Headers } from '@angular/http';
import 'rxjs/add/operator/map';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class ProductService {

    private actionUrl: string;
    private headers: Headers;

    constructor(private http: Http, private configuration: Configuration) {

        this.actionUrl = configuration.Server + 'api/products/';

        this.headers = new Headers();
        this.headers.append('Content-Type', 'application/json');
        this.headers.append('Accept', 'application/json');
    }

    public GetAll(): Observable<Product[]> {
        return this.http
            .post(this.actionUrl + 'all/', '', { headers: this.headers })
            .map((response: Response) => <Product[]>response.json());
    }

    public GetPoduct(id: number): Observable<Product> {
        return this.http
            .get(this.actionUrl + id)
            .map(res => <Product>res.json());
    }

    public Add(prod: Product): Observable<Product> {
        const toAdd = JSON.stringify({ name: prod.name, categoryId: prod.categoryId });

        return this.http
            .post(this.actionUrl, toAdd, { headers: this.headers })
            .map(res => <Product>res.json());
    }

    public Update(id: number, itemToUpdate: Product): Observable<Product> {
        return this.http
            .put(this.actionUrl + id, JSON.stringify(itemToUpdate), { headers: this.headers })
            .map(res => <Product>res.json());
    }

    public Delete(id: number): Observable<any> {
        return this.http
            .delete(this.actionUrl + id);
    }
}