import { Component, OnInit } from '@angular/core';
import { PrimeNGConfig } from 'primeng/api';
import { Application } from './models/application';
import { ApplicationService } from './services/application-service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'apptree-ui';
  applications: Application[];

  constructor(
    private primengConfig: PrimeNGConfig,
    private appService: ApplicationService)
    {}

  ngOnInit(): void {
     this.primengConfig.ripple = true;
     this.loadApplications();
  }
  
  private loadApplications(){
    this.appService.getAllApplications().subscribe(apps => this.applications = apps);
  }

}
