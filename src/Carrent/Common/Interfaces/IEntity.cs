using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Carrent.Common.Interfaces
{
    public interface IEntity<T>
    {
        /// <summary>
        /// Contains the Identification of the Data-set
        /// </summary>
        [Key]
        T Id { get; set; }
    }
}
