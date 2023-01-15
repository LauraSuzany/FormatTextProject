namespace FormatTextProject.Service
{
    public interface IChangeTextService
    {
        public string HtmlToWhatsApp(string text);
        public string WhatsAppToHtml(string text);
    }
}
