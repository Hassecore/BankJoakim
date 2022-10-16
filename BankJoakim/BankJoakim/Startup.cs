using BankJoakim.MediatR.QueryHandlers;
using BankJoakim.Models;
using BankJoakim.Models.Accounts;
using BankJoakim.Models.Accounts.RandomIbanRetriever;
using BankJoakim.Models.Customers;
using BankJoakim.Models.Deposits;
using BankJoakim.Models.Transactions;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace BankJoakim
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddMediatR(typeof(AccountQueryHandler).GetTypeInfo().Assembly);

            services.AddDbContext<BankContext>();

            services.AddScoped<IAccountsRepository, AccountsRepository>();
            services.AddScoped<ICustomersRepository, CustomersRepository>();
            services.AddScoped<IDepositsRepository, DepositsRepository>();
            services.AddScoped<ITransactionsRepository, TransactionsRepository>();

            services.AddScoped<IRandomIbanRetriever, RandomIbanRetriever>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
