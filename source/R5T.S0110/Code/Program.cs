using System;
using System.Threading.Tasks;


namespace R5T.S0110
{
    class Program
    {
        static async Task Main()
        {
            await Scripts.Instance.Get_GitHubClient();
        }
    }
}