using Microsoft.AspNetCore.Mvc;
using nbp_gold_value.Services;
using System;
using System.Web;


namespace nbp_gold_value.Controllers
{   
    [ApiController]
    [Route("[controller]")]
    public class NbpController : ControllerBase
    {
        private INbpService _nbpService;

        public NbpController(INbpService nbpService)
        {
            _nbpService = nbpService;
        }
        [HttpGet]
        public ActionResult<String> GetText()
        {
            return _nbpService.writeText();
        }
        
        [HttpGet]
        [Route("/gold")]
        public async Task<ActionResult<GoldValue>> GetGoldValueAsync()
        {
            return await _nbpService.ReturnGoldValueAsync();
        }

        [HttpGet]
        [Route("/all")]
        public ActionResult<List<GoldValue>> GetGoldValueList()
        {
            return _nbpService.ReturnDataFromDatabase();
        }
    }
}
