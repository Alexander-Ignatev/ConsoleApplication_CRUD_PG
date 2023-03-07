using HomeWork_4.Models;

namespace HomeWork_4.Services
{
    public class UiService : IDisposable
    {
        private ApplicationContext applicationContext;
        public UiService()
        {
            applicationContext = new ApplicationContext();
        }

        public void StartProgram()
        {
            Console.WriteLine("Добро пожаловать в программу!");
            Console.WriteLine("нажмите любую клавишу, чтобы продолжить...");
            Console.ReadKey();

            ShowMainMenu();
        }

        public void ShowMainMenu()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Доступные операции:");
            Console.WriteLine("1. Чтение данных из БД");
            Console.WriteLine("2. Добавление в БД");
            Console.WriteLine("3. Изменение данных в БД");
            Console.WriteLine("4. Удаление данных из БД");
            Console.WriteLine("5. Выход из программы");

            Console.WriteLine();
            Console.WriteLine("Введите номер операции и нажмите Enter");

            string? data = Console.ReadLine();

            ProcessingEnteredMainMenuData(data);
        }

        private void ProcessingEnteredMainMenuData(string? data)
        {
            switch (data)
            {
                case "1":
                    ShowReadDbMenu();
                    break;
                case "2":
                    ShowAddDbMenu();
                    break;
                case "3":
                    ShowUpdateDbMenu();
                    break;
                case "4":
                    break;
                case "5":
                    Console.WriteLine("Благодарим за уделённое время!");
                    System.Threading.Thread.Sleep(3000);
                    return;
                default:
                    ShowMainMenu();
                    break;
            }
        }

        public void ShowReadDbMenu()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Доступные операции:");
            Console.WriteLine("1. Получить всех пользователей");
            Console.WriteLine("2. Получить все товары");
            Console.WriteLine("3. Получить все категории");
            Console.WriteLine("4. Вернуться в основное меню");

            Console.WriteLine();
            Console.WriteLine("Введите номер операции и нажмите Enter");

            string? data = Console.ReadLine();

            ProcessingEnteredReadDbMenuData(data);
        }

        private void ProcessingEnteredReadDbMenuData(string? data)
        {
            switch (data)
            {
                case "1":
                    ShowAllUsers();
                    break;
                case "2":
                    ShowAllProducts();
                    break;
                case "3":
                    ShowAllCategories();
                    break;
                case "4":
                    System.Threading.Thread.Sleep(2000);
                    ShowMainMenu();
                    break;
                default:
                    ShowReadDbMenu();
                    break;
            }
        }
        public void ShowUpdateDbMenu()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Доступные операции:");
            Console.WriteLine("1. Редактировать пользователя");
            Console.WriteLine("2. Редактировать товар");
            Console.WriteLine("3. Редактировать категорию");
            Console.WriteLine("4. Вернуться в основное меню");

            Console.WriteLine();
            Console.WriteLine("Введите номер операции и нажмите Enter");

            string? data = Console.ReadLine();

            ProcessingEnteredUpdateDbMenuData(data);
        }

        private void ProcessingEnteredUpdateDbMenuData(string? data)
        {
            switch (data)
            {
                case "1":
                    UpdateUser();
                    break;
                case "2":
                    UpdateProduct();
                    break;
                case "3":
                    UpdateCategory();
                    break;
                case "4":
                    System.Threading.Thread.Sleep(2000);
                    ShowMainMenu();
                    break;
                default:
                    ShowUpdateDbMenu();
                    break;
            }
        }
        public void ShowDeleteDbMenu()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Доступные операции:");
            Console.WriteLine("1. Удалить пользователя");
            Console.WriteLine("2. Удалить товар");
            Console.WriteLine("3. Удалить категорию");
            Console.WriteLine("4. Вернуться в основное меню");

            Console.WriteLine();
            Console.WriteLine("Введите номер операции и нажмите Enter");

            string? data = Console.ReadLine();

            ProcessingEnteredDeleteDbMenuData(data);
        }

        private void ProcessingEnteredDeleteDbMenuData(string? data)
        {
            switch (data)
            {
                case "1":
                    DeleteUser();
                    break;
                case "2":
                    DeleteProduct();
                    break;
                case "3":
                    DeleteCategory();
                    break;
                case "4":
                    System.Threading.Thread.Sleep(2000);
                    ShowMainMenu();
                    break;
                default:
                    ShowDeleteDbMenu();
                    break;
            }
        }
        private void DeleteUser()
        {
            try
            {
                int userId = UiServiceDataRequest.GetUserIdFromTheUser(applicationContext, "ID пользователя");

                if (userId == 0)
                {
                    System.Threading.Thread.Sleep(1000);
                    Console.WriteLine("INFO | Ввод данных отменен!");
                    System.Threading.Thread.Sleep(2000);
                    ShowUpdateDbMenu();
                }

                DbService.DeleteUserById(applicationContext, userId);
                Console.WriteLine();
                Console.WriteLine("Пользователь удален");
                Console.WriteLine();
                System.Threading.Thread.Sleep(2000);
                ShowUpdateDbMenu();
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); ShowUpdateDbMenu(); }
        }
        private void DeleteCategory()
        {
            try
            {
                int id = UiServiceDataRequest.GetCategoryIdFromTheUser(applicationContext, "ID категории");

                if (id == 0)
                {
                    System.Threading.Thread.Sleep(1000);
                    Console.WriteLine("INFO | Ввод данных отменен!");
                    System.Threading.Thread.Sleep(2000);
                    ShowUpdateDbMenu();
                }

                DbService.DeleteCategoryById(applicationContext, id);
                Console.WriteLine();
                Console.WriteLine("Категория удалена");
                Console.WriteLine();
                System.Threading.Thread.Sleep(2000);
                ShowUpdateDbMenu();
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); ShowUpdateDbMenu(); }
        }
        private void DeleteProduct()
        {
            try
            {
                int id = UiServiceDataRequest.GetProductIdFromTheUser(applicationContext, "ID категории");

                if (id == 0)
                {
                    System.Threading.Thread.Sleep(1000);
                    Console.WriteLine("INFO | Ввод данных отменен!");
                    System.Threading.Thread.Sleep(2000);
                    ShowUpdateDbMenu();
                }

                DbService.DeleteProductById(applicationContext, id);
                Console.WriteLine();
                Console.WriteLine("Товар удалён");
                Console.WriteLine();
                System.Threading.Thread.Sleep(2000);
                ShowUpdateDbMenu();
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); ShowUpdateDbMenu(); }
        }
        private void UpdateUser()
        {
            try
            {
                int userId = UiServiceDataRequest.GetUserIdFromTheUser(applicationContext, "ID пользователя");

                if (userId == 0)
                {
                    System.Threading.Thread.Sleep(1000);
                    Console.WriteLine("INFO | Ввод данных отменен!");
                    System.Threading.Thread.Sleep(2000);
                    ShowUpdateDbMenu();
                }

                Console.WriteLine("Введите новые данные:");
                Console.WriteLine();

                string lastName = UiServiceDataRequest.GetStringDataFromTheUser("Фамилия");
                string firstName = UiServiceDataRequest.GetStringDataFromTheUser("Имя");
                string middleName = UiServiceDataRequest.GetStringDataFromTheUser("Отчество");
                string email = UiServiceDataRequest.GetStringDataFromTheUser("Email");
                string phone = UiServiceDataRequest.GetStringDataFromTheUser("Телефон");


                User updatedUser = DbService.UpdateUser(applicationContext, userId, new User
                {
                    Email = email,
                    FirstName = firstName,
                    LastName = lastName,
                    MiddleName = middleName,
                    Phone = phone
                });
                Console.WriteLine();
                Console.WriteLine("Пользователь обновлен, новые данные:");
                Console.WriteLine(updatedUser.ToString());
                Console.WriteLine();
                System.Threading.Thread.Sleep(2000);
                ShowUpdateDbMenu();
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); ShowUpdateDbMenu(); }
        }
        private void UpdateProduct()
        {
            try
            {
                int productId = UiServiceDataRequest.GetProductIdFromTheUser(applicationContext, "ID товара");

                if (productId == 0)
                {
                    System.Threading.Thread.Sleep(1000);
                    Console.WriteLine("INFO | Ввод данных отменен!");
                    System.Threading.Thread.Sleep(2000);
                    ShowUpdateDbMenu();
                }

                Console.WriteLine("Введите новые данные:");
                Console.WriteLine();

                string name = UiServiceDataRequest.GetStringDataFromTheUser("Название");
                string description = UiServiceDataRequest.GetStringDataFromTheUser("Описание");
                decimal price = UiServiceDataRequest.GetPriceFromTheUser("Цена товара");
                int userId = UiServiceDataRequest.GetUserIdFromTheUser(applicationContext, "ID владельца товара");
                if (userId == 0)
                {
                    System.Threading.Thread.Sleep(1000);
                    Console.WriteLine("INFO | Ввод данных отменен!");
                    System.Threading.Thread.Sleep(2000);
                    ShowAddDbMenu();
                }
                int categoryId = UiServiceDataRequest.GetCategoryIdFromTheUser(applicationContext, "ID категории");
                if (categoryId == 0)
                {
                    System.Threading.Thread.Sleep(1000);
                    Console.WriteLine("INFO | Ввод данных отменен!");
                    System.Threading.Thread.Sleep(2000);
                    ShowAddDbMenu();
                }


                Product updatedProduct = DbService.UpdateProduct(applicationContext, productId, new Product
                {
                    ShortName = name,
                    Description = description,
                    Price = price,
                    UserId = userId,
                    CategoriesId = categoryId
                });
                Console.WriteLine();
                Console.WriteLine("Товар обновлен, новые данные:");
                Console.WriteLine(updatedProduct.ToString());
                Console.WriteLine();
                System.Threading.Thread.Sleep(2000);
                ShowUpdateDbMenu();
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); ShowUpdateDbMenu(); }
        }

        private void UpdateCategory()
        {
            try
            {
                int categoryId = UiServiceDataRequest.GetCategoryIdFromTheUser(applicationContext, "ID категории");

                if (categoryId == 0)
                {
                    System.Threading.Thread.Sleep(1000);
                    Console.WriteLine("INFO | Ввод данных отменен!");
                    System.Threading.Thread.Sleep(2000);
                    ShowUpdateDbMenu();
                }

                Console.WriteLine("Введите новые данные:");
                Console.WriteLine();

                string name = UiServiceDataRequest.GetStringDataFromTheUser("Название категории");
                int parentId = UiServiceDataRequest.GetCategoryIdFromTheUser(applicationContext, "ID родительской категории", true);

                Category updatedCategory = DbService.UpdateCategory(applicationContext, categoryId, new Category
                {
                    ShortName = name,
                    ParentId = parentId
                });
                Console.WriteLine();
                Console.WriteLine("Категория обновлена, новые данные:");
                Console.WriteLine(updatedCategory.ToString());
                Console.WriteLine();
                System.Threading.Thread.Sleep(2000);
                ShowUpdateDbMenu();
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); ShowUpdateDbMenu(); }
        }

        private void ShowAllUsers()
        {
            try
            {
                var users = DbService.GetAllUsers(applicationContext);
                if (users.Any())
                {
                    foreach (var user in users)
                    {
                        Console.WriteLine(user.ToString());
                        Console.WriteLine();
                    }
                }
                else Console.WriteLine("В БД отсутствуют данные о пользователях!");
                Console.WriteLine();
                System.Threading.Thread.Sleep(2000);
                ShowReadDbMenu();
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); ShowReadDbMenu(); }
        }

        private void ShowAllProducts()
        {
            try
            {
                var products = DbService.GetAllProducts(applicationContext);
                if (products.Any())
                {
                    foreach (var product in products)
                    {
                        Console.WriteLine(product.ToString());
                        Console.WriteLine();
                    }
                }
                else Console.WriteLine("В БД отсутствуют данные о товарах!");
                Console.WriteLine();
                System.Threading.Thread.Sleep(2000);
                ShowReadDbMenu();
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); ShowReadDbMenu(); }
        }

        private void ShowAllCategories()
        {
            try
            {
                var categories = DbService.GetAllCategories(applicationContext);
                if (categories.Any())
                {
                    foreach (var category in categories)
                    {
                        Console.WriteLine(category.ToString());
                        Console.WriteLine();
                    }
                }
                else Console.WriteLine("В БД отсутствуют данные о категориях!");
                Console.WriteLine();
                System.Threading.Thread.Sleep(2000);
                ShowReadDbMenu();
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); ShowReadDbMenu(); }
        }

        public void ShowAddDbMenu()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Доступные операции:");
            Console.WriteLine("1. Добавить пользователя");
            Console.WriteLine("2. Добавить товар");
            Console.WriteLine("3. Добавить категорию");
            Console.WriteLine("4. Вернуться в основное меню");

            Console.WriteLine();
            Console.WriteLine("Введите номер операции и нажмите Enter");

            string? data = Console.ReadLine();

            ProcessingEnteredAddDbMenuData(data);
        }
        private void ProcessingEnteredAddDbMenuData(string? data)
        {
            switch (data)
            {
                case "1":
                    AddNewUser();
                    break;
                case "2":
                    AddNewProduct();
                    break;
                case "3":
                    AddNewCategory();
                    break;
                case "4":
                    System.Threading.Thread.Sleep(2000);
                    ShowMainMenu();
                    break;
                default:
                    ShowAddDbMenu();
                    break;
            }
        }

        private void AddNewCategory()
        {
            try
            {
                string name = UiServiceDataRequest.GetStringDataFromTheUser("Название категории");
                int parentId = UiServiceDataRequest.GetCategoryIdFromTheUser(applicationContext, "ID родительской категории", true);

                var id = DbService.AddNewCategory(applicationContext, new Category
                {
                    ShortName = name,
                    ParentId = parentId
                });
                Console.WriteLine();
                Console.WriteLine($"Категория добавлена в БД, присвоен ID {id}");
                Console.WriteLine();
                System.Threading.Thread.Sleep(2000);
                ShowAddDbMenu();
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); ShowAddDbMenu(); }
        }

        private void AddNewProduct()
        {
            try
            {
                string name = UiServiceDataRequest.GetStringDataFromTheUser("Название");
                string description = UiServiceDataRequest.GetStringDataFromTheUser("Описание");
                decimal price = UiServiceDataRequest.GetPriceFromTheUser("Цена товара");
                int userId = UiServiceDataRequest.GetUserIdFromTheUser(applicationContext, "ID владельца товара");
                if (userId == 0)
                {
                    System.Threading.Thread.Sleep(1000);
                    Console.WriteLine("INFO | Ввод данных отменен!");
                    System.Threading.Thread.Sleep(2000);
                    ShowAddDbMenu();
                }
                int categoryId = UiServiceDataRequest.GetCategoryIdFromTheUser(applicationContext, "ID категории");
                if (categoryId == 0)
                {
                    System.Threading.Thread.Sleep(1000);
                    Console.WriteLine("INFO | Ввод данных отменен!");
                    System.Threading.Thread.Sleep(2000);
                    ShowAddDbMenu();
                }

                var id = DbService.AddNewProduct(applicationContext, new Product
                {
                    ShortName = name,
                    Description = description,
                    Price = price,
                    UserId = userId,
                    CategoriesId = categoryId
                });
                Console.WriteLine();
                Console.WriteLine($"Товар добавлен в БД, присвоен ID {id}");
                Console.WriteLine();
                System.Threading.Thread.Sleep(2000);
                ShowAddDbMenu();
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); ShowAddDbMenu(); }
        }

        private void AddNewUser()
        {
            try
            {
                string lastName = UiServiceDataRequest.GetStringDataFromTheUser("Фамилия");
                string firstName = UiServiceDataRequest.GetStringDataFromTheUser("Имя");
                string middleName = UiServiceDataRequest.GetStringDataFromTheUser("Отчество");
                string email = UiServiceDataRequest.GetStringDataFromTheUser("Email");
                string phone = UiServiceDataRequest.GetStringDataFromTheUser("Телефон");

                var id = DbService.AddNewUser(applicationContext, new User
                {
                    Email = email,
                    FirstName = firstName,
                    LastName = lastName,
                    MiddleName = middleName,
                    Phone = phone
                });
                Console.WriteLine();
                Console.WriteLine($"Пользователь добавлен в БД, присвоен ID {id}");
                Console.WriteLine();
                System.Threading.Thread.Sleep(2000);
                ShowAddDbMenu();
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); ShowAddDbMenu(); }
        }

        public void Dispose()
        {
            applicationContext.Dispose();
        }
    }
}
