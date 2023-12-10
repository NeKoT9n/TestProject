using Assets.Scripts.Features.Rewards;
using UnityEngine;
using Zenject;
using UnityEngine.Purchasing;

namespace Assets.Scripts.Shop
{
    public class Purchaser : MonoBehaviour
    {
        private Player _player;

        [Inject]
        public void Construct(Player player)
        {
            _player = player;
        }

        public void OnComplited(Product product)
        {
            Debug.Log("Tut");
            switch (product.definition.id)
            {
                case "com.test.addcoins":
                    _player.AddReward(RewardTypeId.Money,50);
                    break;
            }
        }
    }
}