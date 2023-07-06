using IndrivoHW.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

public static class JsonDataAccess
{
    private const string EntitiesFilePath = "Data/entities.json";
    private const string ClassifiersFilePath = "Data/classifiers.json";

    public static List<Entity> GetEntities()
    {
        var json = File.ReadAllText(EntitiesFilePath);
        return JsonSerializer.Deserialize<List<Entity>>(json) ?? new List<Entity>();
    }

    public static List<Classifier> GetClassifiers()
    {
        var json = File.ReadAllText(ClassifiersFilePath);
        return JsonSerializer.Deserialize<List<Classifier>>(json) ?? new List<Classifier>();
    }

    public static void SaveEntities(List<Entity> entities)
    {
        var json = JsonSerializer.Serialize(entities, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(EntitiesFilePath, json);
    }

    public static void SaveClassifiers(List<Classifier> classifiers)
    {
        var json = JsonSerializer.Serialize(classifiers, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(ClassifiersFilePath, json);
    }
}
