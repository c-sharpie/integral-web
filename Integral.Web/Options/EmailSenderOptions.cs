namespace Integral.Options
{
    public class EmailSenderOptions
    {
        public string? Host { get; set; }

        public ushort Port { get; set; }

        public string? Username { get; set; }

        public string? Password { get; set; }

        public bool EnableSsl { get; set; }

        public int Timeout { get; set; }
    }
}
