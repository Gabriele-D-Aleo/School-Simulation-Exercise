using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonValidator
{
    internal class JsonValObj
    {
        /// <summary>
        /// this is the collection for all the properties in the json,
        /// these must mirror the ones in the model object
        /// </summary>
        ICollection<string> PropertyList { get; set; }


    }
}
