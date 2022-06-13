namespace LifeCycleOfDependencyInjection.Models
{
    public interface IGuidGenerator
    {
        Guid GuidValue { get; set; }        
    }

    public interface IScopedGuidGenerator: IGuidGenerator
    {
            
    }

    public interface ISingletonGuidGenerator : IGuidGenerator
    {

    }

    public interface ITransientGuidGenerator : IGuidGenerator
    {

    }

    public class ScopeguidGenerator : IScopedGuidGenerator
    {
        public Guid GuidValue { get; set ; }
        public ScopeguidGenerator()
        {
            GuidValue = Guid.NewGuid();
        }
    }

    public class SingletonGuidGenerator : ISingletonGuidGenerator
    {
        public Guid GuidValue { get; set; }
        public SingletonGuidGenerator()
        {
            GuidValue = Guid.NewGuid();
        }
        
    }

    public class TransientGuidGenerator : ITransientGuidGenerator
    {
        public Guid GuidValue { get ; set ; }
        public TransientGuidGenerator()
        {
            GuidValue = Guid.NewGuid();
        }
    }






}
