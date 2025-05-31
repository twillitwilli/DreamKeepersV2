public interface IDamagable <T>
{
    float Health { get; set; }

    void Damage(T damageAmount);

    void Death();
}
