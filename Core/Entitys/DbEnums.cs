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
}
