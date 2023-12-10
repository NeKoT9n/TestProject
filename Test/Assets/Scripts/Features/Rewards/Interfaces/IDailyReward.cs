using Assets.Scripts.Features.Rewards;
using Assets.Scripts.UI.Windows;

namespace Assets.Scripts.Features
{
    public interface ITickable
    {
        public void Tick();
    }

    public interface IDailyReward
    {
        public RewardModel CollectReward();
        public RewardModel GetCurrentReward();
    }
}