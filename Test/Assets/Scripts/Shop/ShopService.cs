using Assets.Scripts.Data;
using Assets.Scripts.Features.Rewards;
using Assets.Scripts.UI.Windows;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Shop
{
    public class ShopService : MonoBehaviour, UI.Windows.IInitializable
    {

        [SerializeField] private TextMeshProUGUI _coinsCount;
        [SerializeField] private TextMeshProUGUI _ticketsCount;
        [SerializeField] private List<ShopItem> _items;
 

        private IPlayer _player;
        private IUserDataContainer _userDataContainer;

        [Inject]
        public void Construct(IPlayer player, IUserDataContainer userDataContainer)
        {
            _player = player;
            _userDataContainer = userDataContainer;
        }
        public void Initialize()
        {
            UpdateUI();
            foreach (ShopItem item in _items)
            {
                item.Clicked += TryBuy;
            }
        }

        private void UpdateUI()
        {
            _coinsCount.text = _userDataContainer.PlayerData.Money.ToString();
            _ticketsCount.text = _userDataContainer.PlayerData.Tickets.ToString();
        }

        private void TryBuy(RewardTypeId type, int price, int count)
        {
            if (_userDataContainer.PlayerData.Money < price)
            {
                return;
            }
            else
            {
                _userDataContainer.PlayerData.Money -= price;
                _player.AddReward(type, count);
                UpdateUI();
            }
        }
    }
}