using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Code.ModelVM
{
    public class ModelStateResult
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public int StatusCode { get; set; }
        /// <summary>
        /// 错误信息
        /// </summary>
        public string? Message { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        public object? Data { get; set; }
    }
}
