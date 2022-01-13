import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { HomeList } from 'src/app/models/shop-models/home-list.model';
import { ListsService } from 'src/app/services/shop-panel-services/lists.service';

@Component({
  selector: 'app-add-lists',
  templateUrl: './add-lists.dialog.html',
  styleUrls: ['./add-lists.dialog.scss']
})
export class AddListsDialog implements OnInit {
  public homeList: HomeList = {} as HomeList;
  private isEditMode = false;

  constructor(
    private readonly _dialogRef: MatDialogRef<HomeList>,
    private readonly _listsService: ListsService,
    @Inject(MAT_DIALOG_DATA) public editList?: HomeList,
  ) { }

  ngOnInit(): void {
    this.homeList.isVisible = true;
    if (this.editList) {
      this.homeList = JSON.parse(JSON.stringify(this.editList));
      this.isEditMode = true;
    }
  }

  public onCloseClick(): void {
    this._dialogRef.close();
  }

  public async onSaveClick() {
    if (!this.isEditMode) {
      await this._listsService.add(this.homeList);
      this.editList = {} as HomeList;
      this._dialogRef.close(this.editList);
    }
    else {
      await this._listsService.edit(this.homeList);
      this.editList = this.homeList;
      this._dialogRef.close();
    }
  }
}
