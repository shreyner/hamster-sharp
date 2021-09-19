# Application Monitoring

Добавление миграций

Перейти в Application нужного проекта

-p Указать проект с DB

```shell
dotnet ef migrations add InitialCreate -p ../MetricsManager.DB
```

Для обновления локально базы
```shell
dotnet ef database update
```