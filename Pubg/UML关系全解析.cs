using System;
using System.Collections.Generic;
using BridgeKit;

namespace WeaponLib
{
    /// <summary>
    /// UML关系全解析：依赖、关联、聚合、组合 - 用代码说话
    /// </summary>
    public class UMLRelationshipsExplained
    {
        /*
         * ====================================================================
         * UML中的6种关系 - 从弱到强排序
         * ====================================================================
         * 
         * 1. 依赖（Dependency）        - - - - >  虚线箭头
         * 2. 关联（Association）       ————————>  实线箭头
         * 3. 聚合（Aggregation）       ◇———————>  空心菱形+实线
         * 4. 组合（Composition）       ◆———————>  实心菱形+实线
         * 5. 继承（Inheritance/泛化）   ————|>    空心三角箭头
         * 6. 实现（Realization）       - - -|>   虚线+空心三角箭头
         * 
         * 耦合度：依赖 < 关联 < 聚合 < 组合 < 继承
         * 
         */

        // ====================================================================
        // 1. 依赖关系（Dependency）- - - - >
        // ====================================================================
        /*
         * 核心特征：
         * ✓ 临时使用，不持有引用
         * ✓ 作为方法参数、局部变量、返回值
         * ✓ 最弱的耦合关系
         * ✓ 使用完即结束关系
         * 
         * 识别标志：
         * - 没有成员变量（字段/属性）
         * - 只在方法内部使用
         * - 用完就忘
         */
        public class Soldier
        {
            public string Name { get; set; }

            // ⚠️ 依赖关系：Weapon作为参数传入，用完就不再持有
            public void PickUpAndUse(Weapon weapon)  // 依赖Weapon
            {
                Console.WriteLine($"{Name} picked up a weapon temporarily");
                weapon.Fire();
                // 方法结束，不再持有weapon引用
            }

            // ⚠️ 依赖关系：Ammunition作为局部变量
            public void CheckAmmo()
            {
                Ammunition ammo = new Ammunition(30);  // 依赖Ammunition
                Console.WriteLine($"Ammo count: {ammo.Count}");
                // 方法结束，ammo被回收
            }

            // ⚠️ 依赖关系：返回类型
            public HealthPack FindHealthPack()  // 依赖HealthPack
            {
                return new HealthPack();
            }
        }

        public class Ammunition
        {
            public int Count { get; set; }
            public Ammunition(int count) { Count = count; }
        }

        public class HealthPack { }


        // ====================================================================
        // 2. 关联关系（Association）————————>
        // ====================================================================
        /*
         * 核心特征：
         * ✓ 长期持有引用（成员变量）
         * ✓ "知道"对方的存在
         * ✓ 可以是单向或双向
         * ✓ 比依赖更稳定
         * 
         * 识别标志：
         * - 有成员变量（字段/属性）
         * - 但不强调"拥有"关系
         * - 对象之间相对独立
         */
        public class Player
        {
            public string Name { get; set; }
            
            // ⚠️ 关联关系：持有Team的引用，但不拥有它
            public Team CurrentTeam { get; set; }  // 关联Team
            
            // ⚠️ 关联关系：持有多个Friend引用
            public List<Player> Friends { get; set; }  // 关联Player（自关联）

            public Player(string name)
            {
                Name = name;
                Friends = new List<Player>();
            }

            public void JoinTeam(Team team)
            {
                CurrentTeam = team;  // 从外部传入，不是自己创建
                Console.WriteLine($"{Name} joined {team.TeamName}");
            }

            public void AddFriend(Player friend)
            {
                Friends.Add(friend);  // 从外部传入
            }
        }

        public class Team
        {
            public string TeamName { get; set; }
            
            // 双向关联：Team也知道Player
            public List<Player> Members { get; set; }

            public Team(string name)
            {
                TeamName = name;
                Members = new List<Player>();
            }
        }


        // ====================================================================
        // 3. 聚合关系（Aggregation）◇———————>
        // ====================================================================
        /*
         * 核心特征：
         * ✓ 整体与部分的关系，但部分可独立存在
         * ✓ 部分在整体外部创建
         * ✓ 部分可以被多个整体共享
         * ✓ 整体销毁不影响部分
         * 
         * 识别标志：
         * - 通过构造函数或Setter传入（外部创建）
         * - "Has-a"关系，但不是强拥有
         * - 可以替换
         */
        public class Squad
        {
            public string SquadName { get; set; }
            
            // ⚠️ 聚合关系：持有武器列表，但不拥有它们
            public List<Weapon> SharedWeapons { get; set; }  // 聚合Weapon

            // 武器池从外部传入（外部创建）
            public Squad(string name, List<Weapon> weaponPool)
            {
                SquadName = name;
                SharedWeapons = weaponPool;  // 从外部传入，可共享
            }
        }

        // 使用示例：
        public static void AggregationExample()
        {
            // 武器池在外部创建
            List<Weapon> weaponPool = new List<Weapon>
            {
                new Rifle("AK-47", new FullAutoMode()),
                new Pistol("M1911", new SingleShotMode())
            };

            // 多个小队可以共享同一个武器池
            Squad squad1 = new Squad("Alpha", weaponPool);
            Squad squad2 = new Squad("Bravo", weaponPool);

            // 小队销毁，武器池仍然存在
            squad1 = null;
            Console.WriteLine($"Weapon pool still exists: {weaponPool.Count} weapons");
        }


        // ====================================================================
        // 4. 组合关系（Composition）◆———————>
        // ====================================================================
        /*
         * 核心特征：
         * ✓ 整体与部分的关系，部分不能独立存在
         * ✓ 部分在整体内部创建
         * ✓ 部分不能被共享
         * ✓ 整体销毁时部分必须销毁（同生共死）
         * 
         * 识别标志：
         * - 在构造函数内部new（内部创建）
         * - "Owns-a"关系，强拥有
         * - 私有字段，不暴露给外部
         */
        public class Vehicle
        {
            public string Name { get; set; }
            
            // ⚠️ 组合关系：引擎是车的一部分，不能独立存在
            private Engine engine;  // 组合Engine（私有，不暴露）
            
            // ⚠️ 组合关系：轮子是车的一部分
            private List<Wheel> wheels;  // 组合Wheel

            public Vehicle(string name)
            {
                Name = name;
                
                // 在内部创建，不从外部传入
                engine = new Engine("V8");  // 内部创建
                wheels = new List<Wheel>
                {
                    new Wheel(),  // 内部创建
                    new Wheel(),
                    new Wheel(),
                    new Wheel()
                };
            }

            public void Start()
            {
                engine.Start();  // 使用内部创建的对象
            }

            // 车销毁时，引擎和轮子也随之销毁
        }

        public class Engine
        {
            public string Type { get; set; }
            public Engine(string type) { Type = type; }
            public void Start() { Console.WriteLine($"{Type} engine started"); }
        }

        public class Wheel { }


        // ====================================================================
        // 对比总结表
        // ====================================================================
        /*
         * ┌─────────────────────────────────────────────────────────────────────────┐
         * │  核心区别表：依赖 vs 关联 vs 聚合 vs 组合                                 │
         * ├────────────┬─────────┬─────────┬─────────┬─────────┬──────────────────┤
         * │   特征     │  依赖   │  关联   │  聚合   │  组合   │   判断技巧       │
         * ├────────────┼─────────┼─────────┼─────────┼─────────┼──────────────────┤
         * │ 有成员变量 │   ✗     │   ✓     │   ✓     │   ✓     │ 看有没有字段/属性 │
         * ├────────────┼─────────┼─────────┼─────────┼─────────┼──────────────────┤
         * │ 创建位置   │  外部   │  外部   │  外部   │  内部   │ 看构造函数内部   │
         * │            │(临时)   │(传入)   │(传入)   │ (new)   │ 有没有new        │
         * ├────────────┼─────────┼─────────┼─────────┼─────────┼──────────────────┤
         * │ 生命周期   │  瞬时   │  独立   │  独立   │ 同生死  │ 整体销毁时看部分 │
         * ├────────────┼─────────┼─────────┼─────────┼─────────┼──────────────────┤
         * │ 可共享性   │  N/A    │可能共享 │ 可共享  │ 不可享  │ 看能否被多个对象 │
         * │            │         │         │         │         │ 同时持有         │
         * ├────────────┼─────────┼─────────┼─────────┼─────────┼──────────────────┤
         * │ 耦合强度   │  最弱   │  弱     │  中     │  强     │ 从左到右递增     │
         * ├────────────┼─────────┼─────────┼─────────┼─────────┼──────────────────┤
         * │ UML符号    │ - - ->  │ ——————> │ ◇————>  │ ◆————>  │ 虚/实/空/实菱形 │
         * ├────────────┼─────────┼─────────┼─────────┼─────────┼──────────────────┤
         * │ 代码特征   │ 参数/   │ 字段+   │ 字段+   │ 字段+   │                  │
         * │            │ 局部变量│ 外部传入│ 外部传入│ 内部new │                  │
         * ├────────────┼─────────┼─────────┼─────────┼─────────┼──────────────────┤
         * │ 关系强度   │ 用完就忘│长期持有 │整体部分 │强拥有   │                  │
         * ├────────────┼─────────┼─────────┼─────────┼─────────┼──────────────────┤
         * │ 现实例子   │ 顾客买菜│ 司机开车│公司-员工│ 人-心脏 │                  │
         * │            │(临时)   │(知道)   │(雇佣)   │(拥有)   │                  │
         * └────────────┴─────────┴─────────┴─────────┴─────────┴──────────────────┘
         * 
         * 
         * ====================================================================
         * 快速判断法（一针见血版）
         * ====================================================================
         * 
         * 第1步：看代码里有没有成员变量（字段/属性）？
         *    ✗ 没有 → 依赖关系
         *    ✓ 有   → 继续第2步
         * 
         * 第2步：这个成员变量在哪里创建？
         *    外部创建（参数传入/Setter赋值） → 继续第3步
         *    内部创建（构造函数里new）      → 组合关系 ◆
         * 
         * 第3步：这是"整体-部分"关系吗？
         *    ✗ 不是，只是"知道"对方 → 关联关系 ——>
         *    ✓ 是，但部分可独立存在 → 聚合关系 ◇
         * 
         * 
         * ====================================================================
         * 真实代码示例对比
         * ====================================================================
         */

        // 依赖：临时使用，不持有
        public class Example_Dependency
        {
            public void Method(Weapon weapon)  // weapon只是参数，用完就没了
            {
                weapon.Fire();
            }
        }

        // 关联：持有引用，但不是整体部分关系
        public class Example_Association
        {
            public Weapon CurrentWeapon { get; set; }  // 持有，但不拥有
            
            public void EquipWeapon(Weapon weapon)  // 从外部传入
            {
                CurrentWeapon = weapon;
            }
        }

        // 聚合：整体部分，但部分可独立
        public class Example_Aggregation
        {
            public List<Weapon> WeaponInventory { get; set; }  // 武器库
            
            public Example_Aggregation(List<Weapon> weapons)  // 从外部传入
            {
                WeaponInventory = weapons;  // 可共享
            }
        }

        // 组合：整体部分，部分不可独立
        public class Example_Composition
        {
            private Backpack backpack;  // 背包是玩家的一部分
            
            public Example_Composition()
            {
                backpack = new Backpack();  // 内部创建，同生共死
            }
        }

        public class Backpack { }


        // ====================================================================
        // 特殊情况：关联 vs 聚合 的模糊地带
        // ====================================================================
        /*
         * 有时候关联和聚合很难区分，因为：
         * 1. 都是持有引用
         * 2. 都可以从外部传入
         * 3. 都可以共享
         * 
         * 区分技巧：
         * - 问自己："这是整体-部分关系吗？"
         *   - 是 → 聚合（如：公司-员工，图书馆-图书）
         *   - 否 → 关联（如：老师-学生，司机-车）
         * 
         * - 问自己："部分是整体的组成要素吗？"
         *   - 是 → 聚合（如：车队-车辆）
         *   - 否 → 关联（如：会员-俱乐部）
         * 
         * 实话说：
         * - 在实际项目中，关联和聚合经常混用
         * - UML标准本身对这两者的区分也不是特别严格
         * - 重点是理解"依赖"和"组合"的区别
         * - 关联和聚合介于中间，有时可以不用太纠结
         */

        // ====================================================================
        // 回到你的问题：BridgeKit中的关系
        // ====================================================================
        /*
         * Weapon 和 IShootingMode 的关系：
         * 
         * ✓ 有成员变量：public IShootingMode ShootingMode { get; set; }
         * ✓ 外部创建：new Rifle("AK-47", fullAutoMode)
         * ✓ 可以共享：多个武器可用同一个模式对象
         * ✓ 可以替换：ChangeShootingMode()
         * ✓ 是整体-部分关系：射击模式是武器的组成部分
         * 
         * 结论：聚合关系 ◇
         * 
         * 如果不强调"整体-部分"，也可以说是关联关系
         * 但因为桥接模式的语义，聚合更准确
         */

        // ====================================================================
        // 终极记忆口诀
        // ====================================================================
        /*
         * 依赖 - - ->   ：方法参数局部变量，用完就忘最简单
         * 关联 ————>    ：成员变量长期持有，你知我来我知你
         * 聚合 ◇———>   ：外部创建可以共享，整体部分能分离
         * 组合 ◆———>   ：内部创建同生共死，生死相依不分离
         * 
         * 一句话：
         * 看有没有字段 → 看创建在哪里 → 看能否独立活
         */
    }
}
