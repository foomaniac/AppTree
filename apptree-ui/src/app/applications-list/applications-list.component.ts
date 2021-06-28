import { Component, OnInit } from '@angular/core';
import { Application } from '../models/application';
import { ApplicationService } from '../services/application-service';

@Component({
  selector: 'app-applications-list',
  templateUrl: './applications-list.component.html',
  styleUrls: ['./applications-list.component.css']
})
export class ApplicationsListComponent implements OnInit {
  applications: Application[];

  constructor(private appService: ApplicationService) { }

  ngOnInit(): void {
    this.loadApplications();
  }

  private loadApplications(){
    this.appService.getAllApplications().subscribe(apps => this.applications = apps);
  }

}
