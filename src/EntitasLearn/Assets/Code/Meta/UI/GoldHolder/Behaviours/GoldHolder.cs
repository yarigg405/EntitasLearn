using Assets.Code.Meta.UI.GoldHolder.Service;
using System;
using TMPro;
using UnityEngine;
using Zenject;


namespace Assets.Code.Meta.UI.GoldHolder.Behaviours
{
    internal class GoldHolder : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI amountTmp;
        [SerializeField] private TextMeshProUGUI boostTmp;
        private StorageUIService _storageUIService;


        [Inject]
        private void Construct(StorageUIService storageUIService)
        {
            _storageUIService = storageUIService;
        }

        private void Start()
        {
            _storageUIService.CurrentGold.OnChange += UpdateGold;
            _storageUIService.GoldGainBoost.OnChange += UpdateBoost;

            UpdateGold(_storageUIService.CurrentGold);
            UpdateBoost(_storageUIService.GoldGainBoost);
        }

        private void OnDestroy()
        {
            _storageUIService.CurrentGold.OnChange -= UpdateGold;
            _storageUIService.GoldGainBoost.OnChange -= UpdateBoost;
        }


        private void UpdateBoost(float boost)
        {
            switch (boost)
            {
                case > 0:
                    {
                        boostTmp.gameObject.SetActive(true);
                        boostTmp.text = boost.ToString("+0%");
                    }
                    break;

                default:
                    {
                        boostTmp.gameObject.SetActive(false);
                    }
                    break;
            }
        }

        private void UpdateGold(float currentGold)
        {
            amountTmp.text = currentGold.ToString("0");
        }
    }
}
