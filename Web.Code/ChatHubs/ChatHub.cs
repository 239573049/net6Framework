using Microsoft.AspNetCore.SignalR;
using Service.Dto;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Util;

namespace Web.Code.ChatHubs
{
    public class ChatHub : Hub
    {
        /// <summary>
        /// 依赖注入
        /// </summary>
        private readonly IRedis _redis;
        public ChatHub(
            IRedis redis
            )
        {
            _redis = redis;
        }
        /// <summary>
        /// 客户端连接时触发
        /// </summary>
        /// <returns></returns>
        /// <exception cref="BusinessLogicException"></exception>
        public override async Task OnConnectedAsync()
        {
            var token = Context.GetHttpContext().Request.Headers["Authorization"].ToString();
            if (string.IsNullOrEmpty(token)) throw new BusinessLogicException(401, "请先登录");
            var user = _redis.Get<UserDto>(token);
            if (user == null) throw new BusinessLogicException(401, "请先登录");
            await _redis.SAdd("service", Context.ConnectionId);//添加连接id到service redis集合
            await _redis.SetAsync(user.Id.ToString(), Context.ConnectionId);
        }
        /// <summary>
        /// 客户端端口连接时触发
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        /// <exception cref="BusinessLogicException"></exception>
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var token = Context.GetHttpContext().Request.Headers["Authorization"].ToString();
            if (string.IsNullOrEmpty(token)) throw new BusinessLogicException(401, "请先登录");
            var user = _redis.Get<UserDto>(token);
            if (user == null) throw new BusinessLogicException(401, "请先登录");
            await _redis.SRemAsync("service", Context.ConnectionId);//删除redis集合的连接id
            await _redis.DeleteAsync(user.Id.ToString());
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
