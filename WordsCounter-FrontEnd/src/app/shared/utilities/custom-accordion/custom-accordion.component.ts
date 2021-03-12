import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-custom-accordion',
  templateUrl: './custom-accordion.component.html',
  styleUrls: ['./custom-accordion.component.scss'],
})
export class CustomAccordionComponent implements OnInit {
  @Input() public isOpen: boolean;
  @Input() public isAnimated: boolean;
  @Input() public headerTitle: string;

  public constructor() {
    if (this.isOpen === null || this.isOpen === undefined) {
      this.isOpen = true;
    }

    if (this.isAnimated === null || this.isAnimated === undefined) {
      this.isAnimated = true;
    }
  }

  public ngOnInit(): void {}
}
