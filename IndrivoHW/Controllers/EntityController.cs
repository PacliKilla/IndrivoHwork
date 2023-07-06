using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

[ApiController]
[Route("api/entities")]
public class EntityController : ControllerBase
{
    [HttpGet]
    public ActionResult<List<Entity>> GetAllEntities()
    {
        var entities = JsonDataAccess.GetEntities();
        var classifiers = JsonDataAccess.GetClassifiers();

        foreach (var entity in entities)
        {
            entity.Classifier = classifiers.Find(c => c.Guid == entity.ClassifierGuid);
        }

        return Ok(entities);
    }

    [HttpGet("{guid}")]
    public ActionResult<Entity> GetEntity(Guid guid)
    {
        var entities = JsonDataAccess.GetEntities();
        var entity = entities.Find(e => e.Guid == guid);
        if (entity == null)
            return NotFound();

        var classifiers = JsonDataAccess.GetClassifiers();
        entity.Classifier = classifiers.Find(c => c.Guid == entity.ClassifierGuid);

        return Ok(entity);
    }

    [HttpPost]
    public ActionResult<Entity> CreateEntity(Entity entity)
    {
        var entities = JsonDataAccess.GetEntities();
        entities.Add(entity);
        JsonDataAccess.SaveEntities(entities);
        return Ok(entity);
    }

    [HttpPut("{guid}")]
    public ActionResult<Entity> UpdateEntity(Guid guid, Entity updatedEntity)
    {
        var entities = JsonDataAccess.GetEntities();
        var entityIndex = entities.FindIndex(e => e.Guid == guid);
        if (entityIndex == -1)
            return NotFound();

        updatedEntity.Guid = guid;
        entities[entityIndex] = updatedEntity;
        JsonDataAccess.SaveEntities(entities);
        return Ok(updatedEntity);
    }

    [HttpDelete("{guid}")]
    public IActionResult DeleteEntity(Guid guid)
    {
        var entities = JsonDataAccess.GetEntities();
        var entity = entities.Find(e => e.Guid == guid);
        if (entity == null)
            return NotFound();

        entities.Remove(entity);
        JsonDataAccess.SaveEntities(entities);
        return NoContent();
    }
}
