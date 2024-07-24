using fitness_gateway.Dto.Req;
using fitness_gateway.Dto.Res;
using fitness_gateway.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text;
using System.Text.Json;

namespace fitness_gateway.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<UserController> _logger;
        public UserController(HttpClient httpClient, ILogger<UserController> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] ReqUserDto userReq)
        {
            try
            {
                var apiUrl = "http://localhost:5001/api/user";
                var jsonContent = JsonSerializer.Serialize(userReq);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    var jsonRes = await response.Content.ReadAsStringAsync();
                    var data = JsonSerializer.Deserialize<ResDto<Model.User>>(jsonRes);
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

        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUser(int userId, [FromBody] ReqUserDto userReq)
        {
            try
            {
                var apiUrl = $"http://localhost:5001/api/user/{userId}";
                var jsonContent = JsonSerializer.Serialize(userReq);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    var jsonRes = await response.Content.ReadAsStringAsync();
                    var data = JsonSerializer.Deserialize<ResDto<Model.User>>(jsonRes);
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

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            try
            {
                var apiUrl = $"http://localhost:5001/api/user/{userId}";
                var response = await _httpClient.DeleteAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var jsonRes = await response.Content.ReadAsStringAsync();
                    var data = JsonSerializer.Deserialize<ResDto<Model.User>>(jsonRes);
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
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var apiUrl = "http://localhost:5001/api/user";
                var response = await _httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var jsonRes = await response.Content.ReadAsStringAsync();
                    var data = JsonSerializer.Deserialize<ResAllDto<Model.User>>(jsonRes);
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

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUser(int userId)
        {
            try
            {
                var apiUrl = $"http://localhost:5001/api/user/{userId}";
                var response = await _httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var jsonRes = await response.Content.ReadAsStringAsync();
                    var data = JsonSerializer.Deserialize<ResDto<Model.User>>(jsonRes);
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
