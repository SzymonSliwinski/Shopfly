import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Profile } from 'src/app/models/shop-panel-models/profile.model';
import { ProfileService } from 'src/app/services/shop-panel-services/profile.service';

@Component({
  selector: 'app-profile-dialog',
  templateUrl: './profile.dialog.html',
  styleUrls: ['./profile.dialog.scss']
})
export class ProfileDialog implements OnInit {
  public profile: Profile = {} as Profile;
  public isEditMode: boolean = false;
  constructor(
    private readonly _dialogRef: MatDialogRef<ProfileDialog>,
    private readonly _profileService: ProfileService,
    @Inject(MAT_DIALOG_DATA) public editProfile?: Profile,
  ) { }

  ngOnInit(): void {
    if (this.editProfile) {
      this.profile = JSON.parse(JSON.stringify(this.editProfile));
      this.isEditMode = true;
    }
  }

  public onCloseClick(): void {
    this._dialogRef.close();
  }

  public async onSaveClick() {
    if (this.profile.name.length === 0)
      return;

    if (!this.isEditMode) {
      const result = this._profileService.add(this.profile);
      this._dialogRef.close(result);
    } else {
      await this._profileService.edit(this.profile);
      this.editProfile = this.profile;
      this._dialogRef.close();
    }
  }
}
