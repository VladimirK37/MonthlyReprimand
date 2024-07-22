# MonthlyReprimand
Описание: Проект .NET 8.0 API, использующий AutoMapper,Entity Framework, Entity Framework Design и Entity Framework Tools для взаимодействия с базой данных SQLite.

Функции:
Три основные сущности: Employee, Position, Shift
CRUD (Create, Read, Update, Delete) операции для сущности Employee
API-endpoints:
Employee:
POST /api/hrdepartment/CreateEmployee: Добавить новые сотрудника
GET /api/hrdepartment/GetAllEmployees: Получить всех сотрудников
PUT /api/hrdepartment/EditEmployee: Обновить конкретного сотрудника
DELETE /api/hrdepartment/DeleteEmployee: Удалить сотрудника
GET /api/hrdepartment/GetPosition: Получить все должности сотрудника
Shift:
POST /api/checkpoint/exit: Выход через КПП
POST /api/checkpoint/start: Вход через КПП

Зависимости:
.NET 8.0
Entity Framework 8.0.7
Entity Framework Design 8.0.7
Entity Framework Tools 8.0.7
AutoMapper 13.0.1

Начало работы:
Клонировать репозиторий и перейти в папку проекта.
Запустить команду dotnet run для запуска .NET 6.0 API.
Использовать инструмент, seperti Postman или cURL для тестирования endpoints API.


Настройка:
API использует базу данных SQLite, настроенную в файле appsettings.json. 
