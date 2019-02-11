import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms'
import { NgxMaskModule} from 'ngx-mask'

import {
  MatCardModule,
  MatButtonModule,
  MatFormFieldModule,
  MatInputModule,
  MatSelectModule,
  MatSnackBarModule
} from '@angular/material'

import { OrdensComponent } from './ordens/ordens.component';
import { OrdemEditComponent } from './ordem-edit/ordem-edit.component';

import { OrdemService } from './ordem.service';

@NgModule({
  declarations: [OrdensComponent, OrdemEditComponent],
  imports: [
    CommonModule,
    MatCardModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatSnackBarModule,
    ReactiveFormsModule,
    NgxMaskModule
  ],
  exports: [
    OrdensComponent,
    OrdemEditComponent
  ],
  providers: [
    OrdemService
  ]

})
export class OrdensModule { }
