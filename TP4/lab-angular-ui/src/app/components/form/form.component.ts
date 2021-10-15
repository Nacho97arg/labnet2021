import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';

import { SupplierApiService } from 'src/app/services/supplier-api-service.service';
import { FormCommunicationService } from 'src/app/services/form-communication.service';
import { Supplier } from 'src/app/models/supplier';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class FormComponent implements OnInit {

  form!: FormGroup;
  get idSupplierCtl(): AbstractControl | null{
    return this.form.get('supplierId');
  }
  get companyNameCtl(): AbstractControl | null{
    return this.form.get('companyName');
  }
  get contactNameCtl(): AbstractControl | null{
    return this.form.get('contactName');
  }
  get addressCtl(): AbstractControl | null{
    return this.form.get('address');
  }
  get cityCtl(): AbstractControl | null{
    return this.form.get('city');
  }
  get countryCtl(): AbstractControl | null{
    return this.form.get('country');
  }

  constructor(private readonly fb:FormBuilder, private readonly supplierService: SupplierApiService, private readonly formCommunication:FormCommunicationService) { }

  ngOnInit(): void {
    this.form = this.fb.group({
      supplierId: [''],
      companyName: ['',[Validators.required, Validators.maxLength(40)]],
      contactName: ['',[Validators.maxLength(30)]],
      address: ['',[Validators.maxLength(60)]],
      city: ['',[Validators.maxLength(15)]],
      country: ['',[Validators.maxLength(15)]]
    });
    this.formCommunication.supplierToPass$.subscribe( resp => {
      this.fillForm(resp);
    })
  }

  onSubmit():void{
    if (this.idSupplierCtl?.value === 0){
      let newSupplier = this.form.value;
      this.supplierService.addSupplier(newSupplier).subscribe( res =>{
        this.refreshList();
      });
    }
    else{
      let modifiedSupplier = this.mapFormToSupplier();
      this.supplierService.updateSupplier(modifiedSupplier).subscribe( res => {
        this.refreshList();
      })
    }
    this.form.reset();
  }

  fillForm(supplier:Supplier):void{
    this.form.setValue({
      supplierId: supplier.SupplierID,
      companyName: supplier.CompanyName,
      contactName: supplier.ContactName,
      address: supplier.Address,
      city: supplier.City,
      country: supplier.Country
    });
  }
  mapFormToSupplier():Supplier{
    let supplier = new Supplier();
    supplier.SupplierID = this.idSupplierCtl?.value;
    supplier.Country=this.countryCtl?.value;
    supplier.ContactName=this.contactNameCtl?.value;
    supplier.CompanyName=this.companyNameCtl?.value;
    supplier.City=this.cityCtl?.value;
    supplier.Address=this.addressCtl?.value;

    return supplier;
  }
  refreshList():void{
    this.formCommunication.refreshList(true);
  }
}
