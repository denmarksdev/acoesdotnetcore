
export interface Cliente {
    id:number,
    nome:string,
    dataNascimento:string,
    tipoPessoa:string,
    cnpjCpf:string
};

export const PESSOA_JURIDICA: string = "J";
export const PESSOA_FISICA: string = "F";