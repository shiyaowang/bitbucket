import { Component, OnInit } from '@angular/core';
import { NameDetailService } from '../shared/name-detail.service';
import { CommonModule } from "@angular/common";

@Component({
  selector: 'app-name-details',
  templateUrl: './name-details.component.html',
  styles: [
  ]
})
export class NameDetailsComponent implements OnInit {

  constructor(public service: NameDetailService) { }

  ngOnInit(): void {
    // this.service.refreshList();
  }

}
