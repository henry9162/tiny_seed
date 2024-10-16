using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMW.Models.shared
{
    public interface IModelTags
    {
        int Id { get; set; }
        string? Name { get; set; }
        double Price { get; set; }
    }
}