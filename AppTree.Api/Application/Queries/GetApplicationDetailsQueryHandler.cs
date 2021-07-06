using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using AppTree.Api.Models;
using Dapper;
using MediatR;
using Microsoft.Extensions.Options;

namespace AppTree.Api.Application.Queries
{
    public class GetApplicationDetailsQueryHandler : IRequestHandler<GetApplicationDetailsQuery, Models.ApplicationModel>
    {
        private readonly string _connString;

        public GetApplicationDetailsQueryHandler(IOptions<AppTreeSettings> config)
        {
            _connString = !string.IsNullOrWhiteSpace(config.Value?.AppTreeContext) ? config.Value.AppTreeContext : throw new ArgumentNullException(nameof(AppTreeSettings));
        }

        public async Task<Models.ApplicationModel> Handle(GetApplicationDetailsQuery request, CancellationToken cancellationToken)
        {
            using var connection = new SqlConnection(_connString);

            connection.Open();

            var appResult = await connection.QueryFirstOrDefaultAsync<Models.ApplicationModel>(
               @"SELECT a.Id, a.Name, a.Summary, a.Repository, t.Type
                     FROM Application a 
                     INNER JOIN ApplicationType t ON a.ApplicationTypeId = t.Id
                     WHERE a.Id=@applicationId", new { request.ApplicationId }
                );

            if (appResult == default(Models.ApplicationModel))
                throw new KeyNotFoundException();


            var depResult = await connection.QueryAsync<Models.ApplicationDependencyModel>(
               @"SELECT d.ParentApplicationId, a.Id ApplicationId, a.Name, t.Type
                     FROM Dependency d
                     INNER JOIN Application a ON d.ApplicationId = a.Id
                     INNER JOIN ApplicationType t ON a.ApplicationTypeId = t.Id
                     WHERE d.ParentApplicationId=@applicationId", new { request.ApplicationId }
                );

            if (depResult.AsList().Count > 0)
            {
                appResult.Dependencies = depResult.AsList();
            }

            return appResult;
        }
    }
}
