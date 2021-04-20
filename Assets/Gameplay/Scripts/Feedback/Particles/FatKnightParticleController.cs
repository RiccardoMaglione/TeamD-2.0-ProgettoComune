public class FatKnightParticleController : BasePlayerParticles
{
    public static FatKnightParticleController instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }       
    }
}
