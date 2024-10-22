#https://learn.microsoft.com/en-us/dotnet/core/docker/build-container?tabs=windows&pivots=dotnet-8-0#create-the-dockerfile
 
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Устанавливаем рабочую директорию
WORKDIR /app

# Обновляем сертификаты
RUN apt-get update && apt-get install -y ca-certificates && update-ca-certificates

# Копируем файл проекта и выполняем восстановление зависимостей
COPY *.csproj ./
RUN dotnet restore

# Копируем все файлы и выполняем сборку
COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0

# Рабочая директория
WORKDIR /app

# Копируем собранные файлы
COPY --from=build /app/out .

# Запускаем приложение
ENTRYPOINT ["dotnet", "OrderService.dll"]
