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

        public string Address { get; set; }

        public ICollection<MapUserViewModel> Users { get; set; }

        public MapViewModel() { }
        public MapViewModel(Map map, bool withUsers = false)
        {
            Id = map.Id;
            Name = map.Name;
            NbUsers = map.Users.Count;

            Address = map.Address.ToString();

            if (withUsers)
            {
                Users = new List<MapUserViewModel>();
                foreach (var user in map.Users)
                {
                    Users.Add(new MapUserViewModel
                    {
                        FullName = user.Firstname + " " + user.Surname,
                        Address = user.Address.ToString()
                    });
                }
            }
        }

        public static ICollection<MapViewModel> CastIntoList(List<Map> mapList)
        {
            List<MapViewModel> list = new List<MapViewModel>();
            mapList.ForEach(m => list.Add(new MapViewModel(m)));
            return list;
        }

        public class MapUserViewModel
        {
            public string FullName { get; set; }
            public string Address { get; set; }
        }
    }
}