using PetShop.Data.Repositories;
using PetShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalRepository _animalRepository;

        public AnimalService(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public async Task DeleteAnimalAsync(Animal animal)
        {
            await _animalRepository.DeleteAnimalAsync(animal);
        }

        public async Task EditAnimalAsync(Animal updatedAnimal)
        {
            await _animalRepository.EditAnimalAsync(updatedAnimal);
        }

        public async Task<IEnumerable<Animal>> GetAllAnimalsAsync()
        {
            return await _animalRepository.GetAllAnimalsAsync();
        }

        public async Task<Animal?> GetAnimalByIdAsync(int animalId)
        {
            return await _animalRepository.GetAnimalByIdAsync(animalId);
        }

        public async Task<IEnumerable<Animal>> GetAnimalsInCategoryIdAsync(int categoryId)
        {
            return await _animalRepository.GetAnimalsInCategoryIdAsync(categoryId);
        }

        public async Task<IEnumerable<Animal>> GetTopRatedAnimalsAsync(int top)
        {
            return await _animalRepository.GetTopRatedAnimalsAsync(top);
        }

        public async Task InsertAnimalAsync(Animal animal)
        {
            await _animalRepository.InsertAnimalAsync(animal);
        }
    }
}
