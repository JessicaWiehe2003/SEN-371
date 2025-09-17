using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_4_CampusLearn.Controllers
{
    [Authorize]
    public class ChatPageController : Controller
    {
        [HttpGet("/ChatPage")]
        public IActionResult Index(int topicId) { ViewBag.TopicId = topicId; return View(); }
    }
}
