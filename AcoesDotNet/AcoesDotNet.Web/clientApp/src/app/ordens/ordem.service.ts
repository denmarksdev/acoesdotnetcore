import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject } from 'rxjs';
import { Ordem } from './ordem-model';

const BASE_API = "/api/ordens";

@Injectable({
  providedIn: 'root'
})
export class OrdemService {

  constructor(private _http: HttpClient) {
  }

  private ordens: BehaviorSubject<Ordem[]> = new BehaviorSubject([]);
  public ordens$ = this.ordens.asObservable();

  public getAll() {
    return this._http.get<Ordem[]>(BASE_API)
      .subscribe(ordens => {
        this.ordens.next(ordens);
      })
  }

  public getById(id: number) {
    return this._http.get<Ordem>(BASE_API + "/" + id);
  }

  public post(ordem) {
    return this._http.post(BASE_API, ordem);
  }
}