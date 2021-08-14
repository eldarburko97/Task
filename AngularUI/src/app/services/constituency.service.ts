import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Constituency } from "../models/constituencies.model";

@Injectable()
export class ConstituencyService {

    constructor(private httpClient: HttpClient){

    }

    getAll(): Observable<Constituency[]>{
        return this.httpClient.get<Constituency[]>('http://localhost:33301/api/Constituencies');
    }
}