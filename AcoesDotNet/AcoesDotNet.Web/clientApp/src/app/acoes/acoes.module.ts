import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import {
  MatCardModule,
  MatButtonModule,
  MatFormFieldModule,
  MatInputModule,
  MatSnackBarModule
} from '@angular/material'

import { NgxMaskModule} from 'ngx-mask'
import { CurrencyMaskModule } from "ngx-currency-mask";

import { AcoesService } from './acoes.service';
import { AcoesComponent } from './acoes/acoes.component';
import { AcaoeditComponent } from './acaoedit/acaoedit.component';

@NgModule({
  declarations: [AcoesComponent, AcaoeditComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatCardModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatSnackBarModule,
    NgxMaskModule,
    CurrencyMaskModule
  ],
  exports: [
    AcoesComponent
  ],
  providers: [
    AcoesService
  ]
})
export class AcoesModule { }
