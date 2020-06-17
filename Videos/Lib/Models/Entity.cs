using System;
using System.Collections.Generic;
using System.Text;

namespace Videos.Lib.Models
{
    class Entity
    {
        public Guid Id;

        public Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
