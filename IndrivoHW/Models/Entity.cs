using IndrivoHW.Models;
using Newtonsoft.Json;

public class Entity
{
    public Guid Guid { get; set; }
    public string Title { get; set; }
    public Guid ClassifierGuid { get; set; }
    public string Description { get; set; }

    [JsonIgnore]
    public Classifier Classifier { get; set; }
}

