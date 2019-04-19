using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeChatWeb.Models;
using WeChatLib;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WeChatWeb.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("authvalid")]
        public IActionResult AuthValid([FromBody] AuthModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            bool flag = WeChatMsgCrypt.VerifySignature(model.token, model.signature, model.timestamp, model.nonce);
            if (flag)
            {
                string res = @"<xml><ToUserName><![CDATA[oBtEu1ML2IqmbjIjDHw3nxQS2Acg]]></ToUserName>
                                <FromUserName><![CDATA[gh_227cce7d299c]]></FromUserName>
                                <CreateTime>1550501649</CreateTime>
                                <MsgType><![CDATA[text]]></MsgType>
                                <Content><![CDATA[hello world]]></Content>
                                </xml>";
                string res2 = @"<xml><ToUserName><![CDATA[oBtEu1ML2IqmbjIjDHw3nxQS2Acg]]></ToUserName>
                                <FromUserName><![CDATA[gh_227cce7d299c]]></FromUserName>
                                <CreateTime>1550501649</CreateTime>
                                <MsgType><![CDATA[image]]></MsgType>
                                 <Image>
                                 <MediaId><![CDATA[yb73NMR9jo00f5bMUilUR2X__D3gceEiu0HK_JaJcZJTlw5jnCVtiIm1lw9Qy8Rc]]></MediaId>
                                 </Image>
                                </xml>";
            }
            return Ok(model);
        }


    }
}
