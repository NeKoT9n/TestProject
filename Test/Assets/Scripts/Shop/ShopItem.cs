using Assets.Scripts.Features.Rewards;
using Assets.Scripts.UI.Windows;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Shop
{
    public class ShopItem : MonoBehaviour, IInitializable
    {
        [SerializeField] private Button _BuyButton;
        [SerializeField] private int _price;
        [SerializeField] private int _count;
        [SerializeField] private RewardTypeId _type;

        public event Action<RewardTypeId, int, int> Clicked;
        public void Initialize()
        {
            _BuyButton.onClick.AddListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            Clicked?.Invoke(_type,_price, _count);
        }
    }
}