import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { GetCarResult } from './revision/GetCarResult';
import { CreateRevisionCommand } from './revision/CreateRevisionCommand';
import { CreateCarCommand } from './car-insert/CreateCarCommand';
import { GetRevisionResult } from './revisions-list/GetRevisionResult';
import { CreateClientCommand } from './create-client/CreateClientCommand';

@Injectable()
export class APIService {

    constructor(private httpClient: HttpClient) {

    }

    async getCarsForClient(clientId: number) {
        let cars = await this.httpClient.get<GetCarResult>(`http://localhost:5000/api/clients/${clientId}/cars`).toPromise()
        return cars;
    }

    async createRevision(clientId: number,revisionCommand:CreateRevisionCommand)
    {
        await this.httpClient.post(`http://localhost:5000/api/clients/${clientId}/revisions`, revisionCommand).toPromise();
    }

    async createCar(clientId:number,carCommand:CreateCarCommand)
    {
        await this.httpClient.post(`http://localhost:5000/api/clients/${clientId}/Cars`, carCommand).toPromise();
    }

    async createClient(clientCommand:CreateClientCommand)
    {
        await this.httpClient.post(`http://localhost:5000/api/clients/`,clientCommand).toPromise();
    }

    async getRevisionsList(clientId:number)
    {
        let revisions = await this.httpClient.get<GetRevisionResult>("http://localhost:5000/api/clients/1/revisions").toPromise();
        return revisions;
    }
}