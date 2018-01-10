using System.Collections.Generic;
using BiosManager.Context;
using BiosManager.Models;

namespace BiosManager.Repositories
{
 public class StoelRepository
 {
     readonly IStoelContext rep;
     public StoelRepository(IStoelContext context)
     {
         rep = context;
     }

     public List<Stoel> GetByZaalId(int zaalId)
     {
         return rep.GetByZaalId(zaalId);
     }

     public void UpdateStoel(Stoel s, int reserveringId)
     {
         rep.Update(s, reserveringId);
     }
 }
}