using UnityEngine;


namespace Assets.Code.Meta.Features.AfkGain.Configs
{
    [CreateAssetMenu(fileName = "AfkGainConfig", menuName = "ScriptableObjects/AfkGainConfig", order = 51)]
    public class AfkGainConfig : ScriptableObject
    {
        public float GoldPerSecond;
    }
}
