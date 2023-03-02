using BazarUz.Data.Configurations;
using BazarUz.Data.IRepositories;
using BazarUz.Domain.Commons;
using BazarUz.Domain.Entities;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Reflection.Metadata;

namespace BazarUz.Data.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Auditable
{

    private string path;
    private long lastId = 0;
    
    public Repository()
    {
        if(typeof(TEntity) == typeof(Product))
        {
            path = Constants.PRODUCT_PATH;
        }
        else if (typeof(TEntity) == typeof(User))
        {
            path = Constants.USER_PATH;
        }
        else if (typeof(TEntity) == typeof(Order))
        {
            path = Constants.ORDER_PATH;
        }
        else if (typeof(TEntity) == typeof(Category))
        {
            path = Constants.CATEGORY_PATH;
        }
        else if (typeof(TEntity) == typeof(Cart))
        {
            path = Constants.CART_PATH;
        }
        else if (typeof(TEntity) == typeof(Question))
        {
            path = Constants.QUESTION_PATH;
        }

        AutoIncrement();
    }

    private async void AutoIncrement()
    {
        foreach (var model in await GetAllAsync())
        {
            if (model.Id > lastId)
            {
                lastId = model.Id;
            }
        }
    }


    public async Task<TEntity> CreateAsync(TEntity model)
    {
        model.Id = ++lastId;
        var entities = await GetAllAsync();

        entities.Add(model);

        var text = JsonConvert.SerializeObject(entities, Formatting.Indented);
        File.WriteAllText(path, text);

        return model;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var entities = await GetAllAsync();
        var model  = entities.FirstOrDefault(x => x.Id == id);

        if (model is null) 
        {
            return false;
        }

        entities.Remove(model);

        var text = JsonConvert.SerializeObject(entities, Formatting.Indented);
        File.WriteAllText(path, text);

        return true;
    }

    public async Task<List<TEntity>> GetAllAsync(Predicate<TEntity> predicate = null)
    {
        var text = File.ReadAllText(path);

        if (string.IsNullOrEmpty(text))
        {
            text = "[]";
        }

        var result = JsonConvert.DeserializeObject<List<TEntity>>(text);

        if (predicate is null)
        {
            return result;
        }

        return result.FindAll(predicate);
    }

    public async Task<TEntity> GetByIdAsync(long id)
    {
        var entities = await GetAllAsync();
        return entities.FirstOrDefault(x => x.Id == id);
    }

    public Task<TEntity> UpdateAsync(TEntity model)
    {
        
    }




    
}