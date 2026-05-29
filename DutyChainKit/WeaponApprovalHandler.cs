using System;
using System.Collections.Generic;
using System.Text;

namespace DutyChainKit
{
    public abstract class WeaponApprovalHandler
    {
        protected WeaponApprovalHandler nextHandler;

        // 设置下一个处理者
        public void SetNext(WeaponApprovalHandler handler)
        {
            nextHandler = handler;
        }

        // 抽象处理方法
        public abstract void HandleRequest(WeaponRequest request);
    }
}
