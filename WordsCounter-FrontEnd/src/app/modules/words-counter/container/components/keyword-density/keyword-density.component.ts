import { Component, Input } from '@angular/core';

import { KeywordDensityItem } from '../../../models/keyword-density-item.model';

@Component({
  selector: 'words-counter-keyword-density',
  templateUrl: './keyword-density.component.html',
  styleUrls: ['./keyword-density.component.scss'],
})
export class KeywordDensityComponent {
  @Input() panelTitle: string;

  public keywordDensities: KeywordDensityItem[] = [
    { keyword: 'Characters', quantity: 1, percentage: 0.25 },
    { keyword: 'Sentences', quantity: 3, percentage: 12.25 },
    { keyword: 'Paragraphs', quantity: 45, percentage: 34.25 },
    { keyword: 'Alphanumeric', quantity: 1, percentage: 13.25 },
    { keyword: 'Numeric', quantity: 2, percentage: 100 },
  ];
}
