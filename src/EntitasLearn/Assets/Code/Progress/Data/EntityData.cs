using Newtonsoft.Json;
using System.Collections.Generic;


namespace Assets.Code.Progress.Data
{
    public class EntityData
    {
        [JsonProperty("es")] public List<EntitySnapshot> MetaEntitySnapshots;
    }
}
