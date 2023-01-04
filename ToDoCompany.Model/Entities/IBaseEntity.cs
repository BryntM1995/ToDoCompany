using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ToDoCompany.Model.Entities
{
    public interface IBaseEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class BaseEntity : IBaseEntity
    {
        [Key]
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
