using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WcfService.Engine;
using System.ServiceModel;
using System.Windows;

namespace WcfService
{
    public interface IClientCallback
    {
        [OperationContract]
        void ConnectEnemy(PlayerServer player);
        [OperationContract]
        void DisconectEnemy(Guid id);
        [OperationContract]
        void ChangeEnemyPosition(Guid id, Point position);
        [OperationContract]
        void EnemyEatFood(FoodPoint foodPoint, int id, Guid id_player);
    }
}