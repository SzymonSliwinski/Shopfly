import { Component, OnInit } from '@angular/core';
import { Status } from 'src/app/models/shop-models/status.model';
import { StatusService } from 'src/app/services/shared/status.service';

@Component({
  selector: 'app-change-status-dialog',
  templateUrl: './change-status-dialog.component.html',
  styleUrls: ['./change-status-dialog.component.scss']
})
export class ChangeStatusDialogComponent implements OnInit {
  newStatus: Status = {} as Status;
  statusesList!: Status[];
  constructor(private readonly _statusService: StatusService) { }

  async ngOnInit(): Promise<void> {
    this.statusesList = await this._statusService.getAll();
  }

  onAddClick() {
    if (this.newStatus.name.length === 0)
      return;
    this._statusService.add(this.newStatus);
    this.newStatus = {} as Status;
  }
}
