using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreTest.Models
{
    /// <summary>
    /// 类名称：Person
    /// 命名空间：CoreTest.Models
    /// 类功能：
    /// </summary>
    /// 创建者：libb
    /// 创建日期：2019/5/9 14:16
    /// 修改者：
    /// 修改时间：
    /// -----------------------------------------------------------
    [Table("Person")]
    public class Person
    {

        /// <summary>
        /// 用户ID
        /// </summary>
        /// 创建者：libb
        /// 创建日期：2019/5/9 14:19
        /// 修改者：
        /// 修改时间：
        /// -----------------------------------------------------------
        public Guid Id { get; set; }


        /// <summary>
        /// 用户名称
        /// </summary>
        /// 创建者：libb
        /// 创建日期：2019/5/9 14:19
        /// 修改者：
        /// 修改时间：
        /// -----------------------------------------------------------
        public string Name { get; set; }
    }
}
