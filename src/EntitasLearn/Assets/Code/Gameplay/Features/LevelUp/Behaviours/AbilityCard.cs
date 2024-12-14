using Assets.Code.Gameplay.Features.Abilities.Configs;
using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace Assets.Code.Gameplay.Features.LevelUp.Behaviours
{
    public class AbilityCard : MonoBehaviour
    {
        public AbilityId AbilityId;
        public Image Icon;
        public TextMeshProUGUI DescriptionTmp;
        public Button Button;
        public GameObject Stamp;

        private Action<AbilityId> _onSelected;

        internal void Setup(AbilityId abilityId, AbilityLevel level, Action<AbilityId> onSelected)
        {
            AbilityId = abilityId;
            Icon.sprite = level.Icon;
            DescriptionTmp.text = level.Description;

            _onSelected = onSelected;

            Button.onClick.AddListener(SelectCard);
        }

        private void OnDestroy()
        {
            Button.onClick.RemoveListener(SelectCard);
        }

        private void SelectCard()
        {
            StartCoroutine(StampAndReport());
        }

        private IEnumerator StampAndReport()
        {

            Stamp.SetActive(true);
            yield return new WaitForSeconds(1f);
            _onSelected?.Invoke(AbilityId);
        }
    }
}
