import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ShopPanelModule } from './components/shop-panel/shop-panel.module';
import { FormModule } from './forms/form.module';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ShopPanelModule,
    FormModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})

export class AppModule { }
