function limpa_formulário_cep() {
    //Limpa valores do formulário de cep.
    document.getElementById('Street').value = ("");
    document.getElementById('Neighborhood').value = ("");
    document.getElementById('City').value = ("");
    document.getElementById('State').value = ("");
}

function meu_callback(conteudo) {
    if (!("erro" in conteudo)) {
        //Atualiza os campos com os valores.
        document.getElementById('Street').value = (conteudo.logradouro);
        document.getElementById('Neighborhood').value = (conteudo.bairro);
        document.getElementById('City').value = (conteudo.localidade);
        document.getElementById('State').value = (conteudo.uf);
    } //end if.
    else {
        //CEP não Encontrado.
        limpa_formulário_cep();
        toastr.info('CEP não encontrado.')
    }
}

function pesquisacep(valor) {

    //Nova variável "cep" somente com dígitos.
    var cep = valor.replace(/\D/g, '');

    //Verifica se campo cep possui valor informado.
    if (cep != "") {

        //Expressão regular para validar o CEP.
        var validacep = /^[0-9]{8}$/;

        //Valida o formato do CEP.
        if (validacep.test(cep)) {

            //Preenche os campos com "..." enquanto consulta webservice.
            document.getElementById('Street').value = "...";
            document.getElementById('Neighborhood').value = "...";
            document.getElementById('City').value = "...";
            document.getElementById('State').value = "...";

            //Cria um elemento javascript.
            var script = document.createElement('script');

            //Sincroniza com o callback.
            script.src = 'https://viacep.com.br/ws/' + cep + '/json/?callback=meu_callback';

            //Insere script no documento e carrega o conteúdo.
            document.body.appendChild(script);

        } //end if.
        else {
            //cep é inválido.
            limpa_formulário_cep();
            toastr.info('Formato de CEP inválido.') 
        }
    } //end if.
    else {
        //cep sem valor, limpa formulário.
        limpa_formulário_cep();
    }
}