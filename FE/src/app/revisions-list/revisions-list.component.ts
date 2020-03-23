import { Component, OnInit } from '@angular/core';
import { GetRevisionResult } from './GetRevisionResult';
import { HttpClient } from '@angular/common/http';
import { APIService } from '../APIServices';

@Component({
  selector: 'app-revisions-list',
  templateUrl: './revisions-list.component.html',
  styleUrls: ['./revisions-list.component.scss']
})
export class RevisionsListComponent implements OnInit {
  revisions: GetRevisionResult
  constructor(
    public apiService: APIService
  ) { }

  async ngOnInit() {
    this.revisions= await this.apiService.getRevisionsList(1);
  }

}
