import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CreateCarCommand } from './CreateCarCommand';
import { APIService } from '../APIServices';

@Component({
  selector: 'app-car-insert',
  templateUrl: './car-insert.component.html',
  styleUrls: ['./car-insert.component.scss']
})
export class CarInsertComponent implements OnInit {
  brandName:string
  modelName:string
  plateNumber:string
  registrationId:string
  constructor(
    public apiService:APIService
  ) { }

  ngOnInit(): void {
  }

  async onSubmit() {
    let car = <CreateCarCommand> {
      brandName:this.brandName,
      modelName:this.modelName,
      plateNumber:this.plateNumber,
      registrationId:this.registrationId
    }
    await this.apiService.createCar(1,car);
  }

}
