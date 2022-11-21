﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TournamentApp.Services
{
    public interface IAuthService
    {
        Task<string> LoginWithEmailPassword(string email, string password);

        bool SignOut();
        bool IsLoggedIn();
    }
}
