using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiosManager.Models;

namespace BiosManager.Context
{
    public interface IStoelContext
    {
        void Update(Stoel stoel, int resId);
        List<Stoel> GetByZaalId(int id);
    }
}
