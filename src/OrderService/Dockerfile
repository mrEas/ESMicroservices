#https://learn.microsoft.com/en-us/dotnet/core/docker/build-container?tabs=windows&pivots=dotnet-8-0#create-the-dockerfile
 
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# ������������� ������� ����������
WORKDIR /app

# ��������� �����������
#RUN apt-get update && apt-get install -y ca-certificates && update-ca-certificates

# �������� ���� ������� � ��������� �������������� ������������
COPY *.csproj ./
RUN dotnet restore

# �������� ��� ����� � ��������� ������
COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0

# ������� ����������
WORKDIR /app

# �������� ��������� �����
COPY --from=build /app/out .

# ��������� ����������
ENTRYPOINT ["dotnet", "OrderService.dll"]
