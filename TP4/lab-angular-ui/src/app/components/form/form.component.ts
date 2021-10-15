import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';

import { SupplierApiService } from 'src/app/services/supplier-api-service.service';
import { Supplier } from 'src/app/models/supplier';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class FormComponent implements OnInit {

  form!: FormGroup;

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



  constructor(private readonly fb:FormBuilder, private readonly supplierService: SupplierApiService) { }

  ngOnInit(): void {
    this.form = this.fb.group({
      companyName: ['',[Validators.required, Validators.maxLength(40)]],
      contactName: ['',[Validators.maxLength(30)]],
      address: ['',[Validators.maxLength(60)]],
      city: ['',[Validators.maxLength(15)]],
      country: ['',[Validators.maxLength(15)]]
    })
  }

  onSubmit():void{
    let newSupplier: Supplier = new Supplier();
    newSupplier.CompanyName = this.form.get('companyName')?.value;

  }

}
