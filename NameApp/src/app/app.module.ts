import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from "@angular/forms";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';

import { AppComponent } from './app.component';
import { NameDetailsComponent } from './name-details/name-details.component';
import { NameDetailFormComponent } from './name-details/name-detail-form/name-detail-form.component';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from "@angular/common";

@NgModule({
  declarations: [
    AppComponent,
    NameDetailsComponent,
    NameDetailFormComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    CommonModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
