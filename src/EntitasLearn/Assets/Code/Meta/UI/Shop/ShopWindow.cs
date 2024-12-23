using Assets.Code.Meta.UI.GoldHolder.Service;
using Assets.Code.Meta.UI.Shop.Items;
using Assets.Code.Meta.UI.Shop.Service;
using Assets.Code.Meta.UI.Shop.UiFactory;
using Code.Gameplay.Windows;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;


namespace Code.Meta.UI.Shop
{
    internal sealed class ShopWindow : BaseWindow
    {
        public Transform ItemsLayout;
        public Button CloseButton;
        public GameObject NoItemsAvailable;

        private IWindowService _windowService;
        private IShopUiFactory _shopUiFactory;
        private StorageUIService _storage;
        private IShopUiService _shopUiService;

        private readonly List<ShopItem> _items = new();

        [Inject]
        private void Construct(
            IWindowService windowService,
            IShopUiFactory shopUiFactory,
            IShopUiService shopUiService,
            StorageUIService storage)
        {
            Id = WindowId.ShopWindow;
            _windowService = windowService;
            _shopUiFactory = shopUiFactory;
            _shopUiService = shopUiService;
            _storage = storage;
        }

        protected override void Initialize()
        {
            CloseButton.onClick.AddListener(Close);
        }

        protected override void SubscribeUpdates()
        {
            _shopUiService.ShopChanged += Refresh;
            _storage.CurrentGold.OnChange += UpdateBoostersState;

            Refresh();
            UpdateBoostersState(_storage.CurrentGold);
        }

        private void Refresh()
        {
            ClearConfigs();

            var availableItems = _shopUiService.GetAvailableShopItems();
            NoItemsAvailable.SetActive(availableItems.Count == 0);

            FillItems(availableItems);
        }

        private void UpdateBoostersState(float obj)
        {
            bool itemsCanBeBought = Math.Abs(_storage.GoldGainBoost - 0) <= float.Epsilon;

            foreach (var shopItem in _items)
            {
                shopItem.UpdateAvailability(itemsCanBeBought);
            }
        }


        private void ClearConfigs()
        {
            _items.ForEach(x => Destroy(x.gameObject));
            _items.Clear();
        }

        private void FillItems(List<ShopItemConfig> availableItems)
        {
            foreach (var item in availableItems)
            {
                _items.Add(_shopUiFactory.CreateShopItem(item, ItemsLayout));
            }
        }

        protected override void Cleanup()
        {
            base.Cleanup();
            CloseButton.onClick.RemoveListener(Close);
        }

        private void Close()
        {
            _windowService.Close(Id);
        }
    }
}