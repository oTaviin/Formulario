using Microsoft.AspNetCore.Mvc;
using FormularioMySQL.Models;

namespace FormularioMySQL.Controllers
{
    [Route("[Controller]/[action]")]
    [ApiController]
    public class FormularioController : ControllerBase
    {
        private BDContexto contexto;

        public FormularioController(BDContexto bdContexto)
        {
            contexto = bdContexto;
        }

        [HttpGet]
        public List<Formulario> Listar()
        {
            return contexto.Formularios.ToList();
        }

        [HttpPost]
        public string Cadastrar([FromBody] Formulario novoFormulario)
        {
            contexto.Add(novoFormulario);
            contexto.SaveChanges();
            return "Formulário cadastrado com sucesso!";
        }

        [HttpDelete]
        public string Excluir([FromBody]int id)
        {
            Formulario dados = contexto.Formularios.FirstOrDefault(p => p.IdAluno == id);

            if (dados == null)
            {
                return "Não foi possível encontrar o ID do aluno informado!";
            }
            else
            {
                contexto.Remove(dados);
                contexto.SaveChanges();

                return "Formulário removido com sucesso!";
            }
        }
    }
}