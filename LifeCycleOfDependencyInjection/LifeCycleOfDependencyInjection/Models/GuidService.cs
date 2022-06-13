namespace LifeCycleOfDependencyInjection.Models
{
    public class GuidService
    {
        public readonly ISingletonGuidGenerator _singletonGuidGenerator;
        public readonly ITransientGuidGenerator _transientGuidGenerator;
        public readonly IScopedGuidGenerator _scopedGuidGenerator;

        public GuidService(ISingletonGuidGenerator singletonGuidGenerator, ITransientGuidGenerator transientGuidGenerator, IScopedGuidGenerator scopedGuidGenerator)
        {
            _singletonGuidGenerator = singletonGuidGenerator;
            _transientGuidGenerator = transientGuidGenerator;
            _scopedGuidGenerator = scopedGuidGenerator;
        }

        
    }
}
