using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PriSchLecs.Api.Domains.BaseEntities
{
    public class BaseEntityByInt: BaseEntity
    {
        /// <summary>
        /// Id của thực thể
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }                 
    }
}
