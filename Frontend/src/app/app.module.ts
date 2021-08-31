import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatMenuModule } from '@angular/material/menu';
import { PanelRoutingModule } from './components/shop-panel/panel-routing.module';
import { MainModule } from './components/shop-panel/main.module';
@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatMenuModule,
    PanelRoutingModule,
    MainModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})

export class AppModule { }
