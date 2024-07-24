using fitness_gateway.Controllers.Progress;
using fitness_gateway.Dto.Req;
using fitness_gateway.Dto.Res;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;

namespace fitness_gateway.Controllers.Progress
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgressController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ProgressController> _logger;
        public ProgressController(HttpClient httpClient, ILogger<ProgressController> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProgress([FromBody] ReqProgressDto progressReq)
        {
            try
            {
                var apiUrl = "http://localhost:5004/api/progress";
                var jsonContent = JsonSerializer.Serialize(progressReq);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    var jsonRes = await response.Content.ReadAsStringAsync();
                    var data = JsonSerializer.Deserialize<ResDto<Model.Progress>>(jsonRes);
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

        [HttpPut("{progressId}")]
        public async Task<IActionResult> UpdateProgress(int progressId, [FromBody] ReqProgressDto progressReq)
        {
            try
            {
                var apiUrl = $"http://localhost:5004/api/progress/{progressId}";
                var jsonContent = JsonSerializer.Serialize(progressReq);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    var jsonRes = await response.Content.ReadAsStringAsync();
                    var data = JsonSerializer.Deserialize<ResDto<Model.Progress>>(jsonRes);
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

        [HttpDelete("{progressId}")]
        public async Task<IActionResult> DeleteProgress(int progressId)
        {
            try
            {
                var apiUrl = $"http://localhost:5004/api/progress/{progressId}";
                var response = await _httpClient.DeleteAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var jsonRes = await response.Content.ReadAsStringAsync();
                    var data = JsonSerializer.Deserialize<ResDto<Model.Progress>>(jsonRes);
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
        public async Task<IActionResult> GetProgresss()
        {
            try
            {
                var apiUrl = "http://localhost:5004/api/progress";
                var response = await _httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var jsonRes = await response.Content.ReadAsStringAsync();
                    var data = JsonSerializer.Deserialize<ResAllDto<Model.Progress>>(jsonRes);
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

        [HttpGet("{progressId}")]
        public async Task<IActionResult> GetProgress(int progressId)
        {
            try
            {
                var apiUrl = $"http://localhost:5004/api/progress/{progressId}";
                var response = await _httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var jsonRes = await response.Content.ReadAsStringAsync();
                    var data = JsonSerializer.Deserialize<ResDto<Model.Progress>>(jsonRes);
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
