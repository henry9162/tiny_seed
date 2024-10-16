using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SMW.Data;
using SMW.Models.shared;

namespace SMW.Utilities.ModelAbstractions
{
    public interface IModelAbstractions<T> where T : class, IModelTags, new()
    {
        List<T> GetUpdatedItems(List<T> Items, List<int> Ids);
        public double GetListAmount(List<T> Items);
    }
}