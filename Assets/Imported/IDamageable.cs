namespace Imported
{
    public interface IDamageable
    {
        /// <summary>
        /// Purpose: This function is called by other objects dealing damage to this object via Interface. Write how to handle the incoming damage and typing.
        /// </summary>
        void Damage(float dmgNum, Elem dmgType, DeathType deathType = default);
    }
}
