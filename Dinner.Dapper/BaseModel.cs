using System;
using System.Collections.Generic;
using System.Text;

namespace Dinner.Dapper
{
    public class BaseModel : IEntity<Guid>
    {
        public Guid Id { get; set; }
    }
}
