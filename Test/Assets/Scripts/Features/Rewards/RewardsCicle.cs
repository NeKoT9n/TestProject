using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Features.Rewards
{
    public class RewardsCicle : MonoBehaviour, IRewadCicle
    {
        [SerializeField] private List<RewardModel> _rewards;

        private int _currentRewardIndex = 0;

        public RewardModel CurrentReward => _rewards[_currentRewardIndex];
        
        public void SetCurrentDay(int day)
        {
            _currentRewardIndex = day;
        }
        public RewardModel GetNextReward()
        {
            var result = _rewards[_currentRewardIndex++];

            if(_currentRewardIndex >= _rewards.Count)
            {
                _currentRewardIndex = 0;
            }

            return result;        
        }
    }
}