import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ClientesComponent } from './clientes/clientes/clientes.component';
import { ClienteEditComponent } from './clientes/cliente-edit/cliente-edit.component';

const routes: Routes = [
  { 
    path :"clientes", 
    component : ClientesComponent 
  },
  {
    path:"cliente",
    component : ClienteEditComponent
  },
  {
    path:"cliente/:id",
    component : ClienteEditComponent
  },
  {
    path:"",
    pathMatch:"full",
    redirectTo:"clientes"
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
