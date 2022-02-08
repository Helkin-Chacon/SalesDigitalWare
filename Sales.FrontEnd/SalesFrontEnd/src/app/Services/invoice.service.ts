import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Invoice } from '../Interfaces/invoice.interface';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class InvoiceService {
  private base_url : string = environment.base_url;
  constructor(private http:HttpClient)
  {

  }
  getInvoice() : Observable<Invoice[]>{
    return this.http.get<Invoice[]>(`${
      this.base_url
    }invoice`      
    )
  }
  setInvoice(invoice: Invoice):Observable<Invoice[]>{
    return this.http.post<Invoice[]>(`${
      this.base_url
    }invoice`, invoice);
  }
  
  

  
}
