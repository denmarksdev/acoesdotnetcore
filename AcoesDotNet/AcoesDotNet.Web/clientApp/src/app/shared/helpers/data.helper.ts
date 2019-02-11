export function  getDataUS(dataBr: string,addTempo:boolean= false): string {
    var ano = dataBr.substr(dataBr.length - 4);
    var mes = dataBr.substr(2, 2);
    var dia = dataBr.substr(0, 2);
    return `${ano}-${mes}-${dia}` +  (addTempo ? "T" + new Date().toLocaleTimeString():"");
}

export function getDataAtualBR(somenteNumeros:boolean= false){
    var date = new Date();

    var dataFormatada =
        `${date.getDate().toString().padStart(2,'0')}/${(date.getMonth() +1).toString().padStart(2,'0')}/${date.getFullYear()}`;

    if (somenteNumeros){
        dataFormatada = dataFormatada.trim().replace("/","").replace("/","");
    }

    console.log(dataFormatada);

    return  dataFormatada;
}