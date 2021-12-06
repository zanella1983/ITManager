using ITManager.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITManager.WebMvc.Models
{
    public class ListUserViewModel
    {
        public List<UserDto> Users { get; set; }

        public ListUserViewModel()
        {
            Users = new List<UserDto>();
        }
    }
}
