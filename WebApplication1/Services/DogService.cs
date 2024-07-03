using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.SwaggerGen;
using WebApplication1.Models;
using WebApplication1.Data;
using Microsoft.Extensions.DependencyModel;
namespace WebApplication1.Services;

public class DogService
{

    private readonly DogsContext _dogsContext;

    public DogService(DogsContext context)
    { 
        _dogsContext = context; 
    }
    public bool IsIdUnique(int id)
    {
        if (_dogsContext.Set<Dog>().FirstOrDefault(d => d.Id == id) == null) return true;
        else return false;
    }

    public bool IsIdUsed(int id)
    {
        if (_dogsContext.Set<Dog>().FirstOrDefault(d => d.Id == id) == null) return false;
        else return true;
    }

    

    public List<Dog> GetAll()
    {
        return _dogsContext.Dogs.ToList();
    }

    public Dog GetById(int id)
    {
        return _dogsContext.Set<Dog>().ToList().FirstOrDefault(d => d.Id == id);
    } 

    public List<Dog> FindByName(string name)
    {      
            return _dogsContext.Set<Dog>().ToList().FindAll(d => d.Name == name);
            //_dogsContext.SaveChanges();           

    }

    public void Add(Dog dog)
    {
        _dogsContext.Add(dog);
        _dogsContext.SaveChanges();
    }

    public void Remove(int id)
    {
        Dog foundDog = _dogsContext.Dogs.FirstOrDefault(d => d.Id == id);
        _dogsContext.Remove(foundDog);
        _dogsContext.SaveChanges();
    }

        public void Update(Dog dog)
    {
        Dog newDog = _dogsContext.Dogs.FirstOrDefault(d => d.Id == dog.Id);
        //if (newDog != null && IsValid(dog))

        _dogsContext.Remove(newDog);
        _dogsContext.Add(dog); 
        _dogsContext.SaveChanges();
        
    }

    public List<Dog> GetOdd()
    {
        return _dogsContext.Dogs.ToList().FindAll(d => d.Id%2 ==1);
    }

    public List<Dog> GetPage(int page, int items)
    {
        return _dogsContext.Set<Dog>()
                              .Skip(page*items)
                              .Take(items)
                              .ToList();
    }

 /*  public Dog GetRandom()
    {
        Random rnd = new Random();
        int index = rnd.Next(context.Count);
        return context[index];
    } */
} 