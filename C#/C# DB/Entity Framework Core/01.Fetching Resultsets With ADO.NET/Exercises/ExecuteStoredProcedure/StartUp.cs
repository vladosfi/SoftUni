using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Search.Fluent;
using Microsoft.Azure.Management.Search.Fluent.Models;
using Microsoft.Azure.Management.Search.Fluent.SearchService.Update;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace ExecuteStoredProcedure
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int id = int.Parse(Console.ReadLine());

            const string CONNECTION_STRING = "Server=B5400\\.;Database=BestService;Integrated Security = true";

            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                string uspGetOlder = "EXEC usp_GetOlder @id";

                using (SqlCommand command = new SqlCommand(uspGetOlder, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = (string)reader[0];
                            int age = (int)reader[1];

                            Console.WriteLine($"{name} - {age} years old");
                        }
                    }
                }

            }
        }
    }
    public class SearchService : ISearchService
    {
        public HostingMode HostingMode => throw new NotImplementedException();

        public ProvisioningState ProvisioningState => throw new NotImplementedException();

        public int PartitionCount => throw new NotImplementedException();

        public int ReplicaCount => throw new NotImplementedException();

        public string StatusDetails => throw new NotImplementedException();

        public Sku Sku => throw new NotImplementedException();

        public SearchServiceStatus Status => throw new NotImplementedException();

        public string Type => throw new NotImplementedException();

        public string RegionName => throw new NotImplementedException();

        public Region Region => throw new NotImplementedException();

        public IReadOnlyDictionary<string, string> Tags => throw new NotImplementedException();

        public string Key => throw new NotImplementedException();

        public string Id => throw new NotImplementedException();

        public string Name => throw new NotImplementedException();

        public string ResourceGroupName => throw new NotImplementedException();

        public ISearchManager Manager => throw new NotImplementedException();

        public SearchServiceInner Inner => throw new NotImplementedException();

        public IQueryKey CreateQueryKey(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryKey> CreateQueryKeyAsync(string name, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public void DeleteQueryKey(string key)
        {
            throw new NotImplementedException();
        }

        public Task DeleteQueryKeyAsync(string key, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public IAdminKeys GetAdminKeys()
        {
            throw new NotImplementedException();
        }

        public Task<IAdminKeys> GetAdminKeysAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<IQueryKey> ListQueryKeys()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IQueryKey>> ListQueryKeysAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ISearchService Refresh()
        {
            throw new NotImplementedException();
        }

        public Task<ISearchService> RefreshAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public IAdminKeys RegenerateAdminKeys(AdminKeyKind keyKind)
        {
            throw new NotImplementedException();
        }

        public Task<IAdminKeys> RegenerateAdminKeysAsync(AdminKeyKind keyKind, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public List<SearchResult> Search(string searchTerm, int? page)
        {
            using (DotnettingContext _context = new DotnettingContext())
            {
                var param1 = new SqlParameter("@SearchTerm", searchTerm);
                var param2 = new SqlParameter("@CurrentPage", page);
                var result = _context.Database.SqlQuery<SearchResult>("Search @SearchTerm, @CurrentPage", param1, param2).ToList();
                return result;
            }
        }

        public IUpdate Update()
        {
            throw new NotImplementedException();
        }
    }

    public class SearchResult
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int TotalRecords { get; set; }
    }
}
