import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';


import { environment } from 'src/environments/environment';
import { Supplier } from '../models/supplier';

@Injectable({
  providedIn: 'root'
})
export class SupplierApiService {

  private endPoint: string = "suppliers/"

  constructor(private http: HttpClient) { }

  public getAllSupliers() : Observable<Array<Supplier>>{
      let url = environment.apiSuppliers + this.endPoint;
      return this.http.get<Array<Supplier>>(url)
  }
  public deleteSupplier(id:number): Observable<any>{
    let url = environment.apiSuppliers + this.endPoint + id.toString();
    return this.http.delete(url)
  }
  public addSupplier(newSupplier: Supplier): Observable<any>{
    let url = environment.apiSuppliers + this.endPoint;
    return this.http.put(url,newSupplier)
  }
  public updateSupplier(modifiedSupplier: Supplier): Observable<any>{
    let url = environment.apiSuppliers + this.endPoint + modifiedSupplier.SupplierID.toString();
    return this.http.put(url,modifiedSupplier)
  }
}
