import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { DxButtonModule,
  DxDropDownBoxModule,
  DxSelectBoxModule,
  DxTextAreaModule,
  DxDateBoxModule,
  DxTextBoxModule,
  DxFormModule,
  DxDataGridModule } from 'devextreme-angular';

import { AppComponent } from './app.component';
import { SalesComponent } from './Pages/Sales/sales.component';

import { AppRoutingModule } from './app-routing.module';

@NgModule({
  declarations: [
    AppComponent,
 
    SalesComponent,
    
  ],
  imports: [
    [HttpClientModule,  ],
    BrowserModule, 
    DxButtonModule,
    DxDropDownBoxModule,
    DxSelectBoxModule,
    DxTextAreaModule,
    DxDateBoxModule,
    DxTextBoxModule,
    DxFormModule,
    DxDataGridModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
