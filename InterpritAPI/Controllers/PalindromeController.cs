using InterpritAPI.Class;
using InterpritAPI.Domain;
using Microsoft.AspNetCore.Mvc;

namespace InterpritAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PalindromeController : Controller
    {
        private const string RequestLogText = "Request: {0}";
        private const string ResponeLogText = "Response:\n {0}";
        private readonly ILogger<PalindromeController> _logger;
        private readonly IConfiguration _configuration;
        private int _defaultRemoveTextCount = 2;

        public PalindromeController(ILogger<PalindromeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet(Name = "CheckPalindrome")]
        public IActionResult Index(string text)
        {
            
            var palindrome = new Palindrome();

            _logger.LogInformation(RequestLogText, text);

            var helper = new PalindromeHelper();

            int.TryParse(_configuration["RemoveNumberOfCharsForPotentialPalindrome"], out _defaultRemoveTextCount);

            palindrome = helper.CheckPossiblePalindrome(text, _defaultRemoveTextCount);

            _logger.LogInformation(ResponeLogText, palindrome.ToString());

            return Ok(palindrome);
        }
    }
}
