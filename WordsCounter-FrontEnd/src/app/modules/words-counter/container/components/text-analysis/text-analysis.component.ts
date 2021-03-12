import { Component } from '@angular/core';

import { TextAnalysisItemModel } from 'src/app/modules/words-counter/models/text-analysis-item.model';

@Component({
  selector: 'words-counter-text-analysis',
  templateUrl: './text-analysis.component.html',
  styleUrls: ['./text-analysis.component.scss'],
})
export class TextAnalysisComponent {
  public textAnalysisItems: TextAnalysisItemModel[] = [
    { type: 'Characters', value: '1 (%6,67)' },
    { type: 'Characters without space', value: '2' },
    { type: 'Sentences', value: '3' },
    { type: 'Paragraphs', value: '4' },
    { type: 'Alphanumeric characters', value: '4' },
    { type: 'Numeric characters', value: '4' },
    { type: 'Alpha characters', value: '4' },
    { type: 'Unique words', value: '4' },
    { type: 'Short words', value: '4' },
    { type: 'Long words', value: '4' },
  ];
}
