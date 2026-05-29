using System;
using System.Collections.Generic;
using System.Text;

namespace CommandKit
{
    // 调用者：武器控制器
    public class WeaponController
    {
        private List<ICommand> commandHistory = new List<ICommand>();
        private int currentCommandIndex = -1;

        // 执行命令
        public void ExecuteCommand(ICommand command)
        {
            // 清除当前位置之后的命令历史（如果有的话）
            if (currentCommandIndex < commandHistory.Count - 1)
            {
                commandHistory.RemoveRange(currentCommandIndex + 1,
                    commandHistory.Count - currentCommandIndex - 1);
            }

            // 执行命令并添加到历史
            command.Execute();
            commandHistory.Add(command);
            currentCommandIndex++;
        }

        // 撤销上一个命令
        public void UndoLastCommand()
        {
            if (currentCommandIndex >= 0)
            {
                ICommand command = commandHistory[currentCommandIndex];
                command.Undo();
                currentCommandIndex--;
                Console.WriteLine("Command undone");
            }
            else
            {
                Console.WriteLine("No commands to undo");
            }
        }

        // 重做命令
        public void RedoCommand()
        {
            if (currentCommandIndex < commandHistory.Count - 1)
            {
                currentCommandIndex++;
                ICommand command = commandHistory[currentCommandIndex];
                command.Execute();
                Console.WriteLine("Command redone");
            }
            else
            {
                Console.WriteLine("No commands to redo");
            }
        }

        // 显示命令历史
        public void ShowHistory()
        {
            Console.WriteLine("\n=== Command History ===");
            for (int i = 0; i < commandHistory.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {commandHistory[i].GetType().Name}");
            }
        }
    }
}
