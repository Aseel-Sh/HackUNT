using Backend.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Meeting
{
    public int Id { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]

    [Column("Name")]
    public string Title { get; set; }


    [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
    public string Description { get; set; }

        
    [Required]
    public DateTimeOffset startTime { get; set; }

    [Required]
    public DateTimeOffset endTime { get; set; }
        [Required]
      
    public int CreatedByUserID { get; set; }
    public List<User> Users { get; set; } = new List<User>();

    

}


