using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using System.Text.Json;
using user_registration.models;
using serverless_sample.models;

[assembly:LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]
namespace AwsDotnetCsharp
{
    public class Handler
    {
       public string GetUser(APIGatewayProxyRequest request)
       {
           return "this is what you said: " + request.QueryStringParameters["personId"];
        //    return new Response("Go Serverless v1.0! Your function executed successfully!", request);
       }
       public string CreateUser(APIGatewayProxyRequest request)
       {
           Person person = JsonSerializer.Deserialize<Person>(request.Body);
           using (var db = new UserContext()) {
               db.Add(person);
               db.SaveChanges();
           }
            return "Ok!";
       }
       public string DeleteUser(APIGatewayProxyRequest request)
       {
           return "this is what you said: " + request.QueryStringParameters["personId"];
        //    return new Response("Go Serverless v1.0! Your function executed successfully!", request);
       }
    }
}
