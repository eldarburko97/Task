import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable()
export class FileService {

    constructor(private httpClient: HttpClient) { }

    upload(file: File): Observable<void> {
        let input = new FormData();
        input.append("file", file);
        return this.httpClient.post<void>("http://localhost:33301/api/Files", input);
    }
}