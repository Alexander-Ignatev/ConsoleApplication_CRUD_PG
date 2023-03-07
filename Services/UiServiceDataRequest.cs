namespace HomeWork_4.Services
{
    public static class UiServiceDataRequest
    {
        public static string GetStringDataFromTheUser(string dataType)
        {
            string? res;
            while (true)
            {
                Console.WriteLine($"Введите следующие данные: {dataType}");
                res = Console.ReadLine();
                if (!string.IsNullOrEmpty(res)) break;
                else
                {
                    System.Threading.Thread.Sleep(1000);
                    Console.WriteLine($"Введенные данные недопустимы, повторите ввод!");
                    Console.WriteLine();
                    continue;
                }
            }
            return res;
        }
        public static decimal GetPriceFromTheUser(string dataName)
        {
            decimal price = 0;

            while (true)
            {
                Console.WriteLine($"Введите следующие данные: {dataName}");
                string? res = Console.ReadLine();
                if (!Decimal.TryParse(res, out price))
                {
                    System.Threading.Thread.Sleep(1000);
                    Console.WriteLine($"Введенные данные недопустимы, повторите ввод!");
                    Console.WriteLine();
                    continue;
                }
                else
                {
                    System.Threading.Thread.Sleep(1000);
                    Console.WriteLine($" y/n || Подтвердите введённую сумму: {price}");
                    while (true)
                    {
                        var key = Console.ReadKey();
                        switch (key.Key)
                        {
                            case ConsoleKey.Y:
                                break;
                            case ConsoleKey.N:
                                price = GetPriceFromTheUser(dataName);
                                break;
                            default: continue;
                        }
                        break;
                    }
                    break;
                }
            }

            return price;
        }

        public static int GetUserIdFromTheUser(ApplicationContext applicationContext, string dataName)
        {
            int id = 0;

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine($"Введите следующие данные: {dataName}");
                string? res = Console.ReadLine();
                if (!int.TryParse(res, out id))
                {
                    System.Threading.Thread.Sleep(1000);
                    Console.WriteLine($"Введенные данные недопустимы, повторите ввод!");
                    Console.WriteLine();
                    continue;
                }
                else
                {
                    System.Threading.Thread.Sleep(1000);
                    if (DbService.CheckExistUserById(applicationContext, id))
                    {
                        var user = DbService.GetUserById(applicationContext, id);
                        id = user.Id;
                        Console.WriteLine("Найден следующий пользователь:");
                        Console.WriteLine(user.ToString());
                        Console.WriteLine($" y/n || Подтвердите выбор:");
                        while (true)
                        {
                            var key = Console.ReadKey();
                            switch (key.Key)
                            {
                                case ConsoleKey.Y:
                                    break;
                                case ConsoleKey.N:
                                    id = GetUserIdFromTheUser(applicationContext, dataName);
                                    break;
                                default: continue;
                            }
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Пользователь с данным идентификатором не найден, повторить ввод?");
                        Console.WriteLine($" y/n || Подтвердите выбор:");
                        while (true)
                        {
                            var key = Console.ReadKey();
                            switch (key.Key)
                            {
                                case ConsoleKey.Y:
                                    break;
                                case ConsoleKey.N:
                                    return 0;
                                default: continue;
                            }
                            break;
                        }
                        continue;
                    }
                    break;
                }
            }

            return id;
        }

        public static int GetCategoryIdFromTheUser(ApplicationContext applicationContext, string dataName, bool parent = false)
        {
            int id = 0;
            if (parent)
            {
                Console.WriteLine();
                Console.WriteLine("Присутствует ли родительская категория?");
                while (true)
                {
                    var key = Console.ReadKey();
                    switch (key.Key)
                    {
                        case ConsoleKey.Y:
                            break;
                        case ConsoleKey.N:
                            return 0;
                        default: continue;
                    }
                    break;
                }
            }
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine($"Введите следующие данные: {dataName}");
                string? res = Console.ReadLine();
                if (!int.TryParse(res, out id))
                {
                    System.Threading.Thread.Sleep(1000);
                    Console.WriteLine($"Введенные данные недопустимы, повторите ввод!");
                    Console.WriteLine();
                    continue;
                }
                else
                {
                    System.Threading.Thread.Sleep(1000);
                    if (DbService.CheckExistCategoryById(applicationContext, id))
                    {
                        var category = DbService.GetCategoryById(applicationContext, id);
                        id = category.Id;
                        Console.WriteLine("Найдена следующая категория:");
                        Console.WriteLine(category.ToString());
                        Console.WriteLine($" y/n || Подтвердите выбор:");
                        while (true)
                        {
                            var key = Console.ReadKey();
                            switch (key.Key)
                            {
                                case ConsoleKey.Y:
                                    break;
                                case ConsoleKey.N:
                                    id = GetCategoryIdFromTheUser(applicationContext, dataName);
                                    break;
                                default: continue;
                            }
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Категория с данным идентификатором не найдена, повторить ввод?");
                        Console.WriteLine($" y/n || Подтвердите выбор:");
                        while (true)
                        {
                            var key = Console.ReadKey();
                            switch (key.Key)
                            {
                                case ConsoleKey.Y:
                                    break;
                                case ConsoleKey.N:
                                    return 0;
                                default: continue;
                            }
                            break;
                        }
                        continue;
                    }
                    break;
                }
            }

            return id;
        }

        public static int GetProductIdFromTheUser(ApplicationContext applicationContext, string dataName)
        {
            int id = 0;

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine($"Введите следующие данные: {dataName}");
                string? res = Console.ReadLine();
                if (!int.TryParse(res, out id))
                {
                    System.Threading.Thread.Sleep(1000);
                    Console.WriteLine($"Введенные данные недопустимы, повторите ввод!");
                    Console.WriteLine();
                    continue;
                }
                else
                {
                    System.Threading.Thread.Sleep(1000);
                    if (DbService.CheckExistProductById(applicationContext, id))
                    {
                        var product = DbService.GetProductById(applicationContext, id);
                        id = product.Id;
                        Console.WriteLine("Найден следующий товар:");
                        Console.WriteLine(product.ToString());
                        Console.WriteLine($" y/n || Подтвердите выбор:");
                        while (true)
                        {
                            var key = Console.ReadKey();
                            switch (key.Key)
                            {
                                case ConsoleKey.Y:
                                    break;
                                case ConsoleKey.N:
                                    id = GetUserIdFromTheUser(applicationContext, dataName);
                                    break;
                                default: continue;
                            }
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Товар с данным идентификатором не найден, повторить ввод?");
                        Console.WriteLine($" y/n || Подтвердите выбор:");
                        while (true)
                        {
                            var key = Console.ReadKey();
                            switch (key.Key)
                            {
                                case ConsoleKey.Y:
                                    break;
                                case ConsoleKey.N:
                                    return 0;
                                default: continue;
                            }
                            break;
                        }
                        continue;
                    }
                    break;
                }
            }

            return id;
        }
    }
}
