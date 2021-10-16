import { Component, OnInit } from '@angular/core';

import { Supplier } from 'src/app/models/supplier';
import { FormCommunicationService } from 'src/app/services/form-communication.service';
import { SupplierApiService } from 'src/app/services/supplier-api-service.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {
  public suppliers: Array<Supplier> = [];

  constructor(private readonly supplierService: SupplierApiService, private readonly formCommunication:FormCommunicationService) {}

  ngOnInit(): void {
    this.getSuppliers();
    
    this.formCommunication.refresh$.subscribe(resp =>{
      if (resp) {
        this.getSuppliers();
        this.formCommunication.refreshList(false);
      }
    })
  }

  private getSuppliers(): void{
    this.supplierService.getAllSupliers().subscribe( res => {
      this.suppliers = res;
    },
    error => {
      alert(error.error.Message);
    });
  }
  deleteSupplier(id:number):void{
    this.supplierService.deleteSupplier(id).subscribe( res => {
      this.getSuppliers();
    },
    error => {
      alert(error.error.Message);
    });
  }
  fillForm(supplier:Supplier):void{
    this.formCommunication.sendSupplier(supplier);
  }



}
