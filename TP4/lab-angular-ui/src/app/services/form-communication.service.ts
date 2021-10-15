import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Supplier } from '../models/supplier';

@Injectable({
  providedIn: 'root'
})
export class FormCommunicationService {

  private supplierToPass:BehaviorSubject<Supplier> = new BehaviorSubject<Supplier>(new Supplier());
  public supplierToPass$ = this.supplierToPass.asObservable();

  private refresh:BehaviorSubject<Boolean> = new BehaviorSubject<Boolean>(false);
  public refresh$ = this.refresh.asObservable();

  constructor() { }

  sendSupplier(supplier:Supplier):void{
    this.supplierToPass.next(supplier);
  }
  refreshList(flag:Boolean){
    this.refresh.next(flag);
  }
}
