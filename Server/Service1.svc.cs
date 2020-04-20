using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Windows;
using WcfService.Engine;

namespace WcfService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы Service1.svc или Service1.svc.cs в обозревателе решений и начните отладку.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class Service1 : IAuthorization
    {
        private string path = @"C:\Users\good\Desktop\Project\Game\Console_Game\WCFServise\WcfService\App_Data\key.txt";

        public Service1()
        {
            Random r = new Random();
            for(int i = 0; i <= 10; i++)
            {
                int x = r.Next(10, 550);
                int y = r.Next(10, 350);
                FoodPoint.FoodPoints.Add(new FoodPoint(x,y));
            }

        }

        public Guid Authorization(string login, string password)
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
                        return Guid.Empty;

                    if (word[0] == login && word[1] == password)
                    {
                        PlayerServer player = new PlayerServer(login, Guid.NewGuid(), OperationContext.Current);

                        AllPlayers.players.Add(player);

                        foreach (PlayerServer playerServer in AllPlayers.players)
                        {
                            if (player != playerServer)
                            {
                                playerServer.OperationContext.GetCallbackChannel<IClientCallback>().ConnectEnemy(player);
                            }
                        }

                        return player.ID;
                    }
                }
                return Guid.Empty;
            }
        }

        public Guid Registration(string login, string password)
        {
            try
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

                return player.ID;
            }
            catch (Exception)
            {
                return Guid.Empty;
            }
        }

        public bool AvailabilityLogin(string login)
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

        public void ServerStatus()
        {
            //Пустой метод для проверки работы сервиса
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public List<PlayerServer> GetAllPlayers(Guid id)
        {
            List<PlayerServer> enemyPlayer = new List<PlayerServer>();
            foreach (PlayerServer player in AllPlayers.players)
            {
                if (player.ID != id)
                {
                    enemyPlayer.Add(player);
                }
            }

            return enemyPlayer;
        }

        public void Disconnect(Guid id)
        {
            var player = AllPlayers.players.FirstOrDefault(i => i.ID == id);
            AllPlayers.players.Remove(player);
            foreach (PlayerServer playerServer in AllPlayers.players)
            {
                playerServer.OperationContext.GetCallbackChannel<IClientCallback>().DisconectEnemy(id);
            }

        }

        public void SendClientData(PlayerServer player)
        {
            foreach (PlayerServer playerr in AllPlayers.players)
            {
                playerr.OperationContext.GetCallbackChannel<IClientCallback>().ConnectEnemy(player);
            }

            AllPlayers.players.Add(player);
        }

        public void ChangePosition(Guid id, Point position)
        {
            var player = AllPlayers.players.FirstOrDefault(i => i.ID == id);
            player.Position = position;
            foreach (PlayerServer playerServer in AllPlayers.players)
            {
                if (id != playerServer.ID)
                {
                    playerServer.OperationContext.GetCallbackChannel<IClientCallback>().ChangeEnemyPosition(id, position);
                }
            }
        }

        public List<FoodPoint> GetFoods()
        {
            return FoodPoint.FoodPoints;
        }
    }
}
