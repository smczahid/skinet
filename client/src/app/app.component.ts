import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { IPagination } from './models/pagination';
import { IProduct } from './models/product';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'Skinet';
  products: IProduct[];

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.http.get('https://localhost:7247/api/products?pagesize=50').subscribe({
      next: (v : IPagination) => {
        this.products=v.data;
        console.log(this.products);
      },
      error: (e) => console.error(e),
      complete: () => console.info('complete')
    });
  }

}
