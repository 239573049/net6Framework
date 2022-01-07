### 第一步配置连接字符串：
先更改配置文件 web项目下的appsettings.json
如果是sqlservice 更改sqlservice的数据库连接字符串改成自己的
还要安装redis直接使用必须安装redis配合使用项目 reids下载地址：https://github.com/tporadowski/redis/releases

### 第二步生成迁移日志：
配置完成以后在工具=》NuGet包管理器=》程序管理器控制台 打开程序管理器控制台：
Add-Migration t1 //生成迁移记录和默认数据
update-database //更新到数据库