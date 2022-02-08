import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Client } from '../Interfaces/client.interface';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ClientService {
  private base_url : string = environment.base_url;
  constructor(private http:HttpClient) 
  {

  }
  getClient() : Observable<Client[]>{
    return this.http.get<Client[]>(`${
      this.base_url
    }Clients`
      
    )
  }

}
