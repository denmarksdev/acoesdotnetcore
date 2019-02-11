export interface Ordem {
    id:number,
    idCliente:number
    codigoAcao:string,
    quantidadeAcoes:number,
    dataCompra:string,
    dataOrdem:string,
    tipoOrdem:string
    impostoRenda:number,
    valorOrdem:number,
    taxaCorretagem:number
}

export const ORDEM_COMPRA: string = "C";
export const ORDEM_VENDA: string = "V";
