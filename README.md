# Virgo.Backend.UpdateDatabase
This project is responsible for updating database schema on the fly.

## Supported parameters
`--RunMigration=true | false`  
`--RunMigrationTo="target ID"`  
`--RunFix=true | false`

## Apply database migration
- Full Migration  
  Under the UpdateDatabase project folder, run the command `dotnet run --RunMigration=true`
- Target Migration  
  Under the UpdateDatabase project folder, run the command `dotnet run --RunMigrationTo=<Target ID>`. You need to replace the `<Target ID>` with the string value of your migration.

## Run database fix
Under the UpdateDatabase project folder, run the command `dotnet run --RunFix=true`.