using Assets.Scripts.Data;
using Assets.Scripts.Features.Rewards;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Shop
{

    public interface IPlayer
    {
        public void AddReward(RewardTypeId rewardType, int count);
    }
    public class Player : IPlayer
    {
        private readonly IUserDataContainer _userDataContainer;

        public Player(IUserDataContainer userDataContainer)
        {
            _userDataContainer = userDataContainer;
        }

        public void AddReward(RewardTypeId rewardType, int count)
        {
            switch(rewardType) 
            {
                case RewardTypeId.Money:
                    _userDataContainer.PlayerData.Money += count;
                    break;

                case RewardTypeId.Tickets:
                    _userDataContainer.PlayerData.Tickets += count;
                    break;
            }
        }


    }
}