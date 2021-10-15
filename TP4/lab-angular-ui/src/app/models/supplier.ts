export class Supplier{
    SupplierID!: number;
    CompanyName!: string;
    ContactName!: string;
    Address!: string;
    City!: string;
    Country!: string;

    constructor(){
        this.SupplierID = 0;
        this.CompanyName = "";
        this.ContactName = "";
        this.Address = "";
        this.City = "";
        this.Country = "";
    }
}