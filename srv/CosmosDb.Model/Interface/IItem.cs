using CosmosDb.Model.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CosmosDb.Model.Interface
{
    public interface IItem
    {
        System.Threading.Tasks.Task<IEnumerable<Item>> GetAsync();
        System.Threading.Tasks.Task<Item> GetAsync(string id);
        System.Threading.Tasks.Task<Item> PostAsync(Item item);
        System.Threading.Tasks.Task<Item> PutAsync(string id, Item item);
        System.Threading.Tasks.Task<bool> DeleteAsync(string id);
    }
}
