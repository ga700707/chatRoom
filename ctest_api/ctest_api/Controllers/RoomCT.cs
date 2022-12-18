using ctest_service;
using ctest_model.Entities;
using ctest_service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using ctest_viewmodel;
using Microsoft.AspNetCore.Authorization;

namespace ctest_api.Controllers
{
	[Route("room/[action]")]
	[ApiController]
	//[Authorize]
	public class ChatRoomCT : ControllerBase
	{
		private readonly IChatRoomS _service;
		private readonly ILogger<ChatRoomCT> _logger;

		public ChatRoomCT(ILogger<ChatRoomCT> logger)
		{
			_logger = logger;
			_service = new ChatRoomS();
		}
	

		[HttpPost]
		public IActionResult GetAll([FromBody] ChatLog param)
		{
			var result = _service.GetAll();
			return Ok(result);
		}

        [HttpPost]
        public IActionResult Create([FromBody] ChatLog param)
        {
            _service.Create(param);
			return Ok("success") ;
        }

    }
}
