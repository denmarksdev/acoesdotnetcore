import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ReactiveFormsModule } from '@angular/forms'

import { ClientesComponent } from './clientes/clientes.component';
import { ClienteEditComponent } from './cliente-edit/cliente-edit.component';

import { ClienteService } from './cliente.service';
import { NgxMaskModule} from 'ngx-mask'

import {
  MatCardModule,
  MatButtonModule,
  MatFormFieldModule,
  MatInputModule,
  MatSelectModule,
  MatSnackBarModule
} from '@angular/material'

@NgModule({
  declarations: [
    ClientesComponent, 
    ClienteEditComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatCardModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    NgxMaskModule.forRoot(),
    MatSnackBarModule
  ],
  exports:[
    ClientesComponent
  ],
  providers:[
    ClienteService
  ]
})
export class ClientesModule { }
