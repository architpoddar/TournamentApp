using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateData
{
    public class FirebaseHelper
    {
        FirebaseClient firebaseClient = new FirebaseClient("your_firebase_url");

        public async Task AddPlayer(Player player)
        {
            if (player == null)
                return;

            try
            {
                var child = firebaseClient.Child("Players");
                var result = await child.PostAsync(player);
            }
            catch(Exception ex)
            {

            }
           
        }
    }
}
