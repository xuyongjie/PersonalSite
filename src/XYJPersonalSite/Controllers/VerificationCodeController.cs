using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YOYO.DotnetCore;
using XYJPersonalSite.Data;

namespace XYJPersonalSite.Controllers
{
    public class VerificationCodeController : Controller
    {
        public IActionResult Code()
        {
            byte[] data = null;
            var captcha = new CaptchaImageCore(120, 38, 30);
            captcha.ImageOffset = 20;
            using (var stream = captcha.GetStream("tempcheckcodefile.bmp"))
            {
                data = stream.ToArray();
            }
            HttpContext.Session.Set(Constant.VERIFICATION_CODE_TAG, System.Text.Encoding.UTF8.GetBytes(captcha.Text));
            return File(data, "image/bmp");
        }
    }
}