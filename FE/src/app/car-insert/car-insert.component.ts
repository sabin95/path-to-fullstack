import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CarCreateCommand } from './CarCreateCommand';

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
    public http:HttpClient
  ) { }

  ngOnInit(): void {
  }

  async onSubmit() {
    let car = <CarCreateCommand> {
      brandName:this.brandName,
      modelName:this.modelName,
      plateNumber:this.plateNumber,
      registrationId:this.registrationId
    }
    await this.http.post("http://localhost:5000/api/clients/1/Cars", car).toPromise();
  }

}
