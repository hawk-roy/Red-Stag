using System;
using System.Collections.Generic;
using System.Text;

namespace SingleBody
{
    public sealed class SimpleLogger
    {
        // 私有静态实例
        private static SimpleLogger _instance = null;

        // 线程安全锁
        private static readonly object _lock = new object();

        // 私有构造函数
        private SimpleLogger()
        {
            Console.WriteLine("Logger created!");
        }

        // 获取单例实例的属性
        public static SimpleLogger Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new SimpleLogger();
                        }
                    }
                }
                return _instance;
            }
        }

        // 简单的日志方法
        public void Log(string message)
        {
            Console.WriteLine($"[LOG] {DateTime.Now:HH:mm:ss} - {message}");
        }
    }
}
