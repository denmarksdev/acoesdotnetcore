import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material';
import { AcoesService } from '../acoes.service';

@Component({
  selector: 'app-acoes',
  templateUrl: './acoes.component.html',
  styleUrls: ['./acoes.component.sass']
})
export class AcoesComponent implements OnInit {

  constructor(
    public service: AcoesService,
    private _router: Router,
    private snackBar: MatSnackBar
  ) { }

  ngOnInit() {
    this.service.getAll();
  }

  //#region  Ações

  onIncluir() {
    this._router.navigate(["acao"]);
  }

  onAlterar(id: number) {
    this._router.navigate(["acao/" + id])
  }

  onExcluir(id: number, codigo:string) {

    this.snackBar
      .open(`Excluir a acao código ${codigo}?`, "Confirmar", {
        duration: 3000
      })
      .onAction().subscribe(() => {
        this.service.delete(id)
          .subscribe(() => {
            this.service.getAll();
          }, error => {
            this.snackBar
              .open("Falha ao excluir o acao", "Fechar", {duration:2000})
          })
      });
  }
  
  
  //#endregion
}
