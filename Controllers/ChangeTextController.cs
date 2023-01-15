using FormatTextProject.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FormatTextProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChangeTextController : ControllerBase
    {   
        private readonly IChangeTextService _changeTextService;

        public ChangeTextController(IChangeTextService changeTextService)
        {
            _changeTextService = changeTextService;
        }

        [HttpGet("ParseToWhatsApp")]
        public string ParseToWhatsApp([FromForm] string text)
        {
            string retorno = _changeTextService.HtmlToWhatsApp(text);
            return retorno;
        }

        [HttpGet("ParseToHtml")]
        public string ParseToHtml([FromForm] string text)
        {
            string retorno = _changeTextService.WhatsAppToHtml(text);
            return retorno;
        }
    }
}
