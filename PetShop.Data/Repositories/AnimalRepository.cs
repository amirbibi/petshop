using Microsoft.EntityFrameworkCore;
using PetShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Data.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly PetShopDbContext _context;

        public AnimalRepository(PetShopDbContext context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<Animal>> GetAllAnimalsAsync()
        {
            return await _context.Animals.ToListAsync();
        }

        public async Task<IEnumerable<Animal>> GetTopRatedAnimalsAsync(int numOfAnimals)
        {
            return await _context.Animals
                .OrderByDescending(animal => animal.Comments!.Count)
                .Take(numOfAnimals)
                .ToListAsync();
        }

        public async Task<Animal?> GetAnimalByIdAsync(int animalId)
        {
            return await _context.Animals.SingleOrDefaultAsync(a => a.AnimalId == animalId);
        }

        public async Task<IEnumerable<Animal>> GetAnimalsInCategoryIdAsync(int categoryId)
        {
            return await _context.Animals.Where(c => c.CategoryId == categoryId).ToListAsync();
        }

        public async Task InsertAnimalAsync(Animal animal)
        {
            _context.Animals.Add(animal);
            await _context.SaveChangesAsync();
        }

        public async Task EditAnimalAsync(Animal updatedAnimal)
        {
            var animalInDb = await GetAnimalByIdAsync(updatedAnimal.AnimalId);
            if (animalInDb != null)
            {
                animalInDb.PictureName = updatedAnimal.PictureName;
                animalInDb.Name = updatedAnimal.Name;
                animalInDb.Age = updatedAnimal.Age;
                animalInDb.Description = updatedAnimal.Description;
                animalInDb.CategoryId = updatedAnimal.CategoryId;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAnimalAsync(Animal animal)
        {
            _context.Animals.Remove(animal);
            await _context.SaveChangesAsync();
        }
    }
}
