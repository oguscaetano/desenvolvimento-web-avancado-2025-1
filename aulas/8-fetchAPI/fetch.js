const fetchAPI = async (endpoint) => {
    try {
        const resposta = await fetch(`http://viacep.com.br/ws/${endpoint}/json/`);
        const dados = await resposta.json();

        console.log(dados);

    } catch (error) {
        console.error("Erro na requisição.", error);
    }
}

fetchAPI(81220180);

