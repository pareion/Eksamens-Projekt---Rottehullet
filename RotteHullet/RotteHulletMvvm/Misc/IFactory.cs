using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RotteHulletMvvm.Models;

namespace RotteHulletMvvm.Misc
{
    interface IFactory<T> where T : Model
    {
        T Create();
    }
}
