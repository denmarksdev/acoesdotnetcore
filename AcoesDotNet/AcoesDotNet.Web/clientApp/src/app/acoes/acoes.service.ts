import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http/';
import { BehaviorSubject } from 'rxjs';
import { Acao } from './acoes.model';

const BASE_API = "/api/acoes";

@Injectable({
  providedIn: 'root'
})
export class AcoesService {

  constructor(private _http: HttpClient) { 
  }

  private acoes : BehaviorSubject<Acao[]> = new BehaviorSubject([]);
  public acoes$ =  this.acoes.asObservable();

  public getAll(){
    return this._http.get<Acao[]>(BASE_API)
      .subscribe(acao => {
          this.acoes.next(acao);
      })
  }

  public getById(id:number){
    return this._http.get<Acao>(BASE_API + "/" + id );
  }

  public post(acao){
    return this._http.post(BASE_API, acao);
  }

  public put(acao){
    return this._http.put(BASE_API + "/" + acao.id,acao);
  }

  public delete(id:number){
    return this._http.delete(BASE_API + "/" + id);
  }

  public acaoExiste(codigo:string){
    return this._http.get<boolean>(`${BASE_API}/verifica/${codigo}`);
  }

}
