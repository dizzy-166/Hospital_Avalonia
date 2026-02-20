<h1>Hospital Avalonia</h1>

<p>
  <b>Hospital Avalonia</b> — настольное приложение для управления медицинскими данными пациентов. 
  Проект разработан с использованием <b>Avalonia UI</b>, <b>Entity Framework Core</b> и архитектуры <b>MVVM</b>.
</p>

<hr>

<h2>О проекте</h2>

<p>Приложение реализует:</p>
<ul>
  <li>Авторизацию пользователей</li>
  <li>Разграничение доступа по ролям</li>
  <li>Отображение медицинской карты пациента</li>
  <li>Загрузку данных из базы данных</li>
</ul>

<p>
  Используемые технологии: 
  <a href="https://dotnet.microsoft.com/">.NET</a>, 
  <a href="https://avaloniaui.net/">Avalonia UI</a>, 
  <a href="https://learn.microsoft.com/ef/core/">Entity Framework Core</a>, 
  <a href="https://learn.microsoft.com/dotnet/communitytoolkit/mvvm/">CommunityToolkit.Mvvm</a>
</p>

<hr>

<h2>Стек технологий</h2>

<ul>
  <li>.NET</li>
  <li>Avalonia UI</li>
  <li>Entity Framework Core</li>
  <li>CommunityToolkit.Mvvm</li>
  <li>C#</li>
  <li>MVVM</li>
</ul>

<hr>

<h2>Архитектура проекта</h2>

<p><b>Паттерн:</b> Model–View–ViewModel (MVVM)</p>

<pre>
Hospital
│
├── Models
├── ViewModels
│   ├── LoginPageViewModel
│   ├── AdminViewModel
│   ├── DoctorViewModel
│   └── UserViewModel
│
├── Views
│   ├── LoginPageView.axaml
│   ├── AdminView.axaml
│   ├── DoctorView.axaml
│   └── UserView.axaml
│
└── MainWindow
</pre>

<p>Переключение страниц осуществляется через <b>ContentControl</b>:</p>

<pre>
&lt;ContentControl Content="{Binding PageSwither}"/&gt;
</pre>

<hr>

<h2>Функциональность</h2>

<h3>Авторизация</h3>

<pre>
currentUser = db.LoginTables
    .Include(x => x.IdUserNavigation)
    .FirstOrDefault(x => x.Login == Login && x.Password == Password);
</pre>

<h3>Переход по ролям</h3>

<pre>
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
</pre>

<hr>

<h2>Роли пользователей</h2>

<ul>
  <li>
    <b>Администратор</b>
    <ul>
      <li>Панель управления системой (заглушка)</li>
    </ul>
  </li>
  <li>
    <b>Врач</b>
    <ul>
      <li>Рабочая панель врача (заглушка)</li>
    </ul>
  </li>
  <li>
    <b>Пациент</b>
    <ul>
      <li>Основная информация (ФИО, дата рождения, рост, вес)</li>
      <li>Автоматический расчет возраста</li>
      <li>Список аллергий</li>
      <li>История посещений и диагнозов</li>
    </ul>
  </li>
</ul>

<hr>

<h2>Запуск проекта</h2>

<ol>
  <li>Установить <b>.NET SDK</b></li>
  <li>Настроить строку подключения в <code>SheronovContext</code></li>
  <li>При необходимости выполнить миграции</li>
  <li>Запустить проект:</li>
</ol>

<pre>
dotnet run
</pre>

<hr>

<h2>Текущие задачи</h2>

<ul>
  <li><input type="checkbox" disabled> Реализовать хеширование паролей</li>
  <li><input type="checkbox" disabled> Добавить полноценный logout</li>
  <li><input type="checkbox" disabled> Реализовать CRUD для администратора</li>
  <li><input type="checkbox" disabled> Подключить Dependency Injection</li>
  <li><input type="checkbox" disabled> Добавить валидацию данных</li>
</ul>

<hr>

<h2>Скриншоты интерфейса</h2>

<h3>Экран авторизации</h3>
<p align="center">
  <img src="Assets/avalonia-auth.png" alt="Authorization Screen" width="800">
</p>

<h3>Интерфейс пациента</h3>
<p align="center">
  <img src="Assets/avalonia-interface.png" alt="User Interface Screen" width="800">
</p>

<hr>

<h2>Структура папки Assets</h2>

<pre>
Hospital
├── Assets
│   ├── avalonia-auth.png
│   └── avalonia-interface.png
</pre>

<hr>

<h2>Назначение проекта</h2>

<p>
  Проект создан в учебных целях для демонстрации работы с Avalonia UI, 
  архитектурой MVVM и Entity Framework Core.
</p>