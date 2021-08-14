import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Candidate } from "../models/candidates.model";


@Injectable()
export class CandidateService {

    constructor(private httpClient: HttpClient) {}

    getAll(): Observable<Candidate[]> {
        return this.httpClient.get<Candidate[]>('http://localhost:33301/api/Candidates');
    }

    getCandidate(id: number): Observable<Candidate> {
        return  this.httpClient.get<Candidate>('http://localhost:33301/api/Candidates/' + id);
    }
}