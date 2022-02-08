import { Component, OnInit } from '@angular/core';
import { Client } from 'src/app/Interfaces/client.interface';
import { ClientService } from 'src/app/Services/client.service';
import { ProductService } from 'src/app/Services/product.service';
import { Product } from 'src/app/Interfaces/product.interface';
import { FormGroup, FormBuilder, Validators } from '@angular/forms'; 
import { InvoiceService } from 'src/app/Services/invoice.service';
import { Invoice } from 'src/app/Interfaces/invoice.interface';
import { DetailsInvoice } from 'src/app/Interfaces/invoice.interface';

@Component({
  selector: 'app-sales',
  templateUrl: './sales.component.html',
  styleUrls: ['./sales.component.scss']
})
export class SalesComponent implements OnInit {
  clients : Client[] = [];  
  products : Product[] = [];
  details : DetailsInvoice[] = [];
  form!: FormGroup;

  detail : DetailsInvoice = {};
  quantity: number = 0;
  valid : boolean = false;
  costinvoice : number = 0;

  invoices : Invoice[] = [];
  invoice : Invoice = { quantity : 0  };
  buttonOptions = 
  {
    text: "Submit",
    onClick: "addProd()",
  }

  buttonOp = {
    text: "Submit",
    onClick: "SaveInvoice()",
  }
   
  constructor(private client_s : ClientService,
        private product_s : ProductService,
        private invoice_s : InvoiceService)
   { 
   

   }

  ngOnInit(): void {
    this.getClients();
    this.getProducs();
    this.getInvoice ();
    this.invoice  = { idClient : 0,
      idProduct : 0,
      quantity : 0,

      
    };
    this.details = []
    
  }
  

  validaciones() : boolean {
    if(this.invoice.idClient == 0){
      alert("Seleccione un cliente");
      return false;
    }
    if(this.invoice.idProduct == 0){
      alert("Seleccione un producto");
      return false;

    }
    if(this.invoice.quantity == 0){
      alert("Ingrese una cantidad de Producto");
      return false;

    }
    return true;
  }

    SaveInvoice(e:any)
    { 
      this.valid= this.validaciones();
      if(!this.valid){
        return
      } 
      if(this.details.length == 0){
        alert("Seleccione un producto minimo")
        return;
      }
      this.invoice.costInvoice = this.costinvoice
      this.invoice.detailInvoice = this.details   
      this.clients.forEach(element => {
        if(element.idClient == this.invoice.idClient){
          this.invoice.identificationNumberClient = element.identificationNumberClient
        }
        
      });
      this.invoice_s.setInvoice(this.invoice).subscribe(res =>{
        this.getInvoice();
        this.details = []
        this.invoice = {
          idClient : 0,
      idProduct : 0,
      quantity : 0,
        }
      
        
      })
      
      
      
    }

    addProd(e:any){    
    this.detail  = {};
    this.valid= this.validaciones();
    if(!this.valid){
      return
    }    
    this.products.forEach(element => {
      if(this.invoice.idProduct == element.idProduct){
        if(this.invoice.quantity <= element.stockProduct){
          this.detail.idProduct = element.idProduct,   
          this.detail.quantityProduct =  this.invoice.quantity,
          this.detail.costProduct = element.saleCostProdutc * this.invoice.quantity,
          this.detail.idDetailInvoice = 0,
          this.detail.nameProduct = element.nameProduct,
          
          this.costinvoice =  this.costinvoice + this.detail.costProduct,
          this.details.push(this.detail)
        }      
        else
        {
          alert("Solo quedan disponibles " + element.stockProduct + " " + element.nameProduct );
          return;
        }
      }
    });



    this.detail = {}
    
  }

  getInvoice(){
    
    this.invoice_s.getInvoice().subscribe(x => {
      this.invoices = x
    });
  }

  getClients(){
    
    this.client_s.getClient().subscribe(x => {
      this.clients = x
    });
  }

  getProducs(){
    this.product_s.getProduct().subscribe(x =>{
      this.products = x
    });
  }
  

}
