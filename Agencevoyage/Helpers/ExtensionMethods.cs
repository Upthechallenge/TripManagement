using Agencevoyage.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Agencevoyage.Helpers
{
    public static class ExtensionMethods
    {
        public static IEnumerable<SelectListItem> ToSelectListItems(
              this IEnumerable<Producteur> producteurs)
        {
            return
                producteurs.OrderBy(prod => prod.FirstName)
                      .Select(prod =>
                          new SelectListItem
                          {
                         //     Selected = (prod.ProducteurId == selectedId),
                              Text = prod.FirstName+" "+prod.LastName,
                              Value = prod.ProducteurId.ToString()
                          });
        }
        public static IEnumerable<SelectListItem> ToSelectListItems(
              this IEnumerable<string> genres)
        {
            return
                genres.OrderBy(genre => genre)
                      .Select(genre =>
                          new SelectListItem
                          {
                              
                              Text = genre,
                              Value = genre
                          });
        }
    }
}