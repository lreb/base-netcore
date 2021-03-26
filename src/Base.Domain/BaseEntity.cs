using System;
using System.ComponentModel.DataAnnotations;

namespace Base.Domain
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
    public class BaseEntitySoftDelete: BaseEntity
    {
        public bool Active { get; set; }
    }

    public class BaseEntityFull : BaseEntitySoftDelete
    {
        public DateTime CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
