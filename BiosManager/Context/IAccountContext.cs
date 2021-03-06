﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiosManager.Models;

namespace BiosManager.Context
{
    public interface IAccountContext
    {
        void Insert(Account account);
        List<Account> Select();
        void Update(Account account, string nieuwWachtwoord);
    }
}
