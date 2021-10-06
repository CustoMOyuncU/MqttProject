using System;
using System.Threading.Tasks;
using InfluxDB.Client;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Text;

namespace Core.DataAccess.InfluxDB
{
    public class InfluxDbRepositoryBase
    {

        private const string token = "86NIeBesBgw7neRRYyubxUggjyypEuSQ87i1awML7URTjl3FaMN54qkwr1D8mRV7lAOkNC6a3NY2bLx2IifKHw==";



        public void Write(Action<WriteApi> action)
        {
            using var client = InfluxDBClientFactory.Create("http://192.168.20.60:8086", token);
            using var write = client.GetWriteApi();
            action(write);
        }

        public async Task<T> QueryAsync<T>(Func<QueryApi, Task<T>> action)
        {
            using var client = InfluxDBClientFactory.Create("http://192.168.20.60:8086", token);
            var query = client.GetQueryApi();
            return await action(query);
        }
        
    }
}
