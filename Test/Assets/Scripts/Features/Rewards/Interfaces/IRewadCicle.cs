using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Features.Rewards
{
    public interface IRewadCicle
    {
        public RewardModel GetNextReward();
    }
}