using Agencevoyage.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Agencevoyage.Models
{
    public class FilmViewModel
    {

        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        [Display(Name = "Déscription")]
        public string Description { get; set; }

        /// <summary>
        /// Out date
        /// </summary>
        [Display(Name = "Date de sortie")]
        public DateTime OutDate { get; set; }

        /// <summary>
        /// Image Name
        /// </summary>
        [DataType(DataType.ImageUrl), Display(Name = "Image")]
        public string ImageUrl { get; set; }

        /// <summary>
        /// Genre
        /// </summary>
        public string Genre { get; set; }

        [Display(Name = "Producteur")]
      
        public int? ProducteurId { get; set; } // ? nullable

        public IEnumerable<SelectListItem> Genres { get; set; }
        public IEnumerable<SelectListItem> Productors { get; set; }
    }
}