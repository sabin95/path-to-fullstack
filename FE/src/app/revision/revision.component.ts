import { Component, OnInit } from '@angular/core';
import {GetCarResult} from "./GetCarResult";
import { CreateRevisionCommand } from './CreateRevisionCommand';
import { APIService } from '../APIServices';

@Component({
  selector: 'app-revision',
  templateUrl: './revision.component.html',
  styleUrls: ['./revision.component.scss']
})
export class RevisionComponent implements OnInit {
  cars:GetCarResult
  selectedCarId:number
  problemDetails:string
  title:string
  
  
  constructor(
    public apiService:APIService
  ) { }
  
  async ngOnInit() {
      this.cars = await this.apiService.getCarsForClient(1);
  }

  async onSubmit() {
    console.dir(this.selectedCarId);
    let revision = <CreateRevisionCommand> {
      carId:+this.selectedCarId,
      title:this.title,
      problemDetails:this.problemDetails
    }
    await this.apiService.createRevision(1,revision);
  }



}
