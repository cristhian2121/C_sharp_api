docker run --rm --name SQLServerKr -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Test123." -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-latest

**Create migrations**
`dotnet ef migrations InitialCreate`

**Migrate**
`dotnet ef database update`
