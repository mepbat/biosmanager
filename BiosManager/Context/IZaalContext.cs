﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiosManager.Models;

namespace BiosManager.Context
{
 public interface IZaalContext
 {
  List<Zaal> Select();
     Zaal GetById(int id);
 }
}
