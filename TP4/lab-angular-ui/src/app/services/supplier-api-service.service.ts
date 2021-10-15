import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable,throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

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
      return this.http.get<Array<Supplier>>(url).pipe(
        catchError(this.errorHandler));
  }
  public deleteSupplier(id:number): Observable<any>{
    let url = environment.apiSuppliers + this.endPoint + id.toString();
    return this.http.delete(url).pipe(
      catchError(this.errorHandler));
  }
  public addSupplier(newSupplier: Supplier): Observable<any>{
    let url = environment.apiSuppliers + this.endPoint;
    return this.http.put(url,newSupplier).pipe(
      catchError(this.errorHandler));
  }
  public updateSupplier(modifiedSupplier: Supplier): Observable<any>{
    let url = environment.apiSuppliers + this.endPoint + modifiedSupplier.SupplierID.toString();
    return this.http.put(url,modifiedSupplier).pipe(
      catchError(this.errorHandler));
  }

  private errorHandler(error : HttpErrorResponse){
    console.error(error.error.ExceptionMessage);    
    return throwError(error);
  }
}
