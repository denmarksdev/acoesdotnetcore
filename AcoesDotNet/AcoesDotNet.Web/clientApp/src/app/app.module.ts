import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule } from '@angular/common/http'

import { AppComponent } from './app.component';

import {
  MatSidenavModule,
  MatButtonModule,
} from '@angular/material'

import { ClientesModule }  from './clientes/clientes.module';
import { AcoesModule }  from './acoes/acoes.module';
import { OrdensModule } from './ordens/ordens.module';



import localPT  from '@angular/common/locales/pt'
import { registerLocaleData } from '@angular/common';
import { from } from 'rxjs';
registerLocaleData(localPT)


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    ClientesModule,
    AcoesModule,
    OrdensModule,
    MatSidenavModule,
    MatButtonModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
