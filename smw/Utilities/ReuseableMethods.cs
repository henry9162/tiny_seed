using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SMW.Data;
using SMW.Models;
using SMW.Models.shared;

namespace SMW.Utilities
{
    public static class ReuseableMethods
    {
        public static double GetListAmount(List<StyleAttribute> styleAttributes)
        {
            var styleAmount = 0.0;

            foreach (var attribute in styleAttributes){
                styleAmount += attribute.Price;
            }

            return styleAmount;
        }


        // Logic to calculate total amount
        // if (!ProvidedFabric){
        //     // Refactor this as a utility function that can be called dynamically.
        //     double fabricAmount = 0;

        //     foreach (var fabric in CustomRequestFabrics!)
        //     {
        //         fabricAmount += fabric.Amount;
        //     }

        //     return Style!.Amount + fabricAmount + DeliveryAmount;
        // }

        // //This means SMW picks up the material from client. Delivery calculations needs to be implemented
        // return Style!.Amount + PickUpAmount + DeliveryAmount;
    }
}