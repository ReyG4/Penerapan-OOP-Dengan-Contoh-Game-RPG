using OOP.Entities;
using OOP.Items;
using OOP.Weapons;

namespace OOP.SystemGame;

class ChoosingItem
{
    public void ChoseItem(int choseItem, Player player)
    {
        if (choseItem >= 0 && choseItem < player.Inventory.Count)
        {
            Console.WriteLine($"Kamu memilih {player.Inventory[choseItem].Name}");
            if (player.Inventory[choseItem] is Torch torch)
            {
                torch.ShowInfo();
                Console.WriteLine("1. Gunakan Item\n2. Gunakan Sebagai Senjata\n3. Buang item");
                Console.Write("Pilih: ");
                string discard = Console.ReadLine() ?? "";
                if (discard == "1")
                {
                    Console.Write("Gunakan Item Ini? (y/n) ");
                    string useChoise = Console.ReadLine() ?? "";
                    if (useChoise == "y")
                    {
                        player.UseItem(choseItem);
                        player.ShowStatus();
                    }
                    else if (useChoise == "n")
                    {
                        Console.WriteLine("Kembali Ke menu...");
                    }
                    else
                    {
                        Console.WriteLine("Input Tidak sesuai");
                    }
                }
                else if (discard == "2")
                {
                    if (player.EquippedWeapon is null)
                    {
                        Console.Write("Gunakan Sebagi Senjata? (y/n) ");
                    }
                    else
                    {
                        Console.Write($"Mau mengganti {player.EquippedWeapon.Name} dengan {torch.Name}? (y/n)");
                    }
                    string useChoise = Console.ReadLine() ?? "";
                    if (useChoise == "y")
                    {
                        player.UseWeapon(torch);
                        player.ShowStatus();
                    }
                    else if (useChoise == "n")
                    {
                        Console.WriteLine("Kembali Ke menu...");
                    }
                    else
                    {
                        Console.WriteLine("Input Tidak sesuai");
                    }
                }
                else if (discard == "3")
                {
                    player.DiscardItem(choseItem);
                }
                else
                {
                    Console.WriteLine("Input Tidak sesuai");
                }
            }
            else if (player.Inventory[choseItem] is Weapon weapon)
            {
                weapon.ShowInfo();
                Console.Write("1. Gunakan senjata\n2. Buang Senjata");
                Console.Write("Pilih: ");
                string discard = Console.ReadLine() ?? "";
                if (discard == "1")
                {
                    if (player.EquippedWeapon is null)
                    {
                        Console.WriteLine("Gunakan Sebagi Senjata? (y/n) ");
                    }
                    else
                    {
                        Console.Write($"Mau mengganti {player.EquippedWeapon.Name} dengan {weapon.Name}? (y/n)");
                    }
                    string useChoise = Console.ReadLine() ?? "";
                    if (useChoise == "y")
                    {
                        player.UseWeapon(weapon);
                        player.ShowStatus();
                    }
                    else if (useChoise == "n")
                    {
                        Console.WriteLine("Kembali Ke menu...");
                    }
                    else
                    {
                        Console.WriteLine("Input Tidak sesuai");
                    }
                }
                else if (discard == "2")
                {
                    player.DiscardItem(choseItem);
                }
                else
                {
                    Console.WriteLine("Input Tidak sesuai");
                }
            }
            else if (player.Inventory[choseItem] is Item item)
            {
                item.ShowInfo();
                Console.WriteLine("1. Gunakan Item\n2. Buang Item");
                Console.Write("Pilih: ");
                string discard = Console.ReadLine() ?? "";
                if (discard == "1")
                {
                    Console.Write("Gunakan Item Ini? (y/n) ");
                    string useChoise = Console.ReadLine() ?? "";
                    if (useChoise == "y")
                    {
                        player.UseItem(choseItem);
                        player.ShowStatus();
                    }
                    else if (useChoise == "n")
                    {
                        Console.WriteLine("Kembali Ke menu...");
                    }
                    else
                    {
                        Console.WriteLine("Input Tidak sesuai");
                    }
                }
                else if (discard == "2")
                {
                    player.DiscardItem(choseItem);
                }
                else
                {
                    Console.WriteLine("Input Tidak sesuai");
                }
            }
        }

    }
}