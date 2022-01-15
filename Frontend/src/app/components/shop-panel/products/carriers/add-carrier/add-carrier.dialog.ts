import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Carrier } from 'src/app/models/shop-models/carrier.model';
import { CarriersService } from 'src/app/services/shop-panel-services/carriers.service';

@Component({
  selector: 'app-add-carrier',
  templateUrl: './add-carrier.dialog.html',
  styleUrls: ['./add-carrier.dialog.scss']
})
export class AddCarrierDialog implements OnInit {
  public carrier: Carrier = {} as Carrier;
  private isEditMode = false;

  constructor(
    private readonly _dialogRef: MatDialogRef<Carrier>,
    private readonly _carriersService: CarriersService,
    @Inject(MAT_DIALOG_DATA) public editCarrier?: Carrier,
  ) { }

  ngOnInit(): void {
    this.carrier.isActive = true;
    if (this.editCarrier) {
      this.carrier = JSON.parse(JSON.stringify(this.editCarrier));
      this.isEditMode = true;
    }
  }

  public onCloseClick(): void {
    this._dialogRef.close();
  }

  public async onSaveClick() {
    if (!this.isEditMode) {
      await this._carriersService.add(this.carrier);
      this.carrier = {} as Carrier;
      this._dialogRef.close(this.carrier);
    }
    else {
      await this._carriersService.edit(this.carrier);
      this.editCarrier = this.carrier;
      this._dialogRef.close();
    }
  }

}
