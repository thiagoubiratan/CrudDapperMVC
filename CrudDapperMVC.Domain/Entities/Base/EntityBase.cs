using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CrudDapperMVC.Domain.Entities.Base
{
    public class EntityBase
    {
        public EntityBase()
        {
            DateRegister = DateTime.Now;
        }
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [DisplayName("Ativo")]
        public bool Active { get; set; }
        
        [ScaffoldColumn(false)]
        public DateTime DateRegister { get; set; }
    }
}
