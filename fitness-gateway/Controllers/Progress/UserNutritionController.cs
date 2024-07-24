using fitness_gateway.Dto.Req;
using fitness_gateway.Dto.Res;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;

namespace fitness_gateway.Controllers.UserNutrition
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserNutritionController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<UserNutritionController> _logger;
        public UserNutritionController(HttpClient httpClient, ILogger<UserNutritionController> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserNutrition([FromBody] ReqUserNutritionDto userNutritionReq)
        {
            try
            {
                var apiUrl = "http://localhost:5004/api/userNutrition";
                var jsonContent = JsonSerializer.Serialize(userNutritionReq);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    var jsonRes = await response.Content.ReadAsStringAsync();
                    var data = JsonSerializer.Deserialize<ResDto<Model.UserNutrition>>(jsonRes);
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

        [HttpPut("{userNutritionId}")]
        public async Task<IActionResult> UpdateUserNutrition(int userNutritionId, [FromBody] ReqUserNutritionDto userNutritionReq)
        {
            try
            {
                var apiUrl = $"http://localhost:5004/api/userNutrition/{userNutritionId}";
                var jsonContent = JsonSerializer.Serialize(userNutritionReq);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    var jsonRes = await response.Content.ReadAsStringAsync();
                    var data = JsonSerializer.Deserialize<ResDto<Model.UserNutrition>>(jsonRes);
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

        [HttpDelete("{userNutritionId}")]
        public async Task<IActionResult> DeleteUserNutrition(int userNutritionId)
        {
            try
            {
                var apiUrl = $"http://localhost:5004/api/userNutrition/{userNutritionId}";
                var response = await _httpClient.DeleteAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var jsonRes = await response.Content.ReadAsStringAsync();
                    var data = JsonSerializer.Deserialize<ResDto<Model.UserNutrition>>(jsonRes);
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
        public async Task<IActionResult> GetUserNutritions()
        {
            try
            {
                var apiUrl = "http://localhost:5004/api/userNutrition";
                var response = await _httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var jsonRes = await response.Content.ReadAsStringAsync();
                    var data = JsonSerializer.Deserialize<ResAllDto<Model.UserNutrition>>(jsonRes);
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

        [HttpGet("{userNutritionId}")]
        public async Task<IActionResult> GetUserNutrition(int userNutritionId)
        {
            try
            {
                var apiUrl = $"http://localhost:5004/api/userNutrition/{userNutritionId}";
                var response = await _httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var jsonRes = await response.Content.ReadAsStringAsync();
                    var data = JsonSerializer.Deserialize<ResDto<Model.UserNutrition>>(jsonRes);
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
