import { Component, OnInit } from '@angular/core';
import { CreateClientCommand } from './CreateClientCommand';
import { HttpClient } from '@angular/common/http';
import { APIService } from '../APIServices';

@Component({
  selector: 'app-create-client',
  templateUrl: './create-client.component.html',
  styleUrls: ['./create-client.component.scss']
})
export class CreateClientComponent implements OnInit {
firstName:string;
lastName:string;
phoneNumber:string;
email:string;
password:string;
client:CreateClientCommand;
  constructor(
    public ApiService:APIService
  ) { }

  ngOnInit(): void {
  }

  async onSubmit(){
    let client=<CreateClientCommand>{
      firstName:this.firstName,
      lastName:this.lastName,
      phoneNumber:this.phoneNumber,
      email:this.email,
      password:this.password
    }
    await this.ApiService.createClient(client);
  }

}
