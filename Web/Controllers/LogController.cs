﻿using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Service.Dto;
using Service.Services;

namespace Web.Controllers;

/// <summary>
/// 日志模块
/// </summary>
[Route("api/[controller]/[action]")]
[ApiController]
public class LogController : ControllerBase
{
    private readonly ILogService _logService;
    public LogController(
        ILogService logService
        )
    {
        _logService = logService;
    }
    /// <summary>
    /// 创建记录
    /// </summary>
    /// <param name="log"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ObjectId> CreateLog(LogDto log)
    {
        return await _logService.CreateLog(log);
    }
}