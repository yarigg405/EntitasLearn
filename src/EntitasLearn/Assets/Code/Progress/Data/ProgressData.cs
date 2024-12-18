using Assets.Code.Progress.Data;
using Newtonsoft.Json;
using System;


namespace Code.Progress.Data
{
    public class ProgressData
    {
        [JsonProperty("e")] public EntityData EntityData = new();
        [JsonProperty("at")] public DateTime LastSimulationTickTime;
    }
}