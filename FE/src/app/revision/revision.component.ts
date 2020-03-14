import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {Car} from "./../Car";

@Component({
  selector: 'app-revision',
  templateUrl: './revision.component.html',
  styleUrls: ['./revision.component.scss']
})
export class RevisionComponent implements OnInit {
  cars:Car
  constructor(
    public http:HttpClient
  ) { }
  
  async ngOnInit() {
    this.cars = await this.http.get<Car>("http://localhost:5000/api/clients/1/cars").toPromise()
  }

}
