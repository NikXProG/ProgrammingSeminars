using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.Extensions.Options;
using RGU.WebProgramming.Client.API;
using RGU.WebProgramming.Client.Grpc;
using RGU.WebProgramming.Client.Grpc.Settings;
using RGU.WebProgramming.Grpc;



var hostMediator = new HostMediator(new GrpcChannelFactory(Options.Create(new GrpcClientSettings
{
    TargetAddress = "127.0.0.1:5055"
})), Options.Create(new HostMediatorSettings
{
    // Настройки
}), null);

var clientService = hostMediator;

var obj = new CancellationTokenSource();

try
{
    await FooAsync(obj.Token);
}
catch (OperationCanceledException)
{
    Console.WriteLine("Operation was cancelled.");
}
finally
{
    obj.Dispose();
}


async Task<int> FooAsync(CancellationToken cancellationToken = default)
{
    return await BarAsync(cancellationToken);
}

async Task<int> BarAsync(CancellationToken cancellationToken = default)
{
    while (true)
    {
        Console.WriteLine("FooAsync");
        var result = await clientService.MyFirstRPCAsync(cancellationToken);
        Console.WriteLine($"Value == {result.Value}, Abrakadabra == {result.Abrakadabra}");
        // Основная логика
        if (cancellationToken.IsCancellationRequested)
        {
            Console.WriteLine("Cancellation requested.");

            return 0;
        }
        await Task.Delay(100); 
    }
    return 0;
}