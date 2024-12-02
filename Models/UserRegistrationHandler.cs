namespace LabProject.Models
{
    public class UserRegistrationHandler
    {
         private readonly ApplicationDbContext _dbContext;

        public UserRegistrationHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddDefaultCategoriesAsync(string userId)
        {
            var defaultCategories = GetDefaultCategories(userId);

            _dbContext.Categories.AddRange(defaultCategories);
            await _dbContext.SaveChangesAsync();
        }

        private List<Category> GetDefaultCategories(string userId)
        {
            return new List<Category>
            {
                    new Category { Name = "Food", IsDefault = true, UserId = userId },
                    new Category { Name = "Transportation", IsDefault = true, UserId = userId },
                    new Category { Name = "Travel", IsDefault = true, UserId = userId },
                    new Category { Name = "Health & Fitness", IsDefault = true, UserId = userId },
                    new Category { Name = "Education", IsDefault = true, UserId = userId }
            };
        }

    }
}
