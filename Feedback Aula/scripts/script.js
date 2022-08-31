$(document).ready(function() {
    grid();
});

function limpar() {
    formulario.idAluno.value = '';
    formulario.nomeAluno.value = '';
    formulario.dataAula.value = '';
    formulario.nomeDisciplina.value = '';
    formulario.avaliacaoAula.value = '';
    formulario.comentarioAula.value = '';
}

function grid() {
    $.get('https://localhost:5001/Formulario/Listar')
        .done(function(resposta) { 
            for(i = 0; i < resposta.length; i++) {                
                let linha = $('<tr class="text-center"></tr>');
                
                linha.append($('<td></td>').html(resposta[i].idAluno));
                linha.append($('<td></td>').html(resposta[i].nomeAluno));
                linha.append($('<td></td>').html(resposta[i].dataAula));
                linha.append($('<td></td>').html(resposta[i].nomeDisciplina));
                linha.append($('<td></td>').html(resposta[i].avaliacaoAula));
                linha.append($('<td></td>').html(resposta[i].comentarioAula));
                
                let botaoExcluir = $('<button class="btn btn-danger"></button>').attr('type', 'button').html('Excluir').attr('onclick', 'excluir(' + resposta[i].idAluno + ')');

                let acoes = $('<td></td>');
                acoes.append(botaoExcluir);

                linha.append(acoes);
                
                $('#grid').append(linha);
            }
        })
        .fail(function(erro, mensagem, excecao) { 
            alert("Não foi possível realizar a consulta na API!");
        });
}

function excluir(id) {
    console.log(id)
    $.ajax({
        type: 'DELETE',
        url: 'https://localhost:5001/Formulario/Excluir/',
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(id),
        success: function(resposta) { 
            alert("Formulário removido com sucesso!");
            location.reload(true);
        },
        error: function(erro, mensagem, excecao) { 
            alert("Erro ao realizar a remoção deste dado!");
        }
    });
}

function cadastrar() {
    
    let Formulario = {
        idAluno: formulario.idAluno.value,
        nomeAluno: formulario.nomeAluno.value,
        dataAula: formulario.dataAula.value,
        nomeDisciplina: formulario.nomeDisciplina.value,
        avaliacaoAula: formulario.avaliacaoAula.value,
        comentarioAula: formulario.comentarioAula.value
    };

    console.log(Formulario);

    $.ajax({
        type: 'POST',
        url: 'https://localhost:5001/Formulario/Cadastrar',
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(Formulario),
        success: function() {
            alert("Formulário cadastrado com sucesso!");
            limpar();
            location.reload(true);
        },
        error: function() {
            alert("Erro ao realizar o cadastro deste Formulário!");
        }
    });
}
