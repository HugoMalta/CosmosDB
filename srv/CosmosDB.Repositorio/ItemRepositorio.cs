using CosmosDb.Model.Interface;
using CosmosDb.Model.Model;
using CosmosDB.Utils;
using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CosmosDB.Repositorio
{
    public class ItemRepositorio : IItem
    {
        public ItemRepositorio()
        {
            DocumentDBRepository<Item>.Initialize();
        }
        private static Configurations _config = new Configurations();

        public async System.Threading.Tasks.Task<IEnumerable<Item>> GetAsync()
        {
            //using (var client = new DocumentClient(
            //   new Uri(_config.GetConfiguration("ToDoList_CosmosDB:EndpointUri")),
            //           _config.GetConfiguration("ToDoList_CosmosDB:PrimaryKey")))
            //{
            //    FeedOptions queryOptions =
            //        new FeedOptions { MaxItemCount = -1 };

            //    string database = "ToDoList";
            //    string collection = "Items";
            //    string sSql = "SELECT m.id Id, m.name Name, m.description Description, m.isComplete Completed FROM Items m";

            //    var teste =
            //        client.CreateDocumentQuery<Item>(
            //              UriFactory.CreateDocumentCollectionUri(database, collection), sSql, queryOptions)
            //        .ToList();
            //    return teste;
            //}

            var items = await DocumentDBRepository<Item>.GetItemsAsync(d => d.Id != null);
            return items.ToList();
        }

        public async System.Threading.Tasks.Task<Item> GetAsync(string id)
        {
            var items = await DocumentDBRepository<Item>.GetItemAsync(id);
            return items;
        }
        
        public async System.Threading.Tasks.Task<Item> PostAsync(Item item)
        {
            var varRetorno = await DocumentDBRepository<Item>.CreateItemAsync(item);
            Item retorno = (Item)(dynamic)varRetorno;

            return retorno;
        }

        public async System.Threading.Tasks.Task<Item> PutAsync(string id, Item item)
        {
            var varRetorno = await DocumentDBRepository<Item>.UpdateItemAsync(id, item);
            Item retorno = (Item)(dynamic)varRetorno;

            return retorno;
        }
        public async System.Threading.Tasks.Task<bool> DeleteAsync(string id)
        {
            var varRetorno = await DocumentDBRepository<Item>.DeleteItemAsync(id);
            bool retorno = varRetorno == null;

            return retorno;
        }
    }
}
