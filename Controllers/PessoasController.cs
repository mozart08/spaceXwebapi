using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class PessoasController : ControllerBase
    {
        private readonly Contexto _contexto;

        public PessoasController(Contexto contexto)
        {
            _contexto = contexto;
        }

        /// <summary>
        /// retorna todas as Pessoas cadastradas no banco
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pessoa>>> getAllAsync(){

            return await _contexto.Pessoas.ToListAsync();
        }

        /// <summary>
        /// retorna um registro da entidade Pessoa
        /// </summary>
        /// <param name="pessoaId">Identificação da Pessoa</param>
        /// <returns></returns>
        [HttpDelete]
        [HttpGet("{PessoaId}")]
        public async Task<ActionResult<Pessoa>> getById(int pessoaId){
            Pessoa pessoa = await _contexto.Pessoas.FindAsync(pessoaId);

            if(pessoa == null) 
                return NotFound();
                
            return pessoa;
        }

        /// <summary>
        /// salva um registro da entidade Pessoa
        /// </summary>
        /// <param name="pessoa">entidade Pessoa</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Pessoa>> SaveAsync(Pessoa pessoa){

            await _contexto.Pessoas.AddAsync(pessoa);
            await _contexto.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync(Pessoa pessoa){
            try
            {
                _contexto.Pessoas.Update(pessoa);
                await _contexto.SaveChangesAsync(); 
                return Ok(); 
            }
              catch (Exception ex)
            {
                throw;
            }


        }

            /// <summary>
            /// remove um registro da entidade Pessoa
            /// </summary>
            /// <param name="idPessoa">id da entidade Pessoa</param>
            /// <returns></returns>
            [HttpDelete("{pessoaId}")]
            public async Task<ActionResult> DeleteAsync(int pessoaId){
                Pessoa pessoa = await _contexto.Pessoas.FindAsync(pessoaId);
                if (pessoa == null)
                return NotFound();
                _contexto.Remove(pessoa);
                await _contexto.SaveChangesAsync();
                return Ok();

            }
    }
}