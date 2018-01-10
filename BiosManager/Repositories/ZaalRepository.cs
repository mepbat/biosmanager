using BiosManager.Context;
using BiosManager.Models;

namespace BiosManager.Repositories
{
 public class ZaalRepository
 {
     readonly IZaalContext rep;
     public ZaalRepository(IZaalContext context)
     {
         rep = context;
     }

     public Zaal GetById(int id)
     {
         return rep.GetById(id);
     }
    }
}