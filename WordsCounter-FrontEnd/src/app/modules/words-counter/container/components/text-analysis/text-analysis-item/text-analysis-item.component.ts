import { Component, Input } from '@angular/core';

@Component({
  selector: 'words-counter-text-analysis-item',
  templateUrl: './text-analysis-item.component.html',
  styleUrls: ['./text-analysis-item.component.scss'],
})
export class TextAnalysisItemComponent {
  @Input() typeName: string;
  @Input() quantity: number;
}
