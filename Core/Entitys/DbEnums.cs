namespace Core.Entitys
{
    public enum Status
    {
        /// <summary>
        /// 再用
        /// </summary>
        InUse,
        /// <summary>
        /// 禁用
        /// </summary>
        Forbidden,
        /// <summary>
        /// 冻结
        /// </summary>
        Freeze
    }
    /// <summary>
    /// 单权限(加权限枚举的时候按照从小到大去配置权限0的权限最大)
    /// </summary>
    public enum PowerEnum
    {
        /// <summary>
        /// 管理员
        /// </summary>
        Admin,
        /// <summary>
        /// 审核
        /// </summary>
        Audit,
        /// <summary>
        /// 用户
        /// </summary>
        User
    }
    /// <summary>
    /// 订单枚举
    /// </summary>
    public enum UserFormStatusEnum
    {
        /// <summary>
        /// 等待接单
        /// </summary>
        Await,
        /// <summary>
        /// 被接单
        /// </summary>
        BeTaken,
        /// <summary>
        /// 完成
        /// </summary>
        Accomplish,
        /// <summary>
        /// 失败
        /// </summary>
        GoUnder,
        /// <summary>
        /// 超时
        /// </summary>
        Timeout,
        /// <summary>
        /// 关闭
        /// </summary>
        Close,
        /// <summary>
        /// 申诉
        /// </summary>
        Appeal,
        /// <summary>
        /// 申述失败
        /// </summary>
        AppealFailed,
        /// <summary>
        /// 申述成功
        /// </summary>
        AppealSucceed,
    }
    public enum AppealEnum
    {
        /// <summary>
        /// 申述中
        /// </summary>
        InComplaint,
        /// <summary>
        /// 申述失败
        /// </summary>
        AppealFailed,
        /// <summary>
        /// 申述成功
        /// </summary>
        AppealSucceed,

    }
    /// <summary>
    /// 审核枚举
    /// </summary>
    public enum AuditEnum
    {
        /// <summary>
        /// 待审核
        /// </summary>
        ToAaudit,
        /// <summary>
        /// 未通过审核
        /// </summary>
        NotAudit,
        /// <summary>
        /// 通过
        /// </summary>
        Pass,
    }
    /// <summary>
    /// 冻结单据类型
    /// </summary>
    public enum FrozenTypeEnum
    {
        /// <summary>
        /// 管理员冻结
        /// </summary>
        Admin,
        /// <summary>
        /// 订单
        /// </summary>
        OrderForm,
    }
}
