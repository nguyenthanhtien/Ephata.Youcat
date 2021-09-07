using Nest;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ephata.YouCat.Data.ElasticClientHandler
{
    public interface IElasticClientHandler : IElasticClient
    {
        //should add singleton this class on middleware
    }
}
