import { Component, Input } from '@angular/core';

import { KeywordDensityItem } from 'src/app/modules/words-counter/models/keyword-density-item.model';

@Component({
  selector: 'words-counter-keyword-density-item',
  templateUrl: './keyword-density-item.component.html',
  styleUrls: ['./keyword-density-item.component.scss'],
})
export class KeywordDensityItemComponent {
  @Input() keywordDensityItem: KeywordDensityItem;
}
