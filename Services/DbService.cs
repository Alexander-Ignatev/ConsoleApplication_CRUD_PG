using HomeWork_4.Models;

namespace HomeWork_4.Services
{
    public static class DbService
    {
        public static List<User> GetAllUsers(ApplicationContext applicationContext)
        {
            return applicationContext.Users.ToList();
        }
        public static List<Product> GetAllProducts(ApplicationContext applicationContext)
        {
            return applicationContext.Products.ToList();
        }
        public static List<Category> GetAllCategories(ApplicationContext applicationContext)
        {
            return applicationContext.Categories.ToList();
        }

        public static int AddNewUser(ApplicationContext applicationContext, User user)
        {
            var newUser = applicationContext.Users.Add(user);
            applicationContext.SaveChanges();
            return newUser.Entity.Id;
        }
        public static int AddNewProduct(ApplicationContext applicationContext, Product product)
        {
            var newProduct = applicationContext.Products.Add(product);
            applicationContext.SaveChanges();
            return newProduct.Entity.Id;
        }
        public static int AddNewCategory(ApplicationContext applicationContext, Category category)
        {
            var newCategory = applicationContext.Categories.Add(category);
            applicationContext.SaveChanges();
            return newCategory.Entity.Id;
        }

        public static bool CheckExistUserById(ApplicationContext applicationContext, int id)
        {
            return applicationContext.Users.ToList().Where(i => i.Id == id).Any();
        }
        public static bool CheckExistProductById(ApplicationContext applicationContext, int id)
        {
            return applicationContext.Products.ToList().Where(i => i.Id == id).Any();
        }

        public static User GetUserById(ApplicationContext applicationContext, int id)
        {
            return applicationContext.Users.ToList().First(i => i.Id == id);
        }

        public static Product GetProductById(ApplicationContext applicationContext, int id)
        {
            return applicationContext.Products.ToList().First(i => i.Id == id);
        }

        public static bool CheckExistCategoryById(ApplicationContext applicationContext, int id)
        {
            return applicationContext.Categories.ToList().Where(i => i.Id == id).Any();
        }

        public static Category GetCategoryById(ApplicationContext applicationContext, int id)
        {
            return applicationContext.Categories.ToList().First(i => i.Id == id);
        }

        public static User UpdateUser(ApplicationContext applicationContext, int userId, User user)
        {
            var curUser = GetUserById(applicationContext, userId);

            curUser.FirstName = user.FirstName;
            curUser.LastName = user.LastName;
            curUser.MiddleName = user.MiddleName;
            curUser.Email = user.Email;
            curUser.Phone = user.Phone;

            applicationContext.SaveChanges();
            return curUser;
        }
        public static Product UpdateProduct(ApplicationContext applicationContext, int id, Product product)
        {
            var curProduct = GetProductById(applicationContext, id);

            curProduct.ShortName = product.ShortName;
            curProduct.Description = product.Description;
            curProduct.Price = product.Price;
            curProduct.CategoriesId = product.CategoriesId;
            curProduct.UserId = product.UserId;

            applicationContext.SaveChanges();
            return curProduct;
        }
        public static Category UpdateCategory(ApplicationContext applicationContext, int id, Category category)
        {
            var curCategory = GetCategoryById(applicationContext, id);

            curCategory.ShortName = category.ShortName;
            curCategory.ParentId = category.ParentId;

            applicationContext.SaveChanges();
            return curCategory;
        }

        public static void DeleteUserById(ApplicationContext applicationContext, int id)
        {
            var curUser = GetUserById(applicationContext, id);

            applicationContext.Remove(curUser);

            applicationContext.SaveChanges();
        }
        public static void DeleteCategoryById(ApplicationContext applicationContext, int id)
        {
            var curCategory = GetCategoryById(applicationContext, id);

            applicationContext.Remove(curCategory);

            applicationContext.SaveChanges();
        }
        public static void DeleteProductById(ApplicationContext applicationContext, int id)
        {
            var curProduct = GetProductById(applicationContext, id);

            applicationContext.Remove(curProduct);

            applicationContext.SaveChanges();
        }
    }
}
