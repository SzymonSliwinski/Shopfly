import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Status } from 'src/app/models/shop-models/status.model';
import { StatusService } from 'src/app/services/shared/status.service';

@Component({
  selector: 'app-change-status-dialog',
  templateUrl: './change-status-dialog.component.html',
  styleUrls: ['./change-status-dialog.component.scss']
})
export class ChangeStatusDialogComponent implements OnInit {
  statusesList: Status[] = [];
  selectedStatusId!: number;
  isLoaded = false;
  constructor(
    private readonly _statusService: StatusService,
    private _dialogRef: MatDialogRef<ChangeStatusDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public payload: { actualStatus: string, orderId: number }
  ) { }

  async ngOnInit(): Promise<void> {
    this.statusesList = await this._statusService.getAll();
    this.selectedStatusId = this.statusesList.find(c => c.name === this.payload.actualStatus)!.id;
    this.isLoaded = true;
  }

  async onSaveClick() {
    await this._statusService.changeStatusForOrder(this.payload.orderId, this.selectedStatusId);
    this._dialogRef.close(this.statusesList.find(c => c.id === this.selectedStatusId)!.name);
  }
}
