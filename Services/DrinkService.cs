
using Day1.Database;
using Day1.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

namespace Day1.Services

{
    public class DrinkService
    {
        private readonly DatabaseContext _drinkContext;
        public DrinkService(DatabaseContext context) {
            _drinkContext = context;
        }

        public List<Drink> GetAll()
        {
            return _drinkContext.Set<Drink>().ToList();
        }

        public Drink? GetById(int id)
        {
            return _drinkContext.Set<Drink>().FirstOrDefault(drink => drink.Id == id);

        }

        public void Add(Drink drink)
        {
            _drinkContext.Set<Drink>().Add(drink);
            _drinkContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var drink = _drinkContext.Set<Drink>().FirstOrDefault(d => d.Id == id);
            _drinkContext.Set<Drink>().Remove(drink);
            _drinkContext.SaveChanges();
        }
        public List<Drink> FindByName(string name)
        {
            List<Drink> list = new List<Drink>();
            foreach (Drink drink in _drinkContext.Set<Drink>())
            {
                if (drink.Name == name)
                    list.Add(drink);
            }
            return list;
        }
        public void Update(int id, Drink drink)
        {
            var check = _drinkContext.Set<Drink>().FirstOrDefault(u => u.Id == id);
            if (check != null)
            {
                check.Name = drink.Name;
                check.Description = drink.Description;
                check.Price = drink.Price;
                _drinkContext.SaveChanges();
            }
        }
        public List<Drink> GetOddDrinks()
        {
            return _drinkContext.Drinks.Where(d => d.Id % 2 != 0).ToList();
        }
        public List<Drink> returnPage(int page, int elements)
        {
            return _drinkContext.Set<Drink>().Skip<Drink>(page * elements).Take<Drink>(elements).ToList<Drink>();
        }
    }

}