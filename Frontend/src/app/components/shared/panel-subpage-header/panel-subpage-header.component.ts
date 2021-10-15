import { Component, Input } from '@angular/core';

@Component({
  selector: 'shared-panel-subpage-header',
  templateUrl: './panel-subpage-header.component.html',
  styleUrls: ['./panel-subpage-header.component.scss']
})
export class PanelSubpageHeaderComponent {
  @Input() subpageTitle?: string;
  constructor() { }

}
