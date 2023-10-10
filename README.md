EntityFrameworkCore.ConfigurationManager
========================================

![build status](https://img.shields.io/github/actions/workflow/status/efcore/EFCore.ConfigurationManager/dotnet.yml?branch=main) [![latest version](https://img.shields.io/nuget/v/EntityFrameworkCore.ConfigurationManager)](https://www.nuget.org/packages/EntityFrameworkCore.ConfigurationManager) [![downloads](https://img.shields.io/nuget/dt/EntityFrameworkCore.ConfigurationManager)](https://www.nuget.org/packages/EntityFrameworkCore.ConfigurationManager) ![license](https://img.shields.io/github/license/efcore/EFCore.ConfigurationManager)

Extends EF Core to resolve connection strings from App.config.

Installation
------------

The latest stable version is available on [NuGet](https://www.nuget.org/packages/EntityFrameworkCore.ConfigurationManager).

```sh
dotnet add package EntityFrameworkCore.ConfigurationManager
```

Compatibility
-------------

The following table shows which version of this library to use with which version of EF Core.

EF Core              | Version to use
-------------------- | --------------
8.0                  | 2.x
7.0                  | 2.x
6.0                  | 2.x
3.1 (Out of support) | 1.x

Usage
-----

Enable the extension by calling `UseConfigurationManager` inside OnConfiguring of your DbContext type. Use a special connection string containing the `Name` keyword to resolve it from App.config.

```cs
protected override void OnConfiguring(DbContextOptionsBuilder options)
    => options
        .UseConfigurationManager()
        .UseSqlite("Name=MyConnection");
```

A corresponding App.config would look like this.

```xml
<configuration>
  <connectionStrings>
    <add name="MyConnection" connectionString="Data Source=My.db" />
  </connectionStrings>
</configuration>
```

This extension also works at design time when scaffolding a DbContext.

```ps1
Scaffold-DbContext Name=MyConnection Microsoft.EntityFrameworkCore.Sqlite
```

```sh
dotnet ef dbcontext scaffold Name=MyConnection Microsoft.EntityFrameworkCore.Sqlite
```
