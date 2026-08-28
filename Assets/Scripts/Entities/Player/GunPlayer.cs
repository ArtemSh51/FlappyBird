public class GunPlayer : Gun, IPlayerShootable
{
    public void Shoot()
    {
        TakeBullet();
    }
}
