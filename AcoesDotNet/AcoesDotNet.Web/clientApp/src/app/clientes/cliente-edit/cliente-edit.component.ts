import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatSelectChange, MatSnackBar } from '@angular/material';
import { ClienteService } from '../cliente.service';
import { Cliente, PESSOA_FISICA, PESSOA_JURIDICA } from '../cliente.model';
import { Router, ActivatedRoute } from '@angular/router';
import { formatDate } from '@angular/common';
import { _configFactory } from 'ngx-mask';
import { getDataUS } from '../../shared/helpers/data.helper';

const MASK_CPF = "000.000.000-00";
const MASK_CNPJ = "00.000.000/0000-00"

@Component({
  selector: 'app-cliente-edit',
  templateUrl: './cliente-edit.component.html',
  styleUrls: ['./cliente-edit.component.sass']
})
export class ClienteEditComponent implements OnInit {

  constructor(
    private _formBuilder: FormBuilder,
    private _service: ClienteService,
    private _router: Router,
    private _route: ActivatedRoute,
    private _snackBar: MatSnackBar
  ) {
  }

  //#region membros

  public clienteForm: FormGroup;
  public mask: string;
  public placeHolderCnpjCpf: string;
  public acaoFormulario: string;
  public formIsChanged: boolean = false;
  public valorInicialJson: string;
  public tiposPessoas = [
    {
      valor: PESSOA_JURIDICA,
      nome: "Jurídica"
    },
    {
      valor: PESSOA_FISICA,
      nome: "Física"
    }
  ]

  //#endregion

  //#region Implements   

  ngOnInit() {
    this.configuraFormulario();
    this.observaQueryString();
  }

  //#endregion

  //#region  Ações

  onSalvar(event) {
    event.preventDefault();

    var cliente: Cliente = this.clienteForm.getRawValue();
    cliente.dataNascimento = getDataUS(cliente.dataNascimento);

    if (cliente.id > 0) {
      this.alterar(cliente);
    } else {
      cliente.id = 0;
      this.incluirCliente(cliente);
    }
  }

  onVoltar(event){
    this._router.navigate(["clientes"])
  }

  onTipoChange(info: MatSelectChange) {
    this.setPessoaFisica(info.value);
  }

  //#endregion

  //#region Métodos

  private incluirCliente(cliente: Cliente) {
    this._service.post(cliente)
      .subscribe(() => {
        this._router.navigate(["clientes"]);
      }, error => {
        console.log(error);
        this._snackBar.open("Falha ao incluir o cliente", "Fechar", {
          duration: 2000,
        });
      });
  }

  private alterar(cliente: Cliente) {
    this._service.put(cliente)
      .subscribe(() => {
        this._router.navigate(["clientes"]);
      }, error => {
        this._snackBar.open("Falha ao alterar o cliente", "Fechar", {
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
      }
    });
  }

  private carregaDadosClienteDoPost(cliente: Cliente) {
    cliente.dataNascimento = formatDate(cliente.dataNascimento, "dd/MM/yyyy", "en");
    this.setPessoaFisica(cliente.tipoPessoa);
    this.clienteForm.setValue(cliente);
    this.clienteForm.valueChanges
      .subscribe((cliente: Cliente) => {
        var valorAlteradoJSON = JSON.stringify(cliente);
        if (!this.valorInicialJson) {
          this.valorInicialJson = valorAlteradoJSON;
        }
        this.formIsChanged = this.valorInicialJson !== valorAlteradoJSON;
      });
  }

  private configuraFormulario() {
    this.clienteForm = this._formBuilder.group({
      id: [''],
      nome: ['', Validators.required],
      dataNascimento: ['', [Validators.required, Validators.pattern(/\d{8}/)]],
      tipoPessoa: ['', Validators.required],
      cnpjCpf: ['']
    });
  }

  private setPessoaFisica(tipo: string) {
    if (tipo == PESSOA_FISICA) {
      this.mask = MASK_CPF;
      this.placeHolderCnpjCpf = "CPF";
    }
    else {
      this.mask = MASK_CNPJ;
      this.placeHolderCnpjCpf = "CNPJ";
    }
  }

  //#endregion
}