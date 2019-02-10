export function  GetDataUS(dataBr: string,addTempo:boolean= false): string {
    var ano = dataBr.substr(dataBr.length - 4);
    var mes = dataBr.substr(2, 2);
    var dia = dataBr.substr(0, 2);
    return `${ano}-${mes}-${dia}` +  (addTempo && "T" + new Date().toLocaleTimeString());
}