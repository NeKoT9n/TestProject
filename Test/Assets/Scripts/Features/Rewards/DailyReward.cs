using Assets.Scripts.Data;
using Assets.Scripts.Features.Rewards;
using Assets.Scripts.Shop;
using System;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Features
{
    public class DailyReward : IDailyReward, UI.Windows.IInitializable, ITickable
    {

        private float _timeToReward;
        private bool _canGetReward;
        private RewardsCicle _rewardsCicle;
        private DateConverter _dateConverter;
        private IUserDataContainer _userDataContainer;
        private IPlayer _player;
        private const float SECONDS_IN_DAY = 86400;
        public float TimeToReward => _timeToReward;
        public bool CanGetReward => _canGetReward;

        public event Action RewardUpdated;

        [Inject]
        public DailyReward(IUserDataContainer userDataContainer, IPlayer player)
        {
            _userDataContainer = userDataContainer;
            _player = player;
            _dateConverter = new DateConverter(); 
        }

        public void Initialize()
        {
            RewardsData data = _userDataContainer.RewardsData;

            _rewardsCicle.SetCurrentDay(_userDataContainer.RewardsData.lastRewardDay);
            DateTime lastDate = _dateConverter.StringToDate(data.LastCollectedDate); 
            var timeSpent =  DateTime.Now - lastDate;

            if(timeSpent.TotalHours > 24f)
            {
                _canGetReward = true;
            }
            else
            {
                _canGetReward = false;
                _timeToReward = SECONDS_IN_DAY - (float)timeSpent.TotalSeconds;
            }
            
        }

        public void SetRewardsCile(RewardsCicle rewardsCicle) => _rewardsCicle = rewardsCicle;

        public void Tick()
        {

            if (_canGetReward == true)
                return;

            _timeToReward -= Time.deltaTime;

            if(_timeToReward <= 0f)
            {
                _canGetReward = true;
                RewardUpdated?.Invoke();
            }
        }

        

        public RewardModel CollectReward()
        {
            if(_canGetReward == false)
            {
                return null;
            }

            RewardModel result = _rewardsCicle.GetNextReward();

            _userDataContainer.RewardsData.LastCollectedDate = _dateConverter.DateToString(DateTime.Now);
            _userDataContainer.RewardsData.lastRewardDay = result.Day;

            _timeToReward = SECONDS_IN_DAY;
            _canGetReward = false;

            _player.AddReward(result.TypeId, result.count);
            RewardUpdated?.Invoke();

            return result;
        }

        public RewardModel GetCurrentReward()
        {
            return _rewardsCicle.CurrentReward;
        }
    }
}