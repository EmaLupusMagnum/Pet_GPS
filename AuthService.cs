﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetGPS
{
    public class AuthService
    {
        public async Task<bool> IsAuthenticatedAsync()
        {
            var users = App.UserRepo.GetItems();

            await Task.Delay(2000);

            if(users.Count() > 0)
                return true;
            return false;
        }
    }
}
