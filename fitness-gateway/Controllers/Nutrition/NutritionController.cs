using fitness_gateway.Controllers.Nutrition;
using fitness_gateway.Dto.Req;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;
using fitness_gateway.Controllers.Nutrition;
using fitness_gateway.Dto.Res;

namespace fitness_gateway.Controllers.Nutrition
{
    [Route("api/[controller]")]
    [ApiController]
    public class NutritionController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<NutritionController> _logger;
        public NutritionController(HttpClient httpClient, ILogger<NutritionController> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNutrition([FromBody] ReqNutritionDto nutritionReq)
        {
            try
            {
                var apiUrl = "http://localhost:5003/api/nutrition";
                var jsonContent = JsonSerializer.Serialize(nutritionReq);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    var jsonRes = await response.Content.ReadAsStringAsync();
                    var data = JsonSerializer.Deserialize<ResDto<Model.Nutrition>>(jsonRes);
                    return Ok(new
                    {
                        status = data.status,
                        message = data.message,
                        data = data.data
                    });
                }

                _logger.LogError($"Failed to fetch data. Status code: {response.StatusCode}");
                return StatusCode((int)response.StatusCode, response.ReasonPhrase);
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to fetch data. Message: {e.Message}. InnerException: {e.InnerException.Message}");
                return BadRequest(new
                {
                    status = "Failed",
                    message = e.Message,
                    InnerException = e.InnerException.Message
                });
            }
        }

        [HttpPut("{nutritionId}")]
        public async Task<IActionResult> UpdateNutrition(int nutritionId, [FromBody] ReqNutritionDto nutritionReq)
        {
            try
            {
                var apiUrl = $"http://localhost:5003/api/nutrition/{nutritionId}";
                var jsonContent = JsonSerializer.Serialize(nutritionReq);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    var jsonRes = await response.Content.ReadAsStringAsync();
                    var data = JsonSerializer.Deserialize<ResDto<Model.Nutrition>>(jsonRes);
                    return Ok(new
                    {
                        status = data.status,
                        message = data.message,
                        data = data.data
                    });
                }

                _logger.LogError($"Failed to fetch data. Status code: {response.StatusCode}");
                return StatusCode((int)response.StatusCode, response.ReasonPhrase);
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to fetch data. Message: {e.Message}. InnerException: {e.InnerException.Message}");
                return BadRequest(new
                {
                    status = "Failed",
                    message = e.Message,
                    InnerException = e.InnerException.Message
                });
            }
        }

        [HttpDelete("{nutritionId}")]
        public async Task<IActionResult> DeleteNutrition(int nutritionId)
        {
            try
            {
                var apiUrl = $"http://localhost:5003/api/nutrition/{nutritionId}";
                var response = await _httpClient.DeleteAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var jsonRes = await response.Content.ReadAsStringAsync();
                    var data = JsonSerializer.Deserialize<ResDto<Model.Nutrition>>(jsonRes);
                    return Ok(new
                    {
                        status = data.status,
                        message = data.message,
                    });
                }

                _logger.LogError($"Failed to delete data. Status code: {response.StatusCode}");
                return StatusCode((int)response.StatusCode, response.ReasonPhrase);
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to fetch data. Message: {e.Message}. InnerException: {e.InnerException.Message}");
                return BadRequest(new
                {
                    status = "Failed",
                    message = e.Message,
                    InnerException = e.InnerException.Message

                });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetNutritions()
        {
            try
            {
                var apiUrl = "http://localhost:5003/api/nutrition";
                var response = await _httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var jsonRes = await response.Content.ReadAsStringAsync();
                    var data = JsonSerializer.Deserialize<ResAllDto<Model.Nutrition>>(jsonRes);
                    return Ok(new
                    {
                        status = data.status,
                        message = data.message,
                        data = data.data
                    });
                }

                _logger.LogError($"Failed to fetch data. Status code: {response.StatusCode}");
                return StatusCode((int)response.StatusCode, response.ReasonPhrase);
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to fetch data. Message: {e.Message}. InnerException: {e.InnerException.Message}");
                return BadRequest(new
                {
                    status = "Failed",
                    message = e.Message,
                    InnerException = e.InnerException.Message

                });
            }
        }

        [HttpGet("{nutritionId}")]
        public async Task<IActionResult> GetNutrition(int nutritionId)
        {
            try
            {
                var apiUrl = $"http://localhost:5003/api/nutrition/{nutritionId}";
                var response = await _httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var jsonRes = await response.Content.ReadAsStringAsync();
                    var data = JsonSerializer.Deserialize<ResDto<Model.Nutrition>>(jsonRes);
                    return Ok(new
                    {
                        status = data.status,
                        message = data.message,
                        data = data.data
                    });
                }

                _logger.LogError($"Failed to fetch data. Status code: {response.StatusCode}");
                return StatusCode((int)response.StatusCode, response.ReasonPhrase);
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to fetch data. Message: {e.Message}. InnerException: {e.InnerException.Message}");
                return BadRequest(new
                {
                    status = "Failed",
                    message = e.Message,
                    InnerException = e.InnerException.Message

                });
            }
        }
    }
}
