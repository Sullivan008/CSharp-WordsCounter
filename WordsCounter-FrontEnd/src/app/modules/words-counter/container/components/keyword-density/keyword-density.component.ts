import { Component, Input } from '@angular/core';
import { Observable } from 'rxjs';

import { KeywordDensityItem } from '../../../models/keyword-density-item.model';

@Component({
  selector: 'words-counter-keyword-density',
  templateUrl: './keyword-density.component.html',
  styleUrls: ['./keyword-density.component.scss'],
})
export class KeywordDensityComponent {
  @Input() panelTitle: string;
  @Input() keywordDensityData: Observable<KeywordDensityItem[]>;
}
