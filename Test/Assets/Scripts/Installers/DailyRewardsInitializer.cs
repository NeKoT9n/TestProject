using Assets.Scripts.Features.Rewards;
using Assets.Scripts.Features;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Installers
{
    public class DailyRewardsInitializer : MonoInstaller
    {
        [SerializeField] private RewardsCicle _rewardsCicle;

        [Inject] private DailyReward _dailyReward;
        public override void InstallBindings()
        {
            _dailyReward.SetRewardsCile(_rewardsCicle);
            _dailyReward.Initialize();
        }

        private void Update()
        {
            _dailyReward.Tick();
        }
    }
}