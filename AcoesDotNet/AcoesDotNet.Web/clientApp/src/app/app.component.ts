import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.sass']
})
export class AppComponent {
  title = 'clientApp';
  aberto:boolean;
  
  constructor(private _router:Router) {
  }

  onNavegar(rota:string){
    this._router.navigate([rota]);
  }
}