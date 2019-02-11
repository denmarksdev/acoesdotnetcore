import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { BehaviorSubject } from 'rxjs';
import { Cliente } from './cliente.model'

const BASE_API = "/api/clientes";

@Injectable({
  providedIn: 'root'
})
export class ClienteService {

  constructor(private _http: HttpClient) { 
  }

  private clientes : BehaviorSubject<Cliente[]> = new BehaviorSubject([]);
  public clientes$ =  this.clientes.asObservable();

  public getAll(){
    return this._http.get<Cliente[]>(BASE_API)
      .subscribe(clientes => {
          this.clientes.next(clientes);
      })
  }

  public getById(id:number){
    return this._http.get<Cliente>(BASE_API + "/" + id );
  }

  public post(cliente){
    return this._http.post(BASE_API, cliente);
  }

  public put(cliente){
    return this._http.put(BASE_API + "/" + cliente.id,cliente);
  }

  public delete(id:number){
    return this._http.delete(BASE_API + "/" + id);
  }

}
