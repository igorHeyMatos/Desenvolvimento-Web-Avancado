const nome = document.getElementById('nome');
const form = document.getElementById('form');
const inputCep = document.getElementById('cep');


const fetchAPI = async (endpoint) => {
    try{
        const response = await fetch(endpoint);
        const data = await response.json();
        console.log(data);
        if(data.logradouro === ''){
            nome.innerText = 'Essa cidade não tem logradouro';    
        }else{
            nome.innerText = `${data.logradouro}`;
        }
    }catch(error){
        console.error('Erro!', error);
    }
}

form.addEventListener('submit', (event) => {
    event.preventDefault();
    fetchAPI(`https://viacep.com.br/ws/${inputCep.value}/json`);
})

