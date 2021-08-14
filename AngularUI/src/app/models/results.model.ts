import { Candidate } from "./candidates.model";
import { Constituency } from "./constituencies.model";


export class Result {
    votes: number;
    candidate: Candidate;
    constituency: Constituency;
}