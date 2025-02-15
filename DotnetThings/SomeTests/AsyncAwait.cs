
public class AsyncAwait
{
    // Synchronously copy all data from source to destination.
    public void CopyStreamToStream(Stream source, Stream destination)
    {
        var buffer = new byte[0x1000];
        int numRead;
        while ((numRead = source.Read(buffer, 0, buffer.Length)) != 0)
        {
            destination.Write(buffer, 0, numRead);
        }
    }
}
