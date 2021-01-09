using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Naros_Ana_Maria_AdoptAPet.Data;


namespace Naros_Ana_Maria_AdoptAPet.Models
{
    public class PetCategoriesPageModel:PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(Naros_Ana_Maria_AdoptAPetContext context, Pet pet)
        {
            var allCategories = context.Category;
            var petCategories = new HashSet<int>(
            pet.PetCategories.Select(c => c.PetID));
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = petCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdatePetCategories(Naros_Ana_Maria_AdoptAPetContext context, string[] selectedCategories, Pet petToUpdate)
        {
            if (selectedCategories == null)
            {
                petToUpdate.PetCategories = new List<PetCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var petCategories = new HashSet<int>
            (petToUpdate.PetCategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!petCategories.Contains(cat.ID))
                    {
                        petToUpdate.PetCategories.Add(
                        new PetCategory
                        {
                            PetID = petToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (petCategories.Contains(cat.ID))
                    {
                        PetCategory courseToRemove
                        = petToUpdate
                        .PetCategories
                        .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
