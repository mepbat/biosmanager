﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiosManager.Models;

namespace BiosManager.Context
{
 public interface IFilmContext
 {
  void Insert(Film film);
  List<Film> Select();
  void Delete(Film film);
     Film GetById(int id);
 }
}
