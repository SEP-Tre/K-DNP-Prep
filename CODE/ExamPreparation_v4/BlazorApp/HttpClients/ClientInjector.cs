namespace WASM_.Pages;

public class ClientInjector:IClientInjector
{
    public HttpClient client { get; set; }

    public ClientInjector(HttpClient client)
    {
        this.client = client;
    }

    public HttpClient GetClient()
    {
        return client;
    }
}