import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatMenuModule } from '@angular/material/menu';
import { MainModule } from './components/shop-panel/main.module';
import { HomeModule } from './components/shop/home.module';
import { HttpClientModule } from '@angular/common/http';
import { ShopSettingsService } from './services/shop-settings.service';


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatMenuModule,
    MainModule,
    HttpClientModule,
    HomeModule,
  ],
  providers: [ShopSettingsService],
  bootstrap: [AppComponent]
})

export class AppModule { }
