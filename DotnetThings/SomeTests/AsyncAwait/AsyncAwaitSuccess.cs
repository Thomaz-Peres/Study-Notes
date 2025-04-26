// Force an stack overflow
using System.Net;
using System.Net.Sockets;

namespace AsyncAwait
{
   public class AsyncAwaitSuccess
   {
       // this is terribly inefficient and is only being done in the name of study
       public static void Main(string[] args)
       {
           // If the OS is able to satisfy the operation synchronously, will complete synchronously.
           using Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
           listener.Bind(new IPEndPoint(IPAddress.Loopback, 0));
           listener.Listen();

           using Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
           client.Connect(listener.LocalEndPoint!);

           using Socket server = listener.Accept();
           _ = server.SendAsync(new byte[100_000]);

           var mres = new ManualResetEventSlim();
           byte[] buffer = new byte[1];

           var stream = new NetworkStream(client);

           void ReadAgain()
           {
               stream.BeginRead(buffer, 0, 1, iar =>
               {
                   if (stream.EndRead(iar) != 0)
                   {
                       ReadAgain(); // uh oh!
                   }
                   else
                   {
                       mres.Set();
                   }
               }, null);
           }
           ;
           ReadAgain();

           mres.Wait();
       }
   }

   public class AsyncAwaitSuccess2
   {
       public void Main(string arg)
       {
           var handler = new Handlerr();
           try
           {
               IAsyncResultt ar = handler.BeginDoStuff(arg, iar =>
               {
                   if (!iar.CompletedSynchronously)
                   {
                       try
                       {
                           Handlerr handler = (Handlerr)iar.AsyncState!;
                           int i = handler.EndDoStuff(iar);
                           Use(i);
                       }
                       catch (Exception e2)
                       {
                           //... // handle exceptions from EndDoStuff and Use

                       }
                   }
               }, handler);
               if (ar.CompletedSynchronously)
               {
                   int i = handler.EndDoStuff(ar);
                   Use(i);
               }
           }
           catch (Exception e)
           {
               ///... // handle exceptions that emerge synchronously from BeginDoStuff and possibly EndDoStuff/Use
           }
       }
   }
}
