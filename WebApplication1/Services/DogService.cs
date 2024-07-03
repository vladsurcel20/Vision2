using System.Reflection.Metadata.Ecma335;
using Swashbuckle.AspNetCore.SwaggerGen;
using WebApplication1.Models;
namespace WebApplication1.Services;

public class DogService
{
    public bool IsIdUnique(int id)
    {
        if (context.FirstOrDefault(d => d.Id == id) == null) return true;
        else return false;
        /*if (dog.Age > 0 && dog.Age < 99) return true;
        else return false; */
    }

    public bool IsIdUsed(int id)
    {
        if (context.FirstOrDefault(d => d.Id == id) == null) return false;
        else return true;
    }

    private List<Dog> context = new List<Dog> {
            new Dog{Id =1, Name="Pitbull", Age=3, Color="black"},
            new Dog{Id =2, Name="Shiba", Age=5, Color="brown"},
        };

    public DogService() { }

    public List<Dog> GetAll()
    {
        return context;
    }

    public Dog GetById(int id)
    {
        return context.FirstOrDefault(d => d.Id == id);
    } 

    public List<Dog> FindByName(string name)
    {
        List<Dog> list = new List<Dog>();
        foreach (Dog dog in context)
        {
            if (dog.Name == name)
            {
                list.Add(dog);
            }
        }
        return list;
    }

    public void Add(Dog dog)
    {
        context.Add(dog);
    }

    public void Remove(int id)
    {
        Dog foundDog = context.FirstOrDefault(d => d.Id == id);
        context.Remove(foundDog);
    }

        public void Update(Dog dog)
    {
        Dog newDog = context.FirstOrDefault(d => d.Id == dog.Id);
        //if (newDog != null && IsValid(dog))
        
        context.Remove(newDog); 
        context.Add(dog); 
        
    }


    public Dog GetRandom()
    {
        Random rnd = new Random();
        int index = rnd.Next(context.Count);
        return context[index];
    }
}