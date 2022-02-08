import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Product } from '../Interfaces/product.interface';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  
  private base_url : string = environment.base_url;
  constructor(private http:HttpClient)
  {

  }
  getProduct() : Observable<Product[]>{
    return this.http.get<Product[]>(`${
      this.base_url
    }products`      
    )
  }
}

aaa