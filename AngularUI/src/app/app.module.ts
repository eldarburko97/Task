import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { UploadFilesComponent } from './upload-files/upload-files.component';
import { FileService } from './services/file.services';
import { ListResultsComponent } from './list-results/list-results.component';
import { ConstituencyService } from './services/constituency.service';
import { CandidateService } from './services/candidate.service';
import { DisplayResultsComponent } from './display-results/display-results.component';
import { ListResultsResolverService } from './services/list-results-resolver.service';

@NgModule({
  declarations: [
    AppComponent,
    UploadFilesComponent,
    ListResultsComponent,
    DisplayResultsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', redirectTo: '/list', pathMatch: 'full'},
      { path: 'list', component: ListResultsComponent,  resolve: { resultList: ListResultsResolverService}}
    ])
  ],
  providers: [FileService,ConstituencyService, CandidateService, ListResultsResolverService],
  bootstrap: [AppComponent]
})
export class AppModule { }
