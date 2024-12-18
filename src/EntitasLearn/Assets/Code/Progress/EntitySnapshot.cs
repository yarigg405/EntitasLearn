using Newtonsoft.Json;
using System.Collections.Generic;


namespace Assets.Code.Progress
{
    public class EntitySnapshot
    {
        [JsonProperty("c")] public List<ISavedComponent> Components;
    }
}
