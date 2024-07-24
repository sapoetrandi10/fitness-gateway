using fitness_gateway.Dto.Req;
using fitness_gateway.Dto.Res;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;

namespace fitness_gateway.Controllers.UserWorkout
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserWorkoutController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<UserWorkoutController> _logger;
        public UserWorkoutController(HttpClient httpClient, ILogger<UserWorkoutController> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserWorkout([FromBody] ReqUserWorkoutDto userWorkoutReq)
        {
            try
            {
                var apiUrl = "http://localhost:5004/api/userWorkout";
                var jsonContent = JsonSerializer.Serialize(userWorkoutReq);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    var jsonRes = await response.Content.ReadAsStringAsync();
                    var data = JsonSerializer.Deserialize<ResDto<Model.UserWorkout>>(jsonRes);
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

        [HttpPut("{userWorkoutId}")]
        public async Task<IActionResult> UpdateUserWorkout(int userWorkoutId, [FromBody] ReqUserWorkoutDto userWorkoutReq)
        {
            try
            {
                var apiUrl = $"http://localhost:5004/api/userWorkout/{userWorkoutId}";
                var jsonContent = JsonSerializer.Serialize(userWorkoutReq);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    var jsonRes = await response.Content.ReadAsStringAsync();
                    var data = JsonSerializer.Deserialize<ResDto<Model.UserWorkout>>(jsonRes);
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

        [HttpDelete("{userWorkoutId}")]
        public async Task<IActionResult> DeleteUserWorkout(int userWorkoutId)
        {
            try
            {
                var apiUrl = $"http://localhost:5004/api/userWorkout/{userWorkoutId}";
                var response = await _httpClient.DeleteAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var jsonRes = await response.Content.ReadAsStringAsync();
                    var data = JsonSerializer.Deserialize<ResDto<Model.UserWorkout>>(jsonRes);
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
        public async Task<IActionResult> GetUserWorkouts()
        {
            try
            {
                var apiUrl = "http://localhost:5004/api/userWorkout";
                var response = await _httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var jsonRes = await response.Content.ReadAsStringAsync();
                    var data = JsonSerializer.Deserialize<ResAllDto<Model.UserWorkout>>(jsonRes);
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

        [HttpGet("{userWorkoutId}")]
        public async Task<IActionResult> GetUserWorkout(int userWorkoutId)
        {
            try
            {
                var apiUrl = $"http://localhost:5004/api/userWorkout/{userWorkoutId}";
                var response = await _httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var jsonRes = await response.Content.ReadAsStringAsync();
                    var data = JsonSerializer.Deserialize<ResDto<Model.UserWorkout>>(jsonRes);
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
