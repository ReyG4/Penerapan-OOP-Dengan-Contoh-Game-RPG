namespace OOP.Entites;

class Skeleton : Enemy
{
    public Skeleton() : base("Skeleton", 40, 10) { }

    public override void InfoEnemy()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"HP: {Hp}");
        Console.WriteLine($"Damage: {Damage}");
        Console.WriteLine("Memiliki kesempatan 30% kabur ketika HP dibawah 20");
    }
    public void SpesialAbility()
    {
        if (Hp > 20)
        {
            Random rnd = new();
            int chanceRun = rnd.Next(1, 101);
            if (chanceRun <= 30)
            {
                Console.WriteLine($"{Name} berhasil mengelabui mu dan pergi meninggalkan mu!");
            }
        }
    }

    public override void Attack(int damage)
    {
        if (damage < 0) return;
        Console.WriteLine($"{Name} menyerang dengan tulangnya! memberikan {damage} damage!");
    }


}