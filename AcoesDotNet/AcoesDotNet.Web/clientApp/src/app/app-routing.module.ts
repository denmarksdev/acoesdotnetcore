import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ClientesComponent } from './clientes/clientes/clientes.component';
import { ClienteEditComponent } from './clientes/cliente-edit/cliente-edit.component';
import { AcoesComponent } from './acoes/acoes/acoes.component';
import { AcaoeditComponent } from './acoes/acaoedit/acaoedit.component';
import { OrdensComponent } from './ordens/ordens/ordens.component';
import { OrdemEditComponent } from './ordens/ordem-edit/ordem-edit.component';

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
    path:"acoes",
    component : AcoesComponent
  },
  {
    path:"acao",
    component : AcaoeditComponent
  },
  {
    path:"acao/:id",
    component : AcaoeditComponent
  },
  {
    path:"ordens",
    component : OrdensComponent
  },
  {
    path:"ordem",
    component : OrdemEditComponent
  },
  {
    path:"ordem/:id",
    component : OrdemEditComponent
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
