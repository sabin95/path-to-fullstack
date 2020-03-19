import { Component, OnInit } from '@angular/core';
import { GetRevisionResult } from './GetRevisionResult';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-revisions-list',
  templateUrl: './revisions-list.component.html',
  styleUrls: ['./revisions-list.component.scss']
})
export class RevisionsListComponent implements OnInit {
  revisions: GetRevisionResult
  constructor(
    public http: HttpClient
  ) { }

  async ngOnInit() {
    this.revisions = await this.http.get<GetRevisionResult>("http://localhost:5000/api/clients/1/revisions").toPromise()
  }

}
