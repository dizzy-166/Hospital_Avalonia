Hospital Avalonia
<p> <b>Hospital Avalonia</b> — настольное приложение для управления медицинскими данными пациентов. Проект разработан с использованием <b>Avalonia UI</b>, <b>Entity Framework Core</b> и архитектуры <b>MVVM</b>. </p> <hr>
О проекте
<p> Приложение реализует авторизацию пользователей, разграничение доступа по ролям и отображение медицинской карты пациента. </p> <p> Используемые технологии: <a href="https://dotnet.microsoft.com/">.NET</a>, <a href="https://avaloniaui.net/">Avalonia UI</a>, <a href="https://learn.microsoft.com/ef/core/">Entity Framework Core</a>, <a href="https://learn.microsoft.com/dotnet/communitytoolkit/mvvm/">CommunityToolkit.Mvvm</a> </p> <hr>
Стек технологий
<ul> <li>.NET</li> <li>Avalonia UI</li> <li>Entity Framework Core</li> <li>CommunityToolkit.Mvvm</li> <li>C#</li> <li>MVVM</li> </ul> <hr>
Архитектура проекта
<p><b>Паттерн:</b> Model–View–ViewModel (MVVM)</p> <pre> Hospital │ ├── Models ├── ViewModels │ ├── LoginPageViewModel │ ├── AdminViewModel │ ├── DoctorViewModel │ └── UserViewModel │ ├── Views │ ├── LoginPageView.axaml │ ├── AdminView.axaml │ ├── DoctorView.axaml │ └── UserView.axaml │ └── MainWindow </pre> <p>Переключение страниц осуществляется через <b>ContentControl</b>:</p>
<ContentControl Content="{Binding PageSwither}"/>
<hr>
Функциональность
Авторизация
currentUser = db.LoginTables
    .Include(x => x.IdUserNavigation)
    .FirstOrDefault(x => x.Login == Login && x.Password == Password);
<p>Переход по ролям:</p>
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
<hr>
Роли пользователей
<ul> <li><b>Администратор</b> <ul> <li>Панель управления (заглушка)</li> </ul> </li> <li><b>Врач</b> <ul> <li>Рабочая панель (заглушка)</li> </ul> </li> <li><b>Пациент</b> <ul> <li>Основная информация</li> <li>Возраст (вычисляется автоматически)</li> <li>Список аллергий</li> <li>История посещений</li> </ul> </li> </ul> <hr>
Запуск проекта
<ol> <li>Установить <b>.NET SDK</b></li> <li>Настроить строку подключения в <code>SheronovContext</code></li> <li>При необходимости выполнить миграции</li> <li>Запустить проект:</li> </ol>
dotnet run
<hr>
Текущие задачи
<ul> <li><input type="checkbox" disabled> Реализовать хеширование паролей</li> <li><input type="checkbox" disabled> Добавить полноценный logout</li> <li><input type="checkbox" disabled> Реализовать CRUD для администратора</li> <li><input type="checkbox" disabled> Подключить Dependency Injection</li> <li><input type="checkbox" disabled> Добавить валидацию данных</li> </ul> <hr>
Скриншот интерфейса
<p>Пример отображения экрана авторизации:</p> <p align="center"> <img src="https://via.placeholder.com/800x400?text=Hospital+Avalonia+Login+Screen" width="700"> </p> <p> Для добавления собственного изображения загрузите файл в папку <code>Assets</code> и используйте: </p>
<img src="Assets/screenshot.png" width="700">
<hr>
Назначение проекта
<p> Проект создан в учебных целях для демонстрации работы с Avalonia UI, архитектурой MVVM и Entity Framework Core. </p>

Если нужно, могу сделать более «профессиональную» версию с бейджами (Build, .NET version, License) и оформлением как production-репозитория.

добавь в код скрины, я их назвал avalonia-auth и avalonia-interface, в папке Assets они 

Вот обновлённый блок README с подключёнными изображениями из папки Assets.
GitHub корректно отобразит их, если структура репозитория выглядит так:

Hospital
├── Assets
│   ├── avalonia-auth.png
│   └── avalonia-interface.png

Добавь этот раздел в README.

Скриншоты интерфейса
<h3>Экран авторизации</h3> <p align="center"> <img src="Assets/avalonia-auth.png" alt="Authorization Screen" width="800"> </p> <h3>Интерфейс пациента</h3> <p align="center"> <img src="Assets/avalonia-interface.png" alt="User Interface Screen" width="800"> </p>

Если изображения имеют другое расширение (например .jpg), просто замени .png на нужное.

Если хочешь, могу сделать аккуратную сетку (две картинки в ряд) или добавить подписи в более строгом стиле.

а теперь целиком весь ридми чтобы я просто скопировал 

Вот полный готовый README.md, оформленный с HTML-разметкой, списками, вложенными списками, task-list, кодовыми блоками, ссылками и подключёнными скриншотами из папки Assets.

Ты можешь просто скопировать и вставить его в репозиторий.

Hospital Avalonia
<p> <b>Hospital Avalonia</b> — настольное приложение для управления медицинскими данными пациентов. Проект разработан с использованием <b>Avalonia UI</b>, <b>Entity Framework Core</b> и архитектуры <b>MVVM</b>. </p> <hr>
О проекте
<p> Приложение реализует: </p> <ul> <li>Авторизацию пользователей</li> <li>Разграничение доступа по ролям</li> <li>Отображение медицинской карты пациента</li> <li>Загрузку данных из базы данных</li> </ul> <p> Используемые технологии: <a href="https://dotnet.microsoft.com/">.NET</a>, <a href="https://avaloniaui.net/">Avalonia UI</a>, <a href="https://learn.microsoft.com/ef/core/">Entity Framework Core</a>, <a href="https://learn.microsoft.com/dotnet/communitytoolkit/mvvm/">CommunityToolkit.Mvvm</a> </p> <hr>
Стек технологий
<ul> <li>.NET</li> <li>Avalonia UI</li> <li>Entity Framework Core</li> <li>CommunityToolkit.Mvvm</li> <li>C#</li> <li>MVVM</li> </ul> <hr>
Архитектура проекта
<p><b>Паттерн:</b> Model–View–ViewModel (MVVM)</p> <pre> Hospital │ ├── Models ├── ViewModels │ ├── LoginPageViewModel │ ├── AdminViewModel │ ├── DoctorViewModel │ └── UserViewModel │ ├── Views │ ├── LoginPageView.axaml │ ├── AdminView.axaml │ ├── DoctorView.axaml │ └── UserView.axaml │ └── MainWindow </pre> <p>Переключение страниц осуществляется через <b>ContentControl</b>:</p>
<ContentControl Content="{Binding PageSwither}"/>
<hr>
Функциональность
Авторизация
currentUser = db.LoginTables
    .Include(x => x.IdUserNavigation)
    .FirstOrDefault(x => x.Login == Login && x.Password == Password);

Переход по ролям:

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
Роли пользователей
<ul> <li><b>Администратор</b> <ul> <li>Панель управления системой (заглушка)</li> </ul> </li> <li><b>Врач</b> <ul> <li>Рабочая панель врача (заглушка)</li> </ul> </li> <li><b>Пациент</b> <ul> <li>Основная информация (ФИО, дата рождения, рост, вес)</li> <li>Автоматический расчет возраста</li> <li>Список аллергий</li> <li>История посещений и диагнозов</li> </ul> </li> </ul>
Запуск проекта
<ol> <li>Установить <b>.NET SDK</b></li> <li>Настроить строку подключения в <code>SheronovContext</code></li> <li>При необходимости выполнить миграции</li> <li>Запустить проект:</li> </ol>
dotnet run
Текущие задачи
<ul> <li><input type="checkbox" disabled> Реализовать хеширование паролей</li> <li><input type="checkbox" disabled> Добавить полноценный logout</li> <li><input type="checkbox" disabled> Реализовать CRUD для администратора</li> <li><input type="checkbox" disabled> Подключить Dependency Injection</li> <li><input type="checkbox" disabled> Добавить валидацию данных</li> </ul>
Скриншоты интерфейса
<h3>Экран авторизации</h3> <p align="center"> <img src="Assets/avalonia-auth.png" alt="Authorization Screen" width="800"> </p> <h3>Интерфейс пациента</h3> <p align="center"> <img src="Assets/avalonia-interface.png" alt="User Interface Screen" width="800"> </p>
Назначение проекта
<p> Проект создан в учебных целях для демонстрации работы с Avalonia UI, архитектурой MVVM и Entity Framework Core. </p>