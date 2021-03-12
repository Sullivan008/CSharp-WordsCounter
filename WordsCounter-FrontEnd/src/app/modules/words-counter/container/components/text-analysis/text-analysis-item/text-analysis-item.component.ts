import { Component, Input } from '@angular/core';

import { TextAnalysisItemModel } from 'src/app/modules/words-counter/models/text-analysis-item.model';

@Component({
  selector: 'words-counter-text-analysis-item',
  templateUrl: './text-analysis-item.component.html',
  styleUrls: ['./text-analysis-item.component.scss'],
})
export class TextAnalysisItemComponent {
  @Input() textAnalysisItem: TextAnalysisItemModel;
}
