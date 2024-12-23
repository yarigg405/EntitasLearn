using Assets.Code.Meta.UI.GoldHolder.Service;
using Code.Common.Entity;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Yrr.Utils;
using Zenject;


namespace Assets.Code.Meta.UI.Shop.Items
{
    public class ShopItem : MonoBehaviour
    {
        public Image Icon;
        public TextMeshProUGUI Price;
        public TextMeshProUGUI Duration;
        public TextMeshProUGUI Boost;
        public Button BuyButton;
        public CanvasGroup CanvasGroup;

        private StorageUIService _storage;

        public ShopItemId Id;
        private bool _isAvailable;
        private int _price;

        [Inject]
        private void Construct(StorageUIService storage)
        {
            _storage = storage;
        }

        private void Start()
        {
            _storage.CurrentGold.OnChange += UpdatePrice;

            UpdatePrice(_storage.CurrentGold);
        }

        private void OnDestroy()
        {
            _storage.CurrentGold.OnChange -= UpdatePrice;

            BuyButton.onClick.RemoveListener(BuyItem);
        }

        private void UpdatePrice(float obj)
        {
            BuyButton.interactable = _price <= obj;
        }

        internal void Setup(ShopItemConfig config)
        {
            Id = config.ShopItemId;
            Icon.sprite = config.Icon;
            Price.text = config.Price.ToString() + "$";
            Duration.text = TimeSpan.FromSeconds(config.Duration).ToString("m'm 's's'");
            Boost.text = config.Boost.ToString("+0%");

            _price = config.Price;

            BuyButton.onClick.AddListener(BuyItem);
        }

        private void BuyItem()
        {
            CreateMetaEntity.Empty()
                .AddShopItemId(Id)
                .isBuyRequest = true;
        }

        internal void UpdateAvailability(bool value)
        {
            if (!CanvasGroup) return;

            _isAvailable = value;
            CanvasGroup.alpha = _isAvailable ? 1 : 0.7f;

            BuyButton.interactable = _isAvailable;
        }
    }
}
