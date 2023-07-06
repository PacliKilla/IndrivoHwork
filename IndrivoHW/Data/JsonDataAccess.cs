using IndrivoHW.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

public static class JsonDataAccess
{
    private const string FilePath = "Data/data.json";

    public static List<Entity> GetEntities()
    {
        var json = File.ReadAllText(FilePath);
        var data = JsonSerializer.Deserialize<Data>(json);
        return data?.Entities ?? new List<Entity>();
    }

    public static List<Classifier> GetClassifiers()
    {
        var json = File.ReadAllText(FilePath);
        var data = JsonSerializer.Deserialize<Data>(json);
        return data?.Classifiers ?? new List<Classifier>();
    }

    public static void SaveEntities(List<Entity> entities)
    {
        var data = new Data { Entities = entities, Classifiers = GetClassifiers() };
        var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(FilePath, json);
    }

    public static void SaveClassifiers(List<Classifier> classifiers)
    {
        var data = new Data { Entities = GetEntities(), Classifiers = classifiers };
        var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(FilePath, json);
    }

    private class Data
    {
        public List<Entity> Entities { get; set; }
        public List<Classifier> Classifiers { get; set; }
    }
}
