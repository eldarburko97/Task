import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { FileService } from '../services/file.services';

@Component({
  selector: 'app-upload-files',
  templateUrl: './upload-files.component.html',
  styleUrls: ['./upload-files.component.css']
})
export class UploadFilesComponent implements OnInit {
  @ViewChild('fileInput') fileInput: any;
  constructor(private fileService: FileService, private _router: Router) { }

  ngOnInit(): void {
  }

  onClick() {
    let nativeElement: HTMLInputElement = this.fileInput.nativeElement;
    let file = nativeElement.files[0];
    if(file)
    {
      this.fileService.upload(file).subscribe();  
      window.location.reload();
    }
    else console.log("Niste unijeli file");
  }

}
