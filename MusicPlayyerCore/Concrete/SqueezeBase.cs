namespace MusicPlayerCore.Concrete
{
    public  abstract class SqueezeBase
    {
        protected virtual SqueezeConfig SqueezeConfig
        {
            get
            {
                return SqueezeConfig.Instance;
            }
        }
    }
}
