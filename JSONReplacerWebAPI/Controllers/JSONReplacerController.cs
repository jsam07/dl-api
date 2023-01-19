using JSONReplacer;
using System.Dynamic;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace JSONReplacerWebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JSONReplacerController : ControllerBase
{

    private readonly ILogger<JSONReplacerController> _logger;

    public JSONReplacerController(ILogger<JSONReplacerController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public string Get()
    {
        return "Welcome to JSONReplacer API v1.0";
    }


    [HttpPost]
    public IActionResult Post(dynamic payload)
    {
        try {
            string payloadStr = JsonSerializer.Serialize(payload);
            string payloadReplaced = JsonReplacer.Replace(payloadStr, "\"dog\"", "\"cat\"");
            dynamic response = JsonSerializer.Deserialize<ExpandoObject>(payloadReplaced);

            return Ok(response);
        } catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return Problem("Unable to replace payload");
        }
    }
}
