using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotteHulletMvvm.Models
{
    class Model
    {
        public int Id { get; }

        protected Model() { }
        protected Model(int id)
        {
            Id = id;
        }
    }
}
