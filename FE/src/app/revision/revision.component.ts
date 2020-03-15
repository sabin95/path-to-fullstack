import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {GetCarResult} from "./GetCarResult";
import { RevisionCreateCommand } from './RevisionCreateCommand';

@Component({
  selector: 'app-revision',
  templateUrl: './revision.component.html',
  styleUrls: ['./revision.component.scss']
})
export class RevisionComponent implements OnInit {
  cars:GetCarResult
  selectedCarId:number
  problemDetails:string
  
  
  constructor(
    public http:HttpClient
  ) { }
  
  async ngOnInit() {
    this.cars = await this.http.get<GetCarResult>("http://localhost:5000/api/clients/1/cars").toPromise()
  }

  async onSubmit() {
    console.dir(this.selectedCarId);
    let revision = <RevisionCreateCommand> {
      carId:+this.selectedCarId,
      problemDetails:this.problemDetails
    }
    await this.http.post("http://localhost:5000/api/clients/1/Revisions", revision).toPromise();
  }



}
