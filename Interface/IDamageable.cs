namespace OOP.Interface;

interface ICanDamageable
{
    void TakeDamage(int damage);
    int Hp { get; }
}