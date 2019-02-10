import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { MatSnackBar } from '@angular/material';
import { Acao } from '../acoes.model';
import { AcoesService } from '../acoes.service';
import { formatDate } from '@angular/common';
import { GetDataUS } from '../../shared/data.helper'
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-acaoedit',
  templateUrl: './acaoedit.component.html',
  styleUrls: ['./acaoedit.component.sass']
})
export class AcaoeditComponent implements OnInit {

  constructor(
    private _formBuilder: FormBuilder,
    private _service: AcoesService,
    private _router: Router,
    private _route: ActivatedRoute,
    private _snackBar: MatSnackBar
  ) { }

  //#region propriedades

  public acaoForm: FormGroup;
  public mask: string;
  public placeHolderCnpjCpf: string;
  public acaoFormulario: string;
  public formIsChanged: boolean = false;
  public valorInicialJson: string;
  
  //#endregion

  //#region Implements

  ngOnInit() {
    this.configuraFormulario();
    this.observaQueryString();
  }

  //#endregion
  
  //#region Acções

  onSalvar(event) {
    event.preventDefault();

    var acao: Acao = this.acaoForm.getRawValue();
    acao.dataCotacao = GetDataUS(acao.dataCotacao, true);

    if (acao.id > 0) {
      this.alterar(acao);
    } else {
      acao.id =0;
      this.incluir(acao);
    }
  }

  //#endregion
  
  //#region Métodos

  private incluir(acao: Acao) {
    this._service.post(acao)
      .subscribe(() => {
        this._router.navigate(["acoes"]);
      }, error => {
        this._snackBar.open("Falha ao incluir a ação", "Fechar", {
          duration: 2000,
        });
      });
  }

  private alterar(acao: Acao) {
    this._service.put(acao)
      .subscribe(() => {
        this._router.navigate(["acoes"]);
      }, (error: HttpErrorResponse)  => {
        console.log(error);
        this._snackBar.open("Falha ao alterar a ação", "Fechar", {
          duration: 2000,
        });
      });
  }

  private observaQueryString() {
    this._route.params.subscribe(params => {
      if (params.id) {

        this.acaoFormulario = "Alterar"
        this.formIsChanged = false;

        let id: number = params.id;
        this._service.getById(id).subscribe(cliente => {
          this.carregaDadosClienteDoPost(cliente);
        });
      } else {
        this.acaoFormulario = "Novo"
        this.formIsChanged = true;
        this.acaoForm.get("dataCotacao").setValue(new Date().toLocaleDateString());
      }
    });
  }

  private carregaDadosClienteDoPost(acao: Acao) {
    acao.dataCotacao = formatDate(acao.dataCotacao, "dd/MM/yyyy", "en");
    this.acaoForm.setValue(acao);
    this.acaoForm.valueChanges
      .subscribe((acao: Acao) => {
        var valorAlteradoJSON = JSON.stringify(acao);
        if (this.valorInicialJson == undefined) {
          this.valorInicialJson = valorAlteradoJSON;
        }
        this.formIsChanged = this.valorInicialJson !== valorAlteradoJSON;
      });
  }

  private configuraFormulario() {
    this.acaoForm = this._formBuilder.group({
      id: [''], 
      codigoDaAcao: ['', Validators.required],
      dataCotacao: ['', [Validators.required, Validators.pattern(/\d{8}/)]],
      valor: ['', Validators.required],
    });
  }

  //#endregion
}