using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SMW.Data;
using SMW.Models.shared;

namespace SMW.Utilities.ModelAbstractions
{
    public class ModelAbstractions<T> : IModelAbstractions<T> where T : class, IModelTags, new()
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<T> _dbSet;

        public ModelAbstractions(DatabaseContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public List<T> GetUpdatedItems(List<T> Items, List<int> Ids)
        {
            // Remove the Db item which are not in the list of new items
            foreach (var item in Items){
                if (!Ids!.Contains(item.Id))
                    Items.Remove(item);
            }
            
            // Add the new items which are not in the list of DB items
            foreach (var Id in Ids!)
            {
                if (Items.Any(x => x.Id == Id))
                {
                    var newItem = new T { Id = Id };
                    _dbSet.Attach(newItem);
                    Items.Add(newItem);
                }
            }

            return Items;
        }

        public double GetListAmount(List<T> Items)
        {
            var itemAmount = 0.0;

            foreach (var item in Items){
                itemAmount += item.Price;
            }

            return itemAmount;
        }
    }
}