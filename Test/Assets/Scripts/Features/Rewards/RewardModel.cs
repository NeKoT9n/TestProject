using System;
using UnityEngine;

namespace Assets.Scripts.Features.Rewards
{
    public enum RewardTypeId
    {
        Tickets,
        Money
    }

    [Serializable]
    public class RewardModel
    {
        public int Day;
        public RewardTypeId TypeId;
        public int count;
        public Sprite Icon;
    }
}