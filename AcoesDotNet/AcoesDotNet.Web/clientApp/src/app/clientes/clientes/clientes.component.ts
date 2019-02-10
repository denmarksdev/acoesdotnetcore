import { Component, OnInit } from '@angular/core';
import { ClienteService } from '../cliente.service';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material';

@Component({
  selector: 'app-clientes',
  templateUrl: './clientes.component.html',
  styleUrls: ['./clientes.component.sass']
})
export class ClientesComponent implements OnInit {

  constructor(
    public service: ClienteService,
    private _router: Router,
    private snackBar: MatSnackBar
  ) { }

  ngOnInit() {
    this.service.getAll();
  }

  onIncluir() {

    this._router.navigate(["cliente"]);
  }

  onAlterar(id: number) {
    this._router.navigate(["cliente/" + id])
  }

  onExcluir(id: number) {

    this.snackBar
      .open(`Excluir o cliente código ${id}?`, "Confirmar", {
        duration: 3000
      })
      .onAction().subscribe(() => {
        this.service.delete(id)
          .subscribe(() => {
            this.service.getAll();
          }, error => {
            this.snackBar
              .open("Falha ao excluir o cliente", "Fechar", {duration:2000})
          })
      });
  }
}
