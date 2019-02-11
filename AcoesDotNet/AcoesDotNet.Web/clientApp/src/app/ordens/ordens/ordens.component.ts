import { Component, OnInit } from '@angular/core';
import { OrdemService } from '../ordem.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-ordens',
  templateUrl: './ordens.component.html',
  styleUrls: ['./ordens.component.sass']
})
export class OrdensComponent implements OnInit {

  constructor(
    public service: OrdemService,
    private _router: Router,
  ) { }

  ngOnInit() {
    this.service.getAll();
  }

  onIncluir() {

    this._router.navigate(["ordem"]);
  }

  onconsultar(id: number) {
    this._router.navigate(["ordem/" + id])
  }
}
