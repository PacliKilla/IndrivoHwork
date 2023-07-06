using IndrivoHW.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

[ApiController]
[Route("api/classifiers")]
public class ClassifierController : ControllerBase
{
    [HttpGet]
    public ActionResult<List<Classifier>> GetAllClassifiers()
    {
        var classifiers = JsonDataAccess.GetClassifiers();
        return Ok(classifiers);
    }

    [HttpGet("{guid}")]
    public ActionResult<Classifier> GetClassifier(Guid guid)
    {
        var classifiers = JsonDataAccess.GetClassifiers();
        var classifier = classifiers.Find(c => c.Guid == guid);
        if (classifier == null)
            return NotFound();

        return Ok(classifier);
    }

    [HttpPost]
    public ActionResult<Classifier> CreateClassifier(Classifier classifier)
    {
        var classifiers = JsonDataAccess.GetClassifiers();
        classifiers.Add(classifier);
        JsonDataAccess.SaveClassifiers(classifiers);
        return Ok(classifier);
    }

    [HttpPut("{guid}")]
    public ActionResult<Classifier> UpdateClassifier(Guid guid, Classifier updatedClassifier)
    {
        var classifiers = JsonDataAccess.GetClassifiers();
        var classifierIndex = classifiers.FindIndex(c => c.Guid == guid);
        if (classifierIndex == -1)
            return NotFound();

        updatedClassifier.Guid = guid;
        classifiers[classifierIndex] = updatedClassifier;
        JsonDataAccess.SaveClassifiers(classifiers);
        return Ok(updatedClassifier);
    }

    [HttpDelete("{guid}")]
    public IActionResult DeleteClassifier(Guid guid)
    {
        var classifiers = JsonDataAccess.GetClassifiers();
        var classifier = classifiers.Find(c => c.Guid == guid);
        if (classifier == null)
            return NotFound();

        classifiers.Remove(classifier);
        JsonDataAccess.SaveClassifiers(classifiers);
        return NoContent();
    }
}
