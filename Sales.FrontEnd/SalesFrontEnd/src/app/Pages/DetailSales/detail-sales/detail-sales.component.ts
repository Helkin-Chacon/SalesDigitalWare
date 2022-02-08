import { Component, Input, AfterViewInit } from '@angular/core';
import DataSource from 'devextreme/data/data_source';
import ArrayStore from 'devextreme/data/array_store';
import { InvoiceService } from 'src/app/Services/invoice.service';
import { Invoice } from 'src/app/Interfaces/invoice.interface';

@Component({
  selector: 'app-detail-sales',
  templateUrl: './detail-sales.component.html',
  styleUrls: ['./detail-sales.component.scss']
})
export class DetailSalesComponent implements AfterViewInit {
  @Input() key: number;

  detailsDataSource: DataSource;

  details: Task[];

  constructor(private service: InvoiceService) {
    this.tasks = service.get();
  }

  ngAfterViewInit() {
    this.tasksDataSource = new DataSource({
      store: new ArrayStore({
        data: this.tasks,
        key: 'ID',
      }),
      filter: ['EmployeeID', '=', this.key],
    });
  }

  completedValue(rowData) {
    return rowData.Status == 'Completed';
  }
}
