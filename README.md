# Консольное приложение, в котором реализована работа CRUD-операций с БД PostgreSQL (Entity Framework)

Приложение работает с БД PostgreSQL, для тестирования необходимо восстановить БД из дампа, приложенного к проекту

Кратное описание:
Предлагается выполнить 4 операции:
1. Чтение данных из БД
2. Добавление в БД
3. Изменение данных в БД
4. Удаление данных из БД

БД содержит три таблицы:
1. users
2. categories
3. products

По каждой таблице отдельно можно добавлять/удалять/изменять/читать данные.

Для подключения к БД необходимо отредактировать файл "App.config" заменив connectionString на своё подключение к БД
