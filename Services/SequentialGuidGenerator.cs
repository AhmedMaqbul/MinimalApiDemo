using MinimalApiDemo.Services.Abstractions;

namespace MinimalApiDemo.Services;

public class SequentialGuidGenerator : IGuidGenerator
{
    public Guid Create()
    {
        return Guid.CreateVersion7();
    }
}
