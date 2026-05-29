using System;
using System.Collections.Generic;
using System.Text;

namespace CommandKit
{
    // 抽象命令接口
    public interface ICommand
    {
        void Execute();
        void Undo(); // 支持撤销操作
    }
}
