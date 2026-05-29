using System;
using BridgeKit;

namespace WeaponLib
{
    /// <summary>
    /// 聚合关系 vs 组合关系对比示例
    /// </summary>
    public class AggregationVsComposition
    {
        // ====================================================================
        // 当前实现：聚合关系（Aggregation）- 使用空心菱形 ◇
        // ====================================================================
        public static void AggregationExample()
        {
            Console.WriteLine("=== 聚合关系示例 ===\n");

            // 1. ShootingMode在Weapon外部创建（独立存在）
            IShootingMode fullAutoMode = new FullAutoMode();
            IShootingMode brustMode = new BrustMode();

            // 2. ShootingMode作为参数传入
            Weapon ak47 = new Rifle("AK-47", fullAutoMode);
            Weapon m16 = new Rifle("M16", fullAutoMode);  // 共享同一个对象！

            Console.WriteLine($"AK-47的射击模式对象哈希: {ak47.ShootingMode.GetHashCode()}");
            Console.WriteLine($"M16的射击模式对象哈希:  {m16.ShootingMode.GetHashCode()}");
            Console.WriteLine($"是同一个对象: {ReferenceEquals(ak47.ShootingMode, m16.ShootingMode)}");

            // 3. 可以动态替换
            ak47.ChangeShootingMode(brustMode);
            Console.WriteLine($"\n切换后AK-47的射击模式对象哈希: {ak47.ShootingMode.GetHashCode()}");

            // 4. 即使ak47被销毁，fullAutoMode对象仍然存在
            ak47 = null;
            Console.WriteLine($"\nAK-47销毁后，M16仍在使用fullAutoMode:");
            m16.Fire();

            // 结论：ShootingMode的生命周期独立于Weapon
            Console.WriteLine("\n✓ 这是聚合关系：部分可独立存在，可共享，可替换");
        }

        // ====================================================================
        // 如果改成：组合关系（Composition）- 使用实心菱形 ◆
        // ====================================================================
        public static void CompositionExample()
        {
            Console.WriteLine("\n=== 组合关系示例 ===\n");

            // 组合关系的Weapon实现（假设）
            WeaponWithComposition ak47 = new WeaponWithComposition("AK-47", "FullAuto");
            WeaponWithComposition m16 = new WeaponWithComposition("M16", "FullAuto");

            Console.WriteLine($"AK-47的射击模式对象哈希: {ak47.GetShootingModeHash()}");
            Console.WriteLine($"M16的射击模式对象哈希:  {m16.GetShootingModeHash()}");
            Console.WriteLine($"是同一个对象: {ak47.GetShootingModeHash() == m16.GetShootingModeHash()}");

            Console.WriteLine("\n✗ 无法共享：每个武器内部创建自己的射击模式对象");
            Console.WriteLine("✗ 无法动态替换：射击模式在构造时确定");
            Console.WriteLine("✓ 同生命周期：武器销毁时，射击模式随之销毁");
        }
    }

    // ====================================================================
    // 组合关系的Weapon实现示例
    // ====================================================================
    public class WeaponWithComposition
    {
        public string Name { get; private set; }
        // 私有字段，外部无法访问和替换
        private IShootingMode shootingMode;

        public WeaponWithComposition(string name, string modeType)
        {
            Name = name;
            
            // ⚠️ 关键区别：在构造函数内部创建ShootingMode（组合）
            // 而不是从外部传入（聚合）
            switch (modeType)
            {
                case "Single":
                    shootingMode = new SingleShotMode();
                    break;
                case "Brust":
                    shootingMode = new BrustMode();
                    break;
                case "FullAuto":
                    shootingMode = new FullAutoMode();
                    break;
                default:
                    shootingMode = new SingleShotMode();
                    break;
            }
        }

        public void Fire()
        {
            Console.WriteLine($"{Name} is firing:");
            shootingMode.Shoot();
        }

        public int GetShootingModeHash()
        {
            return shootingMode.GetHashCode();
        }

        // ⚠️ 没有ChangeShootingMode方法，无法动态替换
        // 或者即使有，也是销毁旧对象，创建新对象，而不是引用外部对象
    }

    // ====================================================================
    // 对比总结
    // ====================================================================
    /*
     * ┌─────────────────────────────────────────────────────────────────┐
     * │  特征对比表：聚合 vs 组合                                         │
     * ├──────────────────┬────────────────┬─────────────────────────────┤
     * │      特征        │   聚合关系 ◇   │      组合关系 ◆             │
     * ├──────────────────┼────────────────┼─────────────────────────────┤
     * │ 创建位置         │ 外部创建       │ 内部创建                     │
     * │ 传递方式         │ 参数传入       │ 内部new                      │
     * │ 生命周期         │ 独立           │ 依赖（同生共死）             │
     * │ 可共享性         │ 可共享         │ 不可共享（每个对象独占）     │
     * │ 可替换性         │ 可动态替换     │ 不可替换或创建新对象替换     │
     * │ 销毁行为         │ 整体销毁不影响 │ 整体销毁，部分必须销毁       │
     * │                  │ 部分           │                             │
     * │ UML表示          │ ◇────>        │ ◆────>                      │
     * │ 现实例子         │ 公司与员工     │ 人与心脏                     │
     * │                  │ (员工可跳槽)   │ (心脏不能独立存在)           │
     * └──────────────────┴────────────────┴─────────────────────────────┘
     * 
     * 
     * 当前BridgeKit的代码特征：
     * ✓ ShootingMode在外部创建：new FullAutoMode()
     * ✓ 通过构造函数传入：new Rifle("AK-47", fullAutoMode)
     * ✓ 可以共享：多个武器可使用同一个模式对象
     * ✓ 可以动态替换：ChangeShootingMode(brustMode)
     * ✓ 独立生命周期：武器销毁后，模式对象仍可存在
     * 
     * 结论：这是典型的聚合关系（Aggregation）
     * 
     * 
     * ====================================================================
     * 你的疑问解答：
     * ====================================================================
     * 
     * Q: "射击模式是不能独立于武器单独存在的吧？"
     * A: 这取决于设计角度：
     * 
     * 1. 从现实世界来看：
     *    - 你说得对，射击模式是武器的一部分，不能独立存在
     *    - 如果严格模拟现实，应该用组合关系
     * 
     * 2. 从软件设计来看：
     *    - 桥接模式的目的是让两个维度独立变化
     *    - 将射击模式设计为独立对象，可以：
     *      a. 在多个武器间共享（节省内存）
     *      b. 动态切换（灵活性）
     *      c. 独立扩展射击模式类型
     * 
     * 3. 当前代码的实现：
     *    - 代码中ShootingMode对象确实可以独立存在
     *    - 可以在方法外创建：IShootingMode mode = new FullAutoMode()
     *    - 可以被多个武器共享
     *    - 所以实现上是聚合关系
     * 
     * 
     * ====================================================================
     * 何时用聚合？何时用组合？
     * ====================================================================
     * 
     * 使用聚合关系（当前BridgeKit的做法）：
     * ✓ 需要部分对象可以被多个整体共享
     * ✓ 需要动态替换部分对象
     * ✓ 部分对象的生命周期可能长于整体
     * ✓ 桥接模式、策略模式等设计模式
     * 
     * 例如：
     * - 公司 ◇── 员工（员工可以跳槽）
     * - 图书馆 ◇── 图书（图书可以借出）
     * - 武器 ◇── 射击模式（模式可以切换和共享）
     * 
     * 
     * 使用组合关系：
     * ✓ 部分对象不能独立于整体存在
     * ✓ 整体销毁时部分必须销毁
     * ✓ 部分不能被共享
     * ✓ 强调"拥有"关系
     * 
     * 例如：
     * - 人 ◆── 心脏（心脏不能独立存在）
     * - 订单 ◆── 订单明细（订单删除，明细必删）
     * - 窗口 ◆── 滚动条（窗口关闭，滚动条消失）
     * 
     * 
     * ====================================================================
     * 修正后的UML图应该用：
     * ====================================================================
     * 
     * Weapon ◇── IShootingMode  （空心菱形，聚合关系）
     * 
     * 而不是：
     * Weapon ◆── IShootingMode  （实心菱形，组合关系）
     * 
     * 
     * ====================================================================
     * 总结：
     * ====================================================================
     * 
     * 你的直觉是对的，从现实世界角度看，射击模式应该是组合关系。
     * 但从当前代码实现和桥接模式的设计意图看，它是聚合关系。
     * 
     * 这是软件设计中常见的取舍：
     * - 为了灵活性和可扩展性，牺牲了一些现实世界的严格映射
     * - 桥接模式的核心就是让两个维度独立，所以用聚合更合适
     * 
     */
}
