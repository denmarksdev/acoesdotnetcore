import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { MatSnackBar } from '@angular/material';
import { OrdemService } from '../ordem.service';
import { Ordem, ORDEM_COMPRA, ORDEM_VENDA } from '../ordem-model';
import { formatDate } from '@angular/common';
import { getDataUS, getDataAtualBR } from '../../shared/helpers/data.helper'
import { ClienteService } from 'src/app/clientes/cliente.service';
import { AcoesService } from 'src/app/acoes/acoes.service';

@Component({
  selector: 'app-ordem-edit',
  templateUrl: './ordem-edit.component.html',
  styleUrls: ['./ordem-edit.component.sass']
})
export class OrdemEditComponent implements OnInit {

  constructor(
    private _formBuilder: FormBuilder,
    private _service: OrdemService,
    public clienteService: ClienteService,
    private _acaoService: AcoesService,
    private _router: Router,
    private _route: ActivatedRoute,
    private _snackBar: MatSnackBar
  ) {
  }

  //#region membros

  public ordemForm: FormGroup;
  public mask: string;
  public acaoFormulario: string;
  public formIsChanged: boolean = false;
  public valorInicialJSON: string;
  public acaoNaoLocalizada: boolean;
  public tiposOrdens = [
    {
      valor: ORDEM_COMPRA,
      nome: "Compra"
    },
    {
      valor: ORDEM_VENDA,
      nome: "Venda"
    }
  ]

  //#endregion

  //#region Implements   

  ngOnInit() {
    this.clienteService.getAll();

    this.observaQueryString();
  }

  //#endregion

  //#region  Ações

  onSalvar(event) {
    event.preventDefault();

    var ordem: Ordem = this.ordemForm.getRawValue();
    ordem.dataOrdem = getDataUS(ordem.dataOrdem, true);
    if (ordem.tipoOrdem == ORDEM_VENDA){
      ordem.dataCompra = getDataUS(ordem.dataCompra, true);
    }
    
    this.incluir(ordem);
  }

  onVoltar(event) {
    event.preventDefault();
    this._router.navigate(["ordens"])

  }

  //#endregion

  //#region Métodos

  private incluir(ordem: Ordem) {
    this._service.post(ordem)
      .subscribe(() => {
        this._router.navigate(["ordens"], { replaceUrl: true });
      }, error => {
        this._snackBar.open("Falha ao incluir a ordem", "Fechar", {
          duration: 2000,
        });
      });
  }

  private observaQueryString() {
    this._route.params.subscribe(params => {
      if (params.id) {
        this.configuraFormulario(true);
        this.acaoFormulario = "Consulta"
        let id: number = params.id;
        this._service.getById(id).subscribe(ordem => {
          this.carregaDadosOrdemDoPost(ordem);
        });

      } else {
        this.configuraFormulario(false);
        this.acaoFormulario = "Nova"
        this.ordemForm.get("dataOrdem").setValue(getDataAtualBR(true));
        this.ordemForm.get("codigoAcao")
          .valueChanges
          .subscribe((codigoAcao) => {
            this._acaoService.acaoExiste(codigoAcao)
              .subscribe(existe => {
                this.acaoNaoLocalizada = !existe;
              })
          })
        this.ordemForm.get("tipoOrdem").valueChanges
          .subscribe(tipo => {
              console.log(tipo);
              if (tipo == ORDEM_COMPRA ){
                this.ordemForm.get("dataCompra").setErrors({'incorrect': true});;
                this.ordemForm.get("dataCompra").clearValidators();
                this.ordemForm.get("dataCompra").updateValueAndValidity();
              }else{
                this.ordemForm.get("dataCompra").setValidators([ Validators.required])
                this.ordemForm.get("dataCompra").updateValueAndValidity();
              }
          })
      }
    });
  }

  private carregaDadosOrdemDoPost(ordem: Ordem) {
    ordem.dataCompra = formatDate(ordem.dataCompra, "dd/MM/yyyy", "en");
    ordem.dataOrdem = formatDate(ordem.dataOrdem, "dd/MM/yyyy", "en");
    this.ordemForm.setValue(ordem);
  }

  private configuraFormulario(consulta: boolean) {
    this.ordemForm = this._formBuilder.group({
      id: [0],
      tipoOrdem: [{ value: '', disabled: consulta }, Validators.required],
      dataOrdem: [{ value: '', disabled: consulta }, [Validators.required, Validators.pattern(/\d{8}/)]],
      dataCompra: [{ value: '', disabled: consulta }, [Validators.required, Validators.pattern(/\d{8}/)]],
      idCliente: [{ value: '', disabled: consulta }, Validators.required],
      codigoAcao: [{ value: '', disabled: consulta }, Validators.required],
      quantidadeAcoes: [{ value: '', disabled: consulta }, [Validators.required, Validators.min(1)]],
      valorOrdem: [{ value: 0, disabled: true  }],
      taxaCorretagem: [{ value: 0, disabled: true }],
      impostoRenda: [{ value: 0, disabled: true }]
    });
    
  }

  //#endregion

}
