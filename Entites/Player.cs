namespace OOP.Entites;

using OOP.Interface;
using OOP.Items;
using OOP.Weapons;

class Player(string name) : ICanDamageable, ICanAttack
{
    int _hp = 100;
    int _sanity = 100;
    int _hunger = 0;
    int _damage = 20;

    public List<Item> Inventory { get; set; } = [];

    public string Name { get; set; } = name;
    public int Hp => _hp;
    public int Sanity => _sanity;
    public int Hunger => _hunger;
    public int Damage => _damage;
    public Weapon? EquippedWeapon { get; set; }
    public bool EffectTorch { get; set; } = false;

    public void TakeDamage(int damage)
    {
        if (damage < 0) return;
        _hp -= damage;
        Console.WriteLine($"{Name} kamu terkena {damage} damage, sisa HP kamu {_hp}");
    }

    public void LossSanity(int sanity)
    {
        if (sanity < 0) return;
        if (EffectTorch)
        {
            sanity -= 10;
            EffectTorch = false;
        }
        _sanity -= sanity;
        Console.WriteLine($"{Name} kamu kehilangan {sanity} sanity, sisa sanity kamu {_sanity}");
    }

    public void UseWeapon(Weapon weapon)
    {
        if (weapon == null) return;
        EquippedWeapon = weapon;
        Console.WriteLine($"{Name} kamu menggunakan {weapon.Name} sebagai senjata.");
    }

    public void Attack()
    {
        if (EquippedWeapon != null)
        {
            EquippedWeapon.Attack(this);
        }
        else
        {
            Console.WriteLine($"{Name} kamu menyerang dengan damage {_damage}");
        }
    }

    public void WeaponAttack(Weapon weapon)
    {
        if (weapon == null) return;
        var weaponUsed = weapon;
        weaponUsed.Attack(this);
    }

    public void Heal(int heal)
    {
        if (heal < 0) return;
        _hp += heal;
        if (_hp > 100) _hp = 100;
        Console.WriteLine($"{Name} kamu sembuh sebesar {heal} HP, total HP kamu {_hp}");
    }

    public void HealSanity(int heal)
    {
        if (heal < 0) return;
        _sanity += heal;
        if (_sanity > 100) _sanity = 100;
        Console.WriteLine($"{Name} kamu mengembalikan {heal} Sanity, total Sanity kamu {_sanity}");
    }

    public void IncreaseHunger(int hunger)
    {
        if (hunger < 0) return;
        _hunger += hunger;
        if (_hunger > 100) _hunger = 100;
        Console.WriteLine($"{Name} kamu bertambah lapar sebesar {hunger}, total Hunger kamu {_hunger}");
        if (_hunger >= 80 && _hunger < 100)
        {
            Console.WriteLine($"{Name} kamu merasa sangat lapar, Segeralah makan sesuatu!!");
        }
    }

    public void DecreaseHunger(int hunger)
    {
        if (hunger < 0) return;
        _hunger -= hunger;
        if (_hunger < 0) _hunger = 0;
        Console.WriteLine($"Lapar kamu berkurang sebesar {hunger}, total Hunger kamu {_hunger}");
    }

    public void ShowStatus()
    {
        Console.WriteLine("=== Player Status ===");
        Console.WriteLine($"Player: {Name}");
        Console.WriteLine($"HP: {_hp}");
        Console.WriteLine($"Sanity: {_sanity}");
        Console.WriteLine($"Hunger: {_hunger}");
        if (EquippedWeapon != null)
        {
            Console.WriteLine($"Equipped Weapon: {EquippedWeapon.Name} (Damage: {EquippedWeapon.Damage})");
        }
        else
        {
            Console.WriteLine("No weapon equipped.");
        }
        Console.WriteLine("=====================");
    }

    public void ShowInventory()
    {
        Console.WriteLine("=== Inventory ===");
        if (Inventory.Count == 0)
        {
            Console.WriteLine("Inventory kosong.");
        }
        else
        {
            foreach (var item in Inventory)
            {
                int counter = Inventory.IndexOf(item) + 1;
                Console.WriteLine($"{counter}. ");
                item.ShowInfo();
                Console.WriteLine("--------------------");
            }
        }
    }

    public void UseItem(int index)
    {
        int trueIndex = index - 1;
        if (trueIndex >= 0 && trueIndex < Inventory.Count)
        {
            var item = Inventory[trueIndex];
            item.UseItem(this);
        }
    }

    public void DiscardItem(int index)
    {
        int trueIndex = index - 1;
        if (trueIndex >= 0 && trueIndex < Inventory.Count)
        {
            var item = Inventory[trueIndex];
            Console.WriteLine($"{Name} kamu membuang {item.Name}");
            Inventory.RemoveAt(trueIndex);
        }
    }

    public void FoundItem(Item itemFound)
    {
        Console.WriteLine($"{Name} kamu menemukan {itemFound.Name}!");

        if (itemFound is Weapon)
        {
            itemFound.ShowInfo();
        }
        else
        {
            itemFound.ShowInfo();
        }
    }

    public void AddToInventory(Item itemFound)
    {
        var existingItem = Inventory.FirstOrDefault(
            i => i.Name.Equals(
                itemFound.Name,
                StringComparison.OrdinalIgnoreCase)
            );

        if (existingItem != null)
        {
            existingItem.Quantity += itemFound.Quantity;
            Console.WriteLine($"Quantity {itemFound.Name} ditambahkan. Jumlah {existingItem.Quantity}");
        }
        else
        {
            Inventory.Add(itemFound);
            Console.WriteLine($"Kamu mengambil {itemFound.Name}\n{itemFound.Name} dimasukan ke inventory");
        }
    }
}