using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using Util;
using Web.Code.ModelVM;

namespace Web.Configure
{
    /// <summary>
    /// 文件模块
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Description("文件模块")]
    public class FilesController : ControllerBase
    {
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="file"></param>
        /// <param name="type">0(文件)|1（图片）|2（视频）默认文件</param>
        /// <returns></returns>
        /// <exception cref="BusinessLogicException"></exception>
        [HttpPost]
        [Description("上传文件")]
        public async Task<IActionResult> UploadFiles(IFormFile file,sbyte type=0)
        {
            var max = Convert.ToInt64(AppSettings.App("File:max"));
            if (file.Length > max*1024*1024)throw new BusinessLogicException($"文件大于{max}MB无法上传");
            var path = AppSettings.App("File:path");
            if (type!= 0)
            {
                path += type == 1 ? "/images" : "/mp4";
            }
            if (!Directory.Exists("." + path))
            {
                Directory.CreateDirectory("." + path);
            }
            var bytes = new byte[file.OpenReadStream().Length];
            file.OpenReadStream().Read(bytes, 0, bytes.Length);
            file.OpenReadStream().Close();
            var names=file.FileName.Split(".");
            var name=await StringUtil.GetStringAsync(20);
            if(name.Length > 1)
            {
                name +="."+names[^1];
            }
            var files = System.IO.File.Create("." + path + "/" + name);
            files.Write(bytes);
            files.Close();
            return new OkObjectResult(path + "/" + name);
        }
        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        [HttpDelete]
        [Description("删除文件")]
        public IActionResult DeleteFile(string path)
        {
            if (!System.IO.File.Exists("." + path))
            {
                return new ModelStateResult("文件不存在");
            }
            System.IO.File.Delete("." + path);
            return new OkObjectResult("删除成功");
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        [HttpDelete]
        [Description("批量删除")]
        public IActionResult DeletesFile(List<string> path)
        {
            var notExistsFile = new List<string>();
            foreach (var file in path)
            {
                if (!System.IO.File.Exists("." + file))
                {
                    notExistsFile.Add("." + file);
                }
            }
            path= path.Where(a=>!notExistsFile.Contains(a)).ToList();
            path.ForEach(a => System.IO.File.Delete(a));
            if (notExistsFile.Count > 0) return new ModelStateResult($"以下文件不存在 {string.Join(',', notExistsFile)},其他文件已经删除");
            return new OkObjectResult("删除成功");
        }
        /// <summary>
        /// 获取所有文件名称
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Description("获取所有文件名称")]
        public PagingModelVM<List<string>> GetFileNames(string name,int pageNo=1,int pageSize=20)
        {
            var path = AppSettings.App("File:path");
            var data= Directory.GetFiles("."+path).Where(a=>string.IsNullOrEmpty(name)||a.ToLower().Contains(name.ToLower()))
                .Skip((pageNo - 1) * pageSize).Take(pageSize)
                    .ToList().Select(f => f.Contains('\\') ? f = f.Replace("\\", "/") : f).ToList();
            return new PagingModelVM<List<string>>(data, data.Count());
        }
    }
}
