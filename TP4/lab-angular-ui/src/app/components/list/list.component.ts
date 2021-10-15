import { Component, OnInit } from '@angular/core';

import { Supplier } from 'src/app/models/supplier';
import { SupplierApiService } from 'src/app/services/supplier-api-service.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {
  public suppliers: Array<Supplier> = [];

  constructor(private supplierService: SupplierApiService) {}

  ngOnInit(): void {
    this.getSuppliers();
  }

  private getSuppliers(): void{
    this.supplierService.getAllSupliers().subscribe( res => {
      this.suppliers = res;
      console.log(this.suppliers);
    });
  }
  deleteSupplier(id:number):void{
    this.supplierService.deleteSupplier(id).subscribe( res => {
      console.log('supplier eliminado');
    });
    this.getSuppliers();
  }


}
