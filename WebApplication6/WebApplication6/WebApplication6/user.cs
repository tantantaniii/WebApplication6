using Supabase.Postgrest.Models;
using Supabase.Postgrest.Attributes;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;


namespace WebApplication6
{
    [Table("users")]

    public class User: BaseModel
    {
        [PrimaryKey]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("age")] 
        public int Age { get; set; }
    }

    [Table("city")]

    public class City : BaseModel
    {
        [PrimaryKey]
        public int Id { get; set; }
        [Column("name_of_city")]
        public string Name_of_city { get; set; }
    }
}
