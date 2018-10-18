using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CosmosDb.Model.Model;
using CosmosDB.Negocio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Documents.Client;
using Microsoft.Extensions.Configuration;

namespace CosmosDB.API.Controllers
{
    /// <summary>
    /// ValuesController
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ItemNegocio _itemNegocio;

        private ItemNegocio itemNegocio => _itemNegocio;

        /// <summary>
        /// Construtor que iniciará a classe de negócio.
        /// </summary>
        public ValuesController()
        {
            _itemNegocio = new ItemNegocio();
        }

        /// <summary>
        /// Obter todos registros
        /// </summary>
        /// <returns>Lista de registros</returns>
        [HttpGet]
        public async Task<IEnumerable<Item>> GetAsync()
        {
            var teste = itemNegocio.GetAsync();
            return await teste;
        }

        /// <summary>
        /// Obter Registro
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>Objeto selecionado</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> Get(string id)
        {
            var teste = itemNegocio.GetAsync(id);
            return await teste;
        }

        /// <summary>
        /// Incluir registro
        /// </summary>
        /// <param name="item">Objeto a ser incluído</param>
        /// <returns>Item incluído</returns>
        [HttpPost]
        public async Task<Item> Post([FromBody] Item item)
        {
            var teste = itemNegocio.PostAsync(item);
            return await teste;
        }

        /// <summary>
        /// Atualizar registro
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <param name="item">Registro a ser alterado</param>
        /// <returns>Objeto alterado</returns>
        [HttpPut("{id}")]
        public async Task<Item> Put(string id, Item item)
        {
            var teste = itemNegocio.PutAsync(id, item);
            return await teste;
        }

        /// <summary>
        /// Excluir registro
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>bool informando se excluiu ou não</returns>
        [HttpDelete("{id}")]
        public async Task<bool> Delete(string id)
        {
            var teste = itemNegocio.DeleteAsync(id);
            return await teste;
        }
    }
}
