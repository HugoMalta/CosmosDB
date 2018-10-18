using CosmosDb.Model.Interface;
using CosmosDb.Model.Model;
using CosmosDB.Repositorio;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CosmosDB.Negocio
{
    public class ItemNegocio
    {
        private IItem itemRepositorio { get; }

        public ItemNegocio()
        {
            itemRepositorio = new ItemRepositorio();
        }
        
        public async Task<IEnumerable<Item>> GetAsync()
        {
            System.Threading.Tasks.Task<IEnumerable<Item>> teste = itemRepositorio.GetAsync();
            return await teste;            
        }

        public async Task<Item> GetAsync(string id)
        {
            System.Threading.Tasks.Task<Item> teste = itemRepositorio.GetAsync(id);
            return await teste;
        }

        public async System.Threading.Tasks.Task<Item> PostAsync(Item item)
        {
            Task<Item> teste = itemRepositorio.PostAsync(item);
            return await teste;
        }

        public async System.Threading.Tasks.Task<Item> PutAsync(string id, Item item)
        {
            Task<Item> teste = itemRepositorio.PutAsync(id, item);
            return await teste;
        }

        public async System.Threading.Tasks.Task<bool> DeleteAsync(string id)
        {
            Task<bool> teste = itemRepositorio.DeleteAsync(id);
            return await teste;
        }

    }
}
