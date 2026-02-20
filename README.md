
# Hospital Avalonia

Hospital Avalonia — настольное приложение для работы с медицинскими данными пациентов.
Проект разработан с использованием **Avalonia UI**, **Entity Framework Core** и архитектурного паттерна **MVVM**.

Приложение реализует авторизацию пользователей с различными ролями и отображение медицинской карты пациента.

---

## Стек технологий

* .NET
* Avalonia UI
* Entity Framework Core
* CommunityToolkit.Mvvm
* C#
* MVVM

---

## Основной функционал

### Авторизация

Пользователь вводит логин и пароль. Проверка выполняется через EF Core:

```csharp
currentUser = db.LoginTables
    .Include(x => x.IdUserNavigation)
    .FirstOrDefault(x => x.Login == Login && x.Password == Password);
```

После успешной авторизации выполняется переход на страницу, соответствующую роли пользователя:

```csharp
switch (currentUser.IdRole)
{
    case 1:
        MainWindowViewModel.Instance.PageSwither = new AdminViewModel();
        break;
    case 2:
        MainWindowViewModel.Instance.PageSwither = new DoctorViewModel();
        break;
    case 3:
        MainWindowViewModel.Instance.PageSwither = new UserViewModel(currentUser);
        break;
}
```

---

### Переключение страниц

В `MainWindowViewModel` используется свойство:

```csharp
[ObservableProperty]
ViewModelBase pageSwither = new LoginPageViewModel();
```

В `MainWindow.axaml` отображение реализовано через:

```xml
<ContentControl Content="{Binding PageSwither}"/>
```

---

## Функциональность пациента

После входа пациент получает доступ к:

* Основной информации (ФИО, дата рождения, рост, вес, пол)
* Автоматически вычисляемому возрасту
* Списку аллергий
* Истории посещений и диагнозов

Загрузка данных выполняется через `SheronovContext`:

```csharp
var history = db.VisitsTables
    .Include(v => v.IdDiagnosisNavigation)
    .Where(v => v.IdUser == logined.IdUser)
    .OrderByDescending(v => v.VisitDate)
    .ToList();
```

---

## Архитектура проекта

Структура:

```
Hospital
│
├── Models        // EF Core модели
├── ViewModels    // Логика представления
├── Views         // XAML интерфейсы
└── MainWindow    // Контейнер приложения
```

Проект построен по паттерну **MVVM**.
Базовый класс `ViewModelBase` наследуется от `ObservableObject`.

---

## Запуск проекта

1. Установить .NET SDK
2. Настроить строку подключения в `SheronovContext`
3. При необходимости выполнить миграции
4. Запустить:

```bash
dotnet run
```

---

## Текущие ограничения

* Пароли хранятся без хеширования
* Панели администратора и врача реализованы как заглушки
* Нет регистрации пользователей
* Нет полноценной реализации logout
* Используется статический экземпляр контекста БД

---

## Назначение проекта

Проект создан в учебных целях для демонстрации:

* работы с Avalonia UI
* применения MVVM
* интеграции Entity Framework Core
* авторизации по ролям
* динамической загрузки данных пациента


