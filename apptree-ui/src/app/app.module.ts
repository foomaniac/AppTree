import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { ApplicationsListComponent } from './applications-list/applications-list.component';
import { DataViewModule } from 'primeng/dataview';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { MenuModule } from 'primeng/menu';
import { HomeComponent } from './home/home.component';
import {TableModule} from 'primeng/table';

@NgModule({
  declarations: [
    AppComponent,
    ApplicationsListComponent,
    NavMenuComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    DataViewModule,
    MenuModule,
    TableModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
