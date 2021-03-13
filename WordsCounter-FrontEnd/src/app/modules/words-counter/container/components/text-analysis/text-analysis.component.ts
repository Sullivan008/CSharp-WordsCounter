import { Component } from '@angular/core';

import { TextAnalysisItemModel } from 'src/app/modules/words-counter/models/text-analysis-item.model';

@Component({
  selector: 'words-counter-text-analysis',
  templateUrl: './text-analysis.component.html',
  styleUrls: ['./text-analysis.component.scss'],
})
export class TextAnalysisComponent {
  public textAnalysisItems: TextAnalysisItemModel[] = [
    { typeName: 'Characters', quantity: 1 },
    { typeName: 'Characters without space', quantity: 2 },
    { typeName: 'Sentences', quantity: 3 },
    { typeName: 'Paragraphs', quantity: 4 },
    { typeName: 'Alphanumeric characters', quantity: 4 },
    { typeName: 'Numeric characters', quantity: 4 },
    { typeName: 'Alpha characters', quantity: 4 },
    { typeName: 'Unique words', quantity: 4 },
    { typeName: 'Short words', quantity: 4 },
    { typeName: 'Long words', quantity: 4 },
  ];
}
