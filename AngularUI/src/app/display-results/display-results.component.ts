import { Component, Input, OnInit } from '@angular/core';
import { Candidate } from '../models/candidates.model';
import { Constituency } from '../models/constituencies.model';
import { CandidateService } from '../services/candidate.service';

@Component({
  selector: 'app-display-results',
  templateUrl: './display-results.component.html',
  styleUrls: ['./display-results.component.css']
})
export class DisplayResultsComponent implements OnInit {
  @Input() constituency: Constituency;
  isHidden = false;
  total: number = 0;
  candidateError: Candidate[] = [];  // predstavlja kandidate koji nemaju rezultata
  candidates: Candidate[];  // predstavlja sve kandidate
  array: number[] = []; // predstavlja kandidatove id-ove iz rezultata
  constructor(private _candidateService: CandidateService) { }

  ngOnInit(): void {
    for (let i = 0; i < this.constituency.results.length; i++) {
      this.total = this.total + this.constituency.results[i].votes;
    }

    for (let i = 0; i < this.constituency.results.length; i++) {
      this.array.push(this.constituency.results[i].candidate.id)
    }

    if (this.constituency.results.length < 5) {
      this._candidateService.getAll().subscribe((list) => {
        this.candidates = list;
        for (let i = 0; i < this.candidates.length; i++) {
          if (this.array.includes(this.candidates[i].id) === false) {
            this._candidateService.getCandidate(this.candidates[i].id).subscribe(
              (candidate) => { this.candidateError.push(candidate); }
            );
          }
        }
      });
    }
  }
}
