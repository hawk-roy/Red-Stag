using AdapterKit;
using AdapterKit.Previous;
using AgentKit;
using BridgeKit;
using CommandKit;
using CompositeKit;
using DecoratorKit;
using DutyChainKit;
using FacadeKit;
using FlyWeightKit;
using GunBuilder;
using GunPrototype;
using InterpreterKit;
using IteratorKit;
using MediatorKit;
using MementoKit;
using ObserverKit;
using SingleBody;
using StrategyKit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TemplateMethodKit;
using VisitorKit;
using WeaponKit;
using Weapon = StateKit.Weapon;

namespace WeaponLib
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StartTemplateMethod();
        }

        private static void StartTemplateMethod()
        {
            Console.WriteLine("=== Template Method Pattern Demo ===\n");

            WeaponTraining rifle = new RifleTraining();
            WeaponTraining sniper = new SniperTraining();

            Console.WriteLine("---- Rifle Training ----");
            rifle.Run();

            Console.WriteLine("---- Sniper Training ----");
            sniper.Run();

            Console.ReadKey();
        }

        private static void StartVisitor()
        {
            Console.WriteLine("=== Visitor Pattern Demo ===\n");

            // 一组元素（对象结构），这里用List演示即可
            List<IWeaponElement> weapons = new List<IWeaponElement>
            {
                new VisitorKit.AK47(),
                new VisitorKit.AWM(),
                new VisitorKit.P90(),
                new M1911()
            };

            // 访问者1：显示信息
            DisplayVisitor display = new DisplayVisitor();
            foreach (IWeaponElement w in weapons)
            {
                w.Accept(display);
            }

            Console.WriteLine();

            // 访问者2：统计价格
            PriceVisitor price = new PriceVisitor();
            foreach (IWeaponElement w in weapons)
            {
                w.Accept(price);
            }

            Console.WriteLine($"Total Price = ${price.TotalPrice}");

            Console.ReadKey();
        }

        private static void StartStrategy()
        {
            Console.WriteLine("=== Strategy Pattern Demo ===\n");

            var weapon = new StrategyKit.Weapon("AK-47", new SingleShotStrategy());
            weapon.Fire();

            Console.WriteLine();

            weapon.ChangeStrategy(new BurstShotStrategy());
            weapon.Fire();

            Console.ReadKey();
        }


        private static void StartState()
        {
            Console.WriteLine("=== State Pattern Demo ===\n");

            var ak47 = new Weapon("AK-47");

            ak47.ShowState();
            ak47.Fire();   // 空弹：打不响
            ak47.Load();   // 装弹：切到 Loaded 
            ak47.Fire();   // -1
            ak47.Fire();   // -1
            ak47.Fire();   // 归零后切回 Empty
            ak47.Fire();   // 空弹：打不响

            Console.ReadKey();
        }

        #region 观察者模式

        /// <summary>
        /// 观察者模式示例，展示如何使用观察者模式监控武器状态变化
        /// </summary>
        private static void StartObserver()
        {
            Console.WriteLine("=== Observer Pattern Demo ===\n");

            // 创建武器（主题）
            ObserverKit.Weapon ak47 = new ObserverKit.Weapon("AK-47");

            // 创建观察者
            ObserverKit.Commander commander = new ObserverKit.Commander("Alpha");
            ObserverKit.Monitor monitor = new ObserverKit.Monitor("Weapon Monitor System");
            Supply supply = new Supply("Supply Department");

            Console.WriteLine("=== Attaching Observers ===");
            // 添加观察者
            ak47.Attach(commander);
            ak47.Attach(monitor);
            ak47.Attach(supply);
            Console.WriteLine();

            Console.WriteLine("=== Weapon Operations ===");
            // 执行武器操作，观察者会收到通知
            ak47.Load();
            Console.WriteLine();

            ak47.Fire();
            Console.WriteLine();

            ak47.Fire();
            Console.WriteLine();

            ak47.Fire();
            Console.WriteLine();

            // 移除一个观察者
            Console.WriteLine("=== Removing Observer ===");
            ak47.Detach(commander);
            Console.WriteLine();

            // 继续操作
            ak47.Reload();
            Console.WriteLine();

            ak47.Fire();

            Console.ReadKey();
        }

        #endregion


        #region 备忘录模式

        /// <summary>
        /// 备忘录模式示例，展示如何保存和恢复武器状态
        /// </summary>
        private static void StartMemento()
        {
            Console.WriteLine("=== Memento Pattern Demo ===\n");

            // 创建武器和管理者
            MementoKit.Weapon ak47 = new MementoKit.Weapon("AK-47");
            WeaponManager caretaker = new WeaponManager();

            Console.WriteLine("=== Initial State ===");
            ak47.ShowStatus();

            // 保存初始状态
            caretaker.SaveMemento(ak47.CreateMemento());
            Console.WriteLine();

            // 修改武器状态
            Console.WriteLine("=== Modifying Weapon ===");
            ak47.Load();
            ak47.SafetyOff();
            ak47.ShowStatus();

            // 保存修改后状态
            caretaker.SaveMemento(ak47.CreateMemento());
            Console.WriteLine();

            // 继续修改
            Console.WriteLine("=== More Modifications ===");
            ak47.Fire();
            ak47.Fire();
            ak47.ShowStatus();

            // 保存当前状态
            caretaker.SaveMemento(ak47.CreateMemento());
            Console.WriteLine();

            // 显示所有保存的状态
            caretaker.ShowAllMementos();

            // 恢复到之前的状态
            Console.WriteLine("\n=== Restoring States ===");

            Console.WriteLine("Restoring to state 1 (initial):");
            ak47.RestoreFromMemento(caretaker.GetMemento(0));
            ak47.ShowStatus();
            Console.WriteLine();

            Console.WriteLine("Restoring to state 2 (loaded):");
            ak47.RestoreFromMemento(caretaker.GetMemento(1));
            ak47.ShowStatus();
            Console.WriteLine();

            Console.WriteLine("Restoring to state 3 (after firing):");
            ak47.RestoreFromMemento(caretaker.GetMemento(2));
            ak47.ShowStatus();

            Console.ReadKey();
        }

        #endregion


        #region 中介者模式

        /// <summary>
        /// 中介者模式示例，展示如何使用中介者模式实现队伍成员间的通信
        /// </summary>
        private static void StartMediator()
        {
            Console.WriteLine("=== Mediator Pattern Demo ===\n");

            // 创建中介者
            TeamChatMediator chatMediator = new TeamChatMediator();

            // 创建队伍成员
            MediatorKit.Commander commander = new MediatorKit.Commander(chatMediator, "Alpha");
            Soldier soldier1 = new Soldier(chatMediator, "Bravo");
            Soldier soldier2 = new Soldier(chatMediator, "Charlie");
            Soldier soldier3 = new Soldier(chatMediator, "Delta");

            // 将成员加入队伍
            chatMediator.AddMember(commander);
            chatMediator.AddMember(soldier1);
            chatMediator.AddMember(soldier2);
            chatMediator.AddMember(soldier3);

            Console.WriteLine("\n=== Team Communication ===");

            // 指挥官发送指令
            commander.SendMessage("Move to position A");
            Console.WriteLine();

            // 士兵汇报情况
            soldier1.SendMessage("Position A secured");
            Console.WriteLine();

            soldier2.SendMessage("Enemy spotted at 12 o'clock");
            Console.WriteLine();

            // 指挥官发送新指令
            commander.SendMessage("Engage the enemy");
            Console.WriteLine();

            soldier3.SendMessage("Roger that, engaging");

            Console.ReadKey();
        }

        #endregion


        #region 迭代器模式

        /// <summary>
        /// 迭代器模式示例，展示如何使用迭代器模式遍历武器集合
        /// </summary>
        private static void StartIterator()
        {
            Console.WriteLine("=== Iterator Pattern Demo ===\n");

            // 创建武器集合
            WeaponArsenal arsenal = new WeaponArsenal();

            // 添加武器
            arsenal.AddWeapon("AK-47");
            arsenal.AddWeapon("M4A1");
            arsenal.AddWeapon("AWM");
            arsenal.AddWeapon("Glock-17");

            Console.WriteLine($"\nTotal weapons: {arsenal.Count()}");

            // 使用迭代器遍历
            Console.WriteLine("\n=== Using Iterator ===");
            IIterator<string> iterator = arsenal.CreateIterator();

            while (iterator.HasNext())
            {
                string weapon = iterator.Next();
                Console.WriteLine($"Weapon: {weapon}");
            }

            // 重置迭代器并再次遍历
            Console.WriteLine("\n=== Reset and Iterate Again ===");
            iterator.Reset();

            int count = 1;
            while (iterator.HasNext())
            {
                string weapon = iterator.Next();
                Console.WriteLine($"{count}. {weapon}");
                count++;
            }

            Console.ReadKey();
        }

        #endregion

        #region 解释器模式

        /// <summary>
        /// 解释器模式示例，展示如何使用解释器模式创建一个简单的武器命令语言
        /// </summary>
        private static void StartInterpreter()
        {
            Console.WriteLine("=== Interpreter Pattern Demo ===\n");

            // 创建解释器
            WeaponCommandInterpreter interpreter = new WeaponCommandInterpreter();
            interpreter.SetWeaponName("AK-47");

            Console.WriteLine("=== Simple Commands ===");

            // 执行简单命令
            interpreter.InterpretCommand("status");
            interpreter.InterpretCommand("load");
            interpreter.InterpretCommand("safety_off");
            interpreter.InterpretCommand("fire");
            interpreter.InterpretCommand("fire");
            interpreter.InterpretCommand("status");

            Console.WriteLine("\n=== Complex Expressions ===");

            // 创建复杂表达式：顺序执行
            SequenceExpression sequence = new SequenceExpression();
            sequence.AddExpression(new LoadExpression());
            sequence.AddExpression(new SafetyOffExpression());
            sequence.AddExpression(new FireExpression());
            sequence.AddExpression(new StatusExpression());

            Console.WriteLine("Executing sequence expression:");
            interpreter.InterpretExpression(sequence);

            Console.WriteLine("\n=== Conditional Expressions ===");

            // 创建条件表达式
            ConditionalExpression conditional1 = new ConditionalExpression("loaded",
                new FireExpression(),
                new LoadExpression());

            Console.WriteLine("Conditional: If loaded then fire, else load");
            interpreter.InterpretExpression(conditional1);

            Console.WriteLine("\n=== Repeat Expressions ===");

            // 创建重复表达式
            RepeatExpression repeat = new RepeatExpression(new FireExpression(), 3);
            interpreter.InterpretExpression(repeat);

            Console.WriteLine("\n=== Nested Complex Expression ===");

            // 创建嵌套复杂表达式
            SequenceExpression nestedSequence = new SequenceExpression();
            nestedSequence.AddExpression(new LoadExpression());
            nestedSequence.AddExpression(new SafetyOffExpression());

            ConditionalExpression nestedConditional = new ConditionalExpression("hasAmmo",
                new RepeatExpression(new FireExpression(), 2),
                new LoadExpression());

            nestedSequence.AddExpression(nestedConditional);
            nestedSequence.AddExpression(new StatusExpression());

            Console.WriteLine("Executing nested complex expression:");
            interpreter.InterpretExpression(nestedSequence);

            Console.WriteLine("\n=== Interpreter Pattern Benefits ===");
            Console.WriteLine("✓ Easy to define and extend grammar");
            Console.WriteLine("✓ Can build complex expressions from simple ones");
            Console.WriteLine("✓ Supports recursive composition");
            Console.WriteLine("✓ Separates grammar from interpretation logic");

            Console.ReadKey();
        }

        #endregion

        #region 命令模式

        /// <summary>
        /// 命令模式示例，展示如何使用命令模式将请求封装为对象，支持撤销和重做操作
        /// </summary>
        private static void StartCommand()
        {
            Console.WriteLine("=== Command Pattern Demo ===\n");

            // 创建接收者（武器）
            CommandKit.Weapon ak47 = new CommandKit.Weapon("AK-47");

            // 创建调用者（武器控制器）
            WeaponController controller = new WeaponController();

            // 创建具体命令对象
            LoadCommand loadCommand = new LoadCommand(ak47);
            SafetyOffCommand safetyOffCommand = new SafetyOffCommand(ak47);
            FireCommand fireCommand = new FireCommand(ak47);
            SafetyOnCommand safetyOnCommand = new SafetyOnCommand(ak47);
            UnloadCommand unloadCommand = new UnloadCommand(ak47);

            Console.WriteLine("Initial weapon status:");
            ak47.ShowStatus();
            Console.WriteLine();

            // 执行一系列命令
            Console.WriteLine("=== Executing Commands ===");
            controller.ExecuteCommand(loadCommand);      // 装弹
            ak47.ShowStatus();


            controller.ExecuteCommand(safetyOffCommand); // 关闭保险
            ak47.ShowStatus();

            controller.ExecuteCommand(fireCommand);      // 射击
            ak47.ShowStatus();

            controller.ExecuteCommand(fireCommand);      // 再次射击
            ak47.ShowStatus();

            controller.ExecuteCommand(safetyOnCommand);  // 开启保险
            ak47.ShowStatus();

            //// 显示命令历史
            controller.ShowHistory();

            Console.WriteLine("\n=== Testing Undo Operations ===");

            //// 撤销操作
            controller.UndoLastCommand(); // 撤销保险开启
            ak47.ShowStatus();

            controller.UndoLastCommand(); // 撤销射击
            ak47.ShowStatus();

            controller.UndoLastCommand(); // 撤销射击
            ak47.ShowStatus();

            Console.WriteLine("\n=== Testing Redo Operations ===");

            // 重做操作
            controller.RedoCommand();     // 重做射击
            ak47.ShowStatus();

            controller.RedoCommand();     // 重做射击
            ak47.ShowStatus();

            // 显示最终命令历史
            controller.ShowHistory();

        }

        #endregion


        #region 代理模式

        private static void StartAgent()
        {
            var weapon = new WeaponProxy();

            weapon.Fire("Alice");   // 有权限
            weapon.Fire("Charlie"); // 无权限
            weapon.Fire("Bob");     // 有权限

        }

        #endregion

        #region 责任链模式

        /// <summary>
        /// 责任链模式示例，展示如何使用责任链模式处理武器申请审批流程
        /// </summary>
        private static void StartChainOfResponsibility()
        {
            // 创建处理者链
            WeaponApprovalHandler securityOfficer = new SecurityOfficer();   // 安全官员，处理危险等级1-3的申请
            WeaponApprovalHandler weaponSpecialist = new WeaponSpecialist();  // 武器专家，处理危险等级4-6的申请
            WeaponApprovalHandler commander = new DutyChainKit.Commander();  // 指挥官，处理危险等级7-8的申请
            WeaponApprovalHandler generalManager = new GeneralManager();  // 总司令，处理危险等级9-10的申请

            // 构建责任链：安全官员 -> 武器专家 -> 指挥官 -> 总司令
            securityOfficer.SetNext(weaponSpecialist);
            weaponSpecialist.SetNext(commander);
            commander.SetNext(generalManager);

            // 创建不同的武器申请
            WeaponRequest[] requests = {
                new WeaponRequest("Alice", "Pistol", 2, "Personal Protection"),
                new WeaponRequest("Bob", "Rifle", 5, "Training Exercise"),
                new WeaponRequest("Charlie", "Sniper Rifle", 7, "Special Mission"),
                new WeaponRequest("David", "Rocket Launcher", 9, "Emergency Defense"),
                new WeaponRequest("Eve", "Nuclear Weapon", 15, "Invalid Request")
            };

            // 处理所有申请
            for (int i = 0; i < requests.Length; i++)
            {
                Console.WriteLine($"=== Processing Request {i + 1} ===");
                Console.WriteLine($"Applicant: {requests[i].ApplicantName}");
                Console.WriteLine($"Weapon: {requests[i].WeaponType}");
                Console.WriteLine($"Danger Level: {requests[i].DangerLevel}");
                Console.WriteLine();

                // 从链的第一个处理者开始处理
                securityOfficer.HandleRequest(requests[i]);
                Console.WriteLine();
            }

        }

        #endregion

        #region 享元模式

        /// <summary>
        /// 享元模式示例，展示如何使用享元模式创建一个简单的武器对象池，以减少内存使用和提高性能。
        /// </summary>
        private static void StartFlyWeight()
        {
            // 创建多个士兵，武器类型有限
            FlyWeightKit.WeaponKit weaponKit = new FlyWeightKit.WeaponKit();

            var soldier1 = weaponKit.GetWeapon("ak47");
            var soldier2 = weaponKit.GetWeapon("m4");
            var soldier3 = weaponKit.GetWeapon("ak47"); // 复用

            soldier1.DisplayInfo("Alice");
            soldier2.DisplayInfo("Bob");
            soldier3.DisplayInfo("Charlie");

            Console.WriteLine($"Total weapon types created: {weaponKit.GetPoolCount()}"); // 输出2

        }


        #endregion

        #region 门面模式


        /// <summary>
        /// 门面模式示例，展示如何使用门面模式为一个复杂的子系统提供一个统一的接口，从而使得子系统更易使用。
        /// </summary>
        private static void StartFacade()
        {
            RobotCentre robotCentre = new RobotCentre();
            robotCentre.StartRobot();
           
            robotCentre.StopRobot();

        }




        #endregion

        #region 修饰器模式

        /// <summary>
        /// 修饰器模式示例，展示如何使用修饰器模式动态地为一个对象添加一些额外的职责，就增加功能来说，装饰器模式比生成子类更为灵活。
        /// </summary>
        private static void StartDecorator()
        {
            DecoratorKit.IWeapon basicRifle = new BasicRifle();
            DecoratorKit.IWeapon pistol = new DecoratorKit.Pistol();
            ShowThenFireInfo(basicRifle);
            ShowThenFireInfo(pistol);
            
            WeaponDecorator scopeDecoratedRifle = new ScopeDecorator(basicRifle);
            ShowThenFireInfo(scopeDecoratedRifle);

            WeaponDecorator silencerDecorRifle = new SilencerDecorator(scopeDecoratedRifle);
            ShowThenFireInfo(silencerDecorRifle);

            WeaponDecorator extendedMagDecorRifle = new ExtendedMagDecorator(silencerDecorRifle);
            ShowThenFireInfo(extendedMagDecorRifle);

        }

        private static void  ShowThenFireInfo(DecoratorKit.IWeapon weapon)
        {
            Console.WriteLine($"Weapon: {weapon.Name}, Damage: {weapon.Damage}, Weight: {weapon.Weight}kg, Price: ${weapon.Price}");
            weapon.Fire();
            Console.WriteLine();
        }


        #endregion

        /// <summary>
        /// 建造者模式示例
        /// </summary>
        private static void StartBuildMode()
        {
            RifleBuilder rifleBuilder = new M4_Builder();
            rifleBuilder.BuildRifleName("m4_16")
                .BuildCheekRest("550 cheek rest")
                .BuildExtendedMagazine("extended magazine")
                .BuildSilencer("x6 silencer");

            GunBuilder.AssaultRifle rifle = rifleBuilder.GetRifle();
            rifle.DisplayInfo();

        }


        /// <summary>
        /// 合成模式示例，展示如何使用合成模式创建一个简单的武器配件系统，其中配件可以包含其他配件，从而形成一个树形结构。
        /// </summary>
        private static void StartComposite()
        {
            IWeaponComponent ak47 = new CompositeKit.Weapon("AK-47", "Rifle", 3, 2700);
            IWeaponComponent awm = new CompositeKit.Weapon("AWM", "Sniper Rifle", 6, 5000);
            IWeaponComponent p90 = new CompositeKit.Weapon("P90", "SMG", 2, 3500);
            IWeaponComponent m1911 = new CompositeKit.Weapon("M1911", "Pistol", 1, 1500);
            IWeaponComponent c4 = new CompositeKit.Weapon("C4", "Explosive", 5, 4000);

            WeaponPack soldierPack = new WeaponPack("Soldier Base Pack");
            WeaponPack sniperPack = new WeaponPack("Sniper Pack");
            WeaponPack explosivePack = new WeaponPack("Explosive Pack");


            soldierPack.AddComponent(ak47);
            soldierPack.AddComponent(m1911);
            

            sniperPack.AddComponent(awm);
            sniperPack.AddComponent(m1911);
            
            explosivePack.AddComponent(c4);
            explosivePack.AddComponent(m1911);
            explosivePack.AddComponent(p90);

            Console.WriteLine("=== Composite Pattern Demo ===");


            soldierPack.ShowInfo();
            Console.WriteLine();

            sniperPack.ShowInfo();
            Console.WriteLine();

            explosivePack.ShowInfo();
            Console.WriteLine();

            List<IWeaponComponent> allPacks = new List<IWeaponComponent> { ak47, soldierPack, sniperPack, explosivePack };
            Console.WriteLine("Treating all components uniformly:");
            foreach (var pack in allPacks)
            {
                Console.WriteLine($"- {pack.Name}: Weight={pack.GetWeight()}kg, Price=${pack.GetPrice()}");
            }



        }

        /// <summary>
        /// 桥接模式示例，展示如何使用桥接模式将一个类的接口与其实现分离，使它们可以独立地变化。
        /// </summary>
        private static void StartBridge() 
        {
            IShootingMode singleMode = new SingleShotMode();
            IShootingMode brustMode = new BrustMode();
            IShootingMode fullAutoMode = new FullAutoMode();    

            BridgeKit.Weapon ak47 = new Rifle("AK-47", fullAutoMode);
            BridgeKit.Weapon m1911 = new BridgeKit.Pistol("M1911", singleMode);

            Console.WriteLine("=== Bridge Pattern Demo ===");
            ak47.DisplayWeaponInfo();
            ak47.Fire();

            m1911.DisplayWeaponInfo();
            m1911.Fire();

            Console.WriteLine("\nChanging AK-47 shooting mode to Brust Mode...");
            ak47.ChangeShootingMode(brustMode);
            ak47.DisplayWeaponInfo();
            ak47.Fire();

            Console.WriteLine("\nChanging M1911 shooting mode to Full Auto Mode...");
            m1911.ChangeShootingMode(fullAutoMode);
            m1911.DisplayWeaponInfo();
            m1911.Fire();
        }


        /// <summary>
        /// 启动单例模式示例，展示如何使用单例模式创建一个简单的日志记录器，并验证其唯一性。
        /// </summary>
        private static void StartSingleton()
        {
            Console.WriteLine("=== Simple Singleton Demo ===");

            // 第一次获取实例
            SimpleLogger logger1 = SimpleLogger.Instance;
            logger1.Log("First message");

            // 第二次获取实例
            SimpleLogger logger2 = SimpleLogger.Instance;
            logger2.Log("Second message"); 


            // 验证是否为同一个对象
            bool isSameObject = ReferenceEquals(logger1, logger2);
            Console.WriteLine($"Same object: {isSameObject}");
            Console.WriteLine($"Logger1 hash: {logger1.GetHashCode()}");
            Console.WriteLine($"Logger2 hash: {logger2.GetHashCode()}");
        }


        /// <summary>
        /// 启动原型模式示例，展示如何使用原型模式创建和修改武器配置。
        /// </summary>
        private static void StartPrototype()
        {
            WeaponPrototypeMgr prototypeManager = new WeaponPrototypeMgr();

            GunPrototype.AssaultRifle m4Prototype = new GunPrototype.AssaultRifle
            {
                RifleName = "M4A1-Standard",
                Silencer = "Standard Suppressor",
                ExtendedMagazine = "30-Round Magazine",
                VerticalGrip = "Vertical Foregrip",
                Sight = "Red Dot Sight",
                CheekRest = "Adjustable Stock",
                Ammunition = "5.56x45mm NATO"
            };

            SniperRifle awmPrototype = new SniperRifle
            {
                RifleName = "AWM-Sniper",
                Scope = "8x Scope",
                Bipod = "Folding Bipod",
                Silencer = "Sniper Suppressor",
                Ammunition = "7.62x51mm NATO"
            };

            prototypeManager.RegisterPrototype("M4A1", m4Prototype);
            prototypeManager.RegisterPrototype("AWM", awmPrototype);

            Console.WriteLine("Available Prototypes:");
            foreach (string key in prototypeManager.GetRegisteredKeys())
            {
                Console.WriteLine($"- {key}");
            }

            Console.WriteLine();


            IWeaponPrototype clonedM4 = prototypeManager.CreateWeapon("M4A1");
            GunPrototype.AssaultRifle modifiedM4 = (GunPrototype.AssaultRifle)clonedM4;
            modifiedM4.RifleName = "M4A1-Custom";
            modifiedM4.Sight = "ACOG 4x Scope";
            modifiedM4.Silencer = "Advanced Suppressor";
            modifiedM4.DisplayInfo();


            Console.WriteLine();

            IWeaponPrototype clonedAWM = prototypeManager.CreateWeapon("AWM");
            SniperRifle modifiedAWM = (SniperRifle)clonedAWM;
            modifiedAWM.RifleName = "AWM-Modified";
            modifiedAWM.Scope = "15x Scope";
            modifiedAWM.Bipod = "Heavy-Duty Bipod";
            modifiedAWM.Silencer = "Enhanced Suppressor";
            modifiedAWM.Ammunition = "Custom 7.62mm Rounds";

            modifiedAWM.DisplayInfo();

        }

        /// <summary>
        /// 工厂方法模式示例，展示如何使用工厂方法模式创建不同类型的武器，并调用它们的功能。
        /// </summary>
        private static void StartFactoryMethod()
        {           
            AirDropGunFactory gun1 = new AWMFactory();
            AWM awm = (AWM)gun1.CreateGun();
            awm.CheckInfo();
            awm.Reload();
            awm.Shoot();

            Console.WriteLine();

            AirDropGunFactory gun2 = new FAMASFactory();
            FAMAS famas = (FAMAS)gun2.CreateGun();
            famas.CheckInfo();
            famas.Reload();
            famas.Shoot();

            Console.WriteLine();

            AirDropGunFactory gun3 = new P90Factory();
            P90 p90 = (P90)gun3.CreateGun();
            p90.CheckInfo();
            p90.Reload();
            p90.Shoot();


        }

        /// <summary>
        /// 抽象工厂模式示例，展示如何使用抽象工厂模式创建一系列相关的武器，并调用它们的功能。
        /// </summary>
        private static void AbstractFactoryMode() 
        { 
            IWeaponKit weapon1Kit = new AK47Kit();
            WeaponKit.IWeapon weapon1 = weapon1Kit.CreateWeapon();
            IAccessory accessory1 = weapon1Kit.CreateAccessory();

            accessory1.Attach(weapon1);

            weapon1.CheckInfo();
            weapon1.Reload();
            weapon1.Shoot();

            Console.WriteLine();

            IWeaponKit weapon2Kit = new AWMKit();
            WeaponKit.IWeapon weapon2 = weapon2Kit.CreateWeapon();
            IAccessory accessory2 = weapon2Kit.CreateAccessory();

            accessory2.Attach(weapon2);

            weapon2.CheckInfo();
            weapon2.Reload();
            weapon2.Shoot();

            Console.WriteLine();

            IWeaponKit weapon3Kit = new P90Kit();
            WeaponKit.IWeapon weapon3 = weapon3Kit.CreateWeapon();
            IAccessory accessory3 = weapon3Kit.CreateAccessory();

            accessory3.Attach(weapon3);

            weapon3.CheckInfo();
            weapon3.Reload();
            weapon3.Shoot();

        }

        /// <summary>
        /// 适配器模式示例，展示如何使用适配器模式将一个类的接口转换成客户希望的另一个接口，从而使原本由于接口不兼容而无法一起工作的类能够一起工作。
        /// </summary>
        private static void StartAdapterMode()
        {
            AdapterKit.Previous.IWeapon m3 = new M3();
            AdapterKit.Previous.IWeapon thompson = new Thompson();

            AdapterCurrentWeaponStandard adaptedM3 = new AdapterCurrentWeaponStandard(m3);
            AdapterCurrentWeaponStandard adaptedThompson = new AdapterCurrentWeaponStandard(thompson);

            adaptedM3.CheckInfo();
            adaptedM3.Reload();
            adaptedM3.Shoot();

            Console.WriteLine();

            adaptedThompson.CheckInfo();
            adaptedThompson.Reload();
            adaptedThompson.Shoot();


        }

    }
}
