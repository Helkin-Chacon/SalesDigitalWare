import { Client } from "./client.interface";
import { Product } from "./product.interface";
export interface Invoice {
    idInvoice? : number
    idProduct? : number;   
    quantity : number ;
    idClient? : number;
    identificationNumberClient? : string   
    dateInvoice? : Date;   
    costInvoice? : number;  
    detailInvoice? : DetailsInvoice[] ;
    idClientNavigation? : Client   
}

export interface DetailsInvoice{
    idDetailInvoice? : number;
    idProduct? : number;
    nameProduct? : string;
    quantityProduct? : number;
    costProduct? : number;
    dateTime? : Date;
}
