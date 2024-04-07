using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetWebApi.DTOs
{
    public class ClubPostDto
    {
        // Nombre del Club
        [StringLength(maximumLength:150)]
        public string Name { get; set; }
    }
}
