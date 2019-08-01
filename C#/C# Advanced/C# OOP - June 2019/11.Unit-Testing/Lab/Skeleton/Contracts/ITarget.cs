namespace Skeleton.Contracts
{
    public interface ITarget
    {
        void TakeAttack(int damage);

        bool IsDead();

        int GiveExperience();
    }
}
