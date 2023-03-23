using AtividadeApi.Data;
using AtividadeApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AtividadeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtividadeController : ControllerBase
    {
        private readonly AtividadesContext _context;

        public AtividadeController(AtividadesContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("/atividades")]
        public async Task<ActionResult> CriarAtividade(Atividade atividade)
        {
            await _context.Atividades.AddAsync(atividade); // Adiciona a atividade na base de dados

            await _context.SaveChangesAsync();
            return Ok(new
            {
                data = atividade,
                sucesss = true,
                message = "Atividade Adicionada na base de dados."
            });
        }

        [HttpPut]
        [Route("/atividades")]
        public async Task<ActionResult> UpdateAtividade(Atividade atividade)
        {
            var dbAtividade =  await _context.Atividades.FindAsync(atividade.Id); // Busca a atividade na base de dados

            if(dbAtividade == null)
            {
                return NotFound("Atividade não encontrada na base de dados.");
            }


            dbAtividade.NomeAtividade = atividade.NomeAtividade;
            dbAtividade.InicioAtividade = atividade.InicioAtividade;
            dbAtividade.FimAtividade = atividade.FimAtividade;
            dbAtividade.HorasAtividade = dbAtividade.HorasAtividade;

            await _context.SaveChangesAsync();

            return Ok(new
            {
                data = dbAtividade,
                sucesss = true,
                message = "Atividade Atualizada."
            });

        }

        [HttpDelete]
        [Route("/atividades")]
        public async Task<ActionResult> DeleteAtividade(int Id)
        {
            var dbAtividade = await _context.Atividades.FindAsync(Id); // Busca a atividade na base de dados

            if (dbAtividade == null)
            {
                return NotFound("Atividade não encontrada na base de dados.");
            }

             _context.Atividades.Remove(dbAtividade); // Remove da base de dados
           
            await _context.SaveChangesAsync();

            return Ok(new
            {
                sucesss = true,
                message = "Atividade deletada da base de dados."
            });

        }

        [HttpGet]
        [Route("/atividades")]
        public async Task<ActionResult> ObterRelatorio(DateTime dataInicial, DateTime dataFinal)
        {
            var lista = _context.Atividades.Where(x => x.InicioAtividade > dataInicial && x.FimAtividade < dataFinal).Select(x => new Atividade {
                Id = x.Id,
                InicioAtividade = x.InicioAtividade,
                FimAtividade = x.FimAtividade,
                NomeAtividade = x.NomeAtividade,
                HorasAtividade = x.HorasAtividade //Convert.ToString(x.FimAtividade - x.InicioAtividade) poderia ser feito assim.

            }).ToListAsync();
            
            return Ok(await lista);
        }


    }
}
