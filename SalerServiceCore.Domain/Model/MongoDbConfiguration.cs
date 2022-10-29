using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalerServiceCore.Domain.Model
{
    /// <summary>
    /// The MongoDbConfiguration class
    /// </summary>
    public class MongoDbConfiguration
    {
        /// <summary>
        /// gets or sets the connection string 
        /// </summary>
        public string? ConnectionString { get; set; }
        /// <summary>
        /// gets or sets the Database
        /// </summary>
        public string? Database { get; set; }
        /// <summary>
        /// gets or sets the Collections
        /// </summary>
        public IReadOnlyDictionary<string,string>? Collections { get; set; }
    }
}
