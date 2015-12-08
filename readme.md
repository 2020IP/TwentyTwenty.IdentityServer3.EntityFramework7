#20|20 IdentityServer3.EntityFramework7

###Entity Framework 7 persistence layer for [IdentityServer v3](https://github.com/IdentityServer/IdentityServer3)

Appveyor Build: [![Build status](https://ci.appveyor.com/api/projects/status/a5fpfldw17icqq8l/branch/master?svg=true)](https://ci.appveyor.com/project/2020IP/twentytwenty-identityserver3-entityframework7/branch/master)

#### Usage
The primary key type can be configured for ClientStore and ScopeStore.  To facilitate this, subclass the `ClientConfigurationContext<TKey>` and `ScopeConfigurationContext<TKey>` with the desired key type.
```
public class ClientConfigurationContext : ClientConfigurationContext<Guid>
{
	public ClientConfigurationContext(DbContextOptions options)
		: base(options)
	{ }
}

public class ScopeConfigurationContext : ScopeConfigurationContext<Guid>
{
	public ScopeConfigurationContext(DbContextOptions options)
		: base(options)
	{ }
}
```
In the `Startup.cs`, register your DbContexts with Entity Framework
```
public void ConfigureServices(IServiceCollection services)
{
	...
	services.AddEntityFramework()
		.AddSqlServer()
		.AddDbContext<ClientConfigurationContext>(o => o.UseSqlServer(connectionString))
		.AddDbContext<ScopeConfigurationContext>(o => o.UseSqlServer(connectionString))
		.AddDbContext<OperationalContext>(o => o.UseSqlServer(connectionString));
	...
}
```
Configure the `IdentityServerServiceFactory` to use the EF stores.
```
public void Configure(IApplicationBuilder app)
{
	...
	var factory = new IdentityServerServiceFactory();
	factory.ConfigureEntityFramework(app.ApplicationServices)
		.RegisterOperationalStores()
		.RegisterClientStore<Guid, ClientConfigurationContext>()
		.RegisterScopeStore<Guid, ScopeConfigurationContext>();

	owinAppBuilder.UseIdentityServer(new IdentityServerOptions
	{
		...
		Factory = factory,
		...
	});
	...
}
```