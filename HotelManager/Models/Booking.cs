using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HotelManager.Models
{
    public class Booking
    {
        [Key]
        [Column(Order = 1)]
        [JsonIgnore]
        public int Id { get; set; }
        [Required]
        public string HotelName { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string CustomerSurname { get; set; }
        
        public string CustomerMidName { get; set; }
        public DateTime? CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; } 
        public string Currency { get; set; }
        public ushort RoomNumber { get; set; }

    }
 
     
}
