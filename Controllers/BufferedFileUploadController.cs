﻿//using bookshop.Interfaces;
//using Microsoft.AspNetCore.Mvc;

//namespace bookshop.Controllers
//{
//    public class BufferedFileUploadController : Controller
//    {
//        readonly IBufferedFileUploadService _bufferedFileUploadService;

//        public BufferedFileUploadController(IBufferedFileUploadService bufferedFileUploadService)
//        {
//            _bufferedFileUploadService = bufferedFileUploadService;
//        }

//        public IActionResult Index()
//        {
//            return View();
//        }

//        [HttpPost]
//        public async Task<ActionResult> Index(IFormFile file)
//        {
//            try
//            {
//                if (await _bufferedFileUploadService.UploadFile(file))
//                {
//                    ViewBag.Message = "File Upload Successful";
//                }
//                else
//                {
//                    ViewBag.Message = "File Upload Failed";
//                }
//            }
//            catch (Exception ex)
//            {
//                //Log ex
//                ViewBag.Message = "File Upload Failed";
//            }
//            return View();
//        }
//    }
//}
