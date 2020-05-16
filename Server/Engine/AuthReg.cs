using System;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Windows;

namespace WcfService.Engine
{
   class AuthReg
   {
      private static string path = @"C:\Users\good\Desktop\Project\Game\Console_Game\WCFServise\WcfService\App_Data\key.txt";

      public static PlayerServer Authorization(string login, string password)
      {
         using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
         {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
               string[] word = line.Split(' ');

               //Если уже есть авторизованнные с таким ником, то не даём авторизоваться
               var usedLogin = AllPlayers.players.FirstOrDefault(i => i.Login == login);
               if (usedLogin != null)
                  return null;

               if (word[0] == login && word[1] == password)
               {
                  Point lastPostion = LastPosition.LoadLastPosition(login);
                  PlayerServer player = new PlayerServer(login, Guid.NewGuid(), lastPostion, OperationContext.Current);

                  AllPlayers.players.Add(player);

                  foreach (PlayerServer playerServer in AllPlayers.players)
                  {
                     if (player != playerServer)
                     {
                        playerServer.OperationContext.GetCallbackChannel<IClientCallback>().ConnectEnemy(player);
                     }
                  }

                  return player;
               }
            }
            return null;
         }
      }

      public static PlayerServer Registration(string login, string password)
      {
         using (StreamWriter writer = new StreamWriter(path, true))
         {
            writer.Write($"\n{login} {password}");
         }

         PlayerServer player = new PlayerServer(login, Guid.NewGuid(), OperationContext.Current);
         AllPlayers.players.Add(player);

         foreach (PlayerServer playerServer in AllPlayers.players)
         {
            if (player != playerServer)
            {
               playerServer.OperationContext.GetCallbackChannel<IClientCallback>().ConnectEnemy(player);
            }
         }

         return player;
      }

      public static bool AvailabilityLogin(string login)
      {
         using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
         {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
               string[] word = line.Split(' ');

               if (word[0] == login)
               {
                  return false;
               }
            }
            return true;
         }
      }
   }
    
}