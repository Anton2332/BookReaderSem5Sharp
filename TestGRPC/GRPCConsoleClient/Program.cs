// See https://aka.ms/new-console-template for more information


using Grpc.Net.Client;
using GrpcClient;

var data = new HelloRequest {Name = "Mukesh" };
var grpc = GrpcChannel.ForAddress(" https://localhost:7034");
var client = new Greeter.GreeterClient(grpc);
var response = await client.SayHelloAsync(data);
Console.WriteLine(response.Message);
Console.ReadLine();