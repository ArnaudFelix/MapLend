using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MapLend.Business;

namespace MapLend.Mvc.Models
{
    public class MapViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nom")]
        public string Name { get; set; }

        [Display(Name = "Nbr. utilisateurs")]
        public int NbUsers { get; set; }

        public MapViewModel() { }
        public MapViewModel(Map map)
        {
            Id = map.Id;
            Name = map.Name;
            NbUsers = map.Users.Count;
        }

        public static ICollection<MapViewModel> CastIntoList(List<Map> mapList)
        {
            List<MapViewModel> list = new List<MapViewModel>();
            mapList.ForEach(m => list.Add(new MapViewModel(m)));
            return list;
        }
    }
}