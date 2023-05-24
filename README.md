# Habit Tracker - (.NET MVC Web Application)

## Technologies Used:

For Frontend: HTML, CSS, BootStrap, JavaScript

For Backend: C#, ASP.NET

For Database: MS SQL

## How to Run
1. Install the following:
* [Microsoft Visual Studio](https://visualstudio.microsoft.com/vs/community/)
* [Microsoft SQL Server Express](https://www.microsoft.com/en-us/sql-server/sql-server-editions-express)

2. Open SQL Server Management Studio and in the "Connect to Database Engine" window type the following:
```
Servername: (localdb)\MSSQLLocalDB
Authentication: Windows Authentication 

```
3. Download the project 

4. use "update-database" in Package Manager Console


Дисциплина вырабатывается через привычки. А привычки создаются на основе регулярности действия. Данное веб-приложения следит за прогрессом и формированием привычек.

- **CRUD для Создания Профиля**
    - Регистрация / Авторизация;
    - Сброс / Создание / Подтверждение нового пароля
    - Имя / изменение
    - Добавление аватара пользователя
- **CRUD для Создания Привычки**
        - Название
        - Описание
        - Цель (количество повтора в день)
        - Частота выполнения (измерение в днях, неделях, месяцах)
        - Сроки (дата начала и конца)
    - **Управление привычками**
        - Выбор привычек из готового списка (ходьба, бег, йога, чтение и тд.)
        - Добавление персональных привычек
        - Удаление привычек
