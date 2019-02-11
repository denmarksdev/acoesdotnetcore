import { FormControl } from '@angular/forms';

export function minValidator(c: FormControl, valorMinimo:number ) {

  return c.value >= valorMinimo ? null : {
    minValidator: {
      valid: false
    }
  };
}