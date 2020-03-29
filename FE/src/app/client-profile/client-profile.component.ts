import { Component, OnInit } from '@angular/core';
import { GetClientResult } from './GetClientResult';
import { APIService } from '../APIServices';
import { GetCarResult } from '../revision/GetCarResult';

@Component({
  selector: 'app-client-profile',
  templateUrl: './client-profile.component.html',
  styleUrls: ['./client-profile.component.scss']
})
export class ClientProfileComponent implements OnInit {
client:GetClientResult
cars:GetCarResult
  constructor(
    public apiService: APIService
    ) { }

  async ngOnInit(){
    this.client= await this.apiService.getClientDetails(1);
    this.cars= await this.apiService.getCarsForClient(1);
  }

}
