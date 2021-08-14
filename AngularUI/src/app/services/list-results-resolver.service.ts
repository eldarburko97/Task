import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from "@angular/router";
import { Observable } from "rxjs";
import { Constituency } from "../models/constituencies.model";
import { ConstituencyService } from "./constituency.service";



@Injectable()
export class ListResultsResolverService implements Resolve<Constituency[]> {
    constructor(private _constituencyService: ConstituencyService) { }

    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<Constituency[]> {
        return this._constituencyService.getAll();
    }
}