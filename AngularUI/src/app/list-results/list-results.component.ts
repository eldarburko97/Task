import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Constituency } from '../models/constituencies.model';
import { ConstituencyService } from '../services/constituency.service';

@Component({
  selector: 'app-list-results',
  templateUrl: './list-results.component.html',
  styleUrls: ['./list-results.component.css']
})
export class ListResultsComponent implements OnInit {
  constituencies: Constituency[];
  constructor(private _constituencyService: ConstituencyService, private _route: ActivatedRoute) {
    this.constituencies = _route.snapshot.data['resultList'];
   }

  ngOnInit(): void {
    // this._constituencyService.getAll().subscribe(
    //   (constituencyList) => { this.constituencies = constituencyList; }
    // );
  }

}
