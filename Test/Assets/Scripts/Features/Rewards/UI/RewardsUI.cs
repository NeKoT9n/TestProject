using UnityEngine;
using Zenject;
using TMPro;
using UnityEngine.UI;
using System;


namespace Assets.Scripts.Features.Rewards.UI
{
    public class RewardsUI : MonoBehaviour, Scripts.UI.Windows.IInitializable, IDisposable
    {
        [SerializeField] private TextMeshProUGUI _dayText;
        [SerializeField] private TextMeshProUGUI _rewardCount;
        [SerializeField] private TextMeshProUGUI _timeToRewardText;
        [SerializeField] private Image _rewardImage;
        [SerializeField] private Button _collectButton;

        public Func<RewardModel> ButtonClicked;

        private RewardModel _currentReward;
        private DailyReward _dailyReward;

        [Inject]
        public void Construct(DailyReward dailyReward)
        {
            _dailyReward = dailyReward;
        }

        public void Initialize()
        {
            UpdateUI();
            _collectButton.onClick.AddListener(OnButtonClick);
            _dailyReward.RewardUpdated += UpdateUI;
        }

        private void OnButtonClick()
        {
            _dailyReward.CollectReward();
        }

        public void UpdateUI()
        {
            _currentReward = _dailyReward.GetCurrentReward();

            bool canGet = _dailyReward.CanGetReward;
            _collectButton.interactable = canGet;
            _dayText.text = "Day " + _currentReward.Day.ToString();
            _rewardCount.text = _currentReward.count.ToString();
            _rewardImage.sprite = _currentReward.Icon;
        }

        private string TimeFormater(int seconds)
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(seconds);
            string formattedTime = timeSpan.Hours + ":" + timeSpan.Minutes + ":" + timeSpan.Seconds;
            return formattedTime;
        }

        private void Update()
        {
            int timeToReward = (int)_dailyReward.TimeToReward;  
            if (timeToReward <= 0)
            {
                _timeToRewardText.text = TimeFormater(0);
                return;
            }
            _timeToRewardText.text = TimeFormater(timeToReward);
        }


        public void Dispose()
        {
            _collectButton.onClick.RemoveListener(OnButtonClick);
        }
    }
}