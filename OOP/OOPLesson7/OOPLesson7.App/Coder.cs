namespace OOPLesson7.App
{
    public interface ICoder
    {
        string Encoder(string payload);
        string Decoder(string data);
    }
}